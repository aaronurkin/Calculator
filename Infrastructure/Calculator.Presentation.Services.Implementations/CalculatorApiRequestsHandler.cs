using AutoMapper;
using Calculator.Application.Models;
using Calculator.Application.Services;
using Calculator.Presentation.Models;
using Microsoft.Extensions.Logging;

namespace Calculator.Presentation.Services.Implementations
{
    public class CalculatorApiRequestsHandler : ICalculatorApiRequestsHandler
    {
        private readonly IMapper mapper;
        private readonly IServiceResolver services;
        private readonly ApplicationRequestContext requestContext;
        private readonly ILogger<CalculatorApiRequestsHandler> logger;

        public CalculatorApiRequestsHandler(IServiceResolver services)
        {
            if (services == null)
            {
                throw new System.ArgumentNullException(nameof(services));
            }

            this.services = services;
            this.mapper = services.Resolve<IMapper>();
            this.requestContext = services.Resolve<ApplicationRequestContext>();
            this.logger = services.Resolve<ILogger<CalculatorApiRequestsHandler>>();

            if (this.mapper == null || this.logger == null || this.requestContext == null)
            {
                throw new System.Exception($"Missing dependencies. {typeof(CalculatorApiRequestsHandler).FullName} instanse can't be created");
            }
        }

        public ApiResponse Handle(CalculateApiRequest request)
        {
            try
            {
                var operation = this.services.ResolveNamed<ICalculatorOperation>(request.Operation);

                if (operation == null)
                {
                    this.logger.LogWarning($"Unknown operation has been requested: {request.Operation}");
                    return new UnknownOperationApiResponse($"Unknown operation: {request.Operation}");
                }

                var resultResolver = this.services.ResolveNamed<ICalculatorOperationResultResolver>(this.requestContext.ServiceName);

                if (resultResolver == null)
                {
                    this.logger.LogWarning($"Unknown service name has been generated: {this.requestContext.ServiceName}");
                    return new UnknownClientApiResponse($"Unknown client: {this.requestContext.ServiceName}");
                }

                var operationResult = operation.Calculate(this.mapper.Map<OperationCalculateDto>(request));
                var responseData = resultResolver.Resolve(operationResult);

                return new ApiResponse<CalculateResultDto>(responseData);
            }
            catch (System.Exception exception)
            {
                this.logger.LogError(exception, "FAILED Handling {0}", typeof(CalculateApiRequest).Name);
                return new ApiResponse(System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
