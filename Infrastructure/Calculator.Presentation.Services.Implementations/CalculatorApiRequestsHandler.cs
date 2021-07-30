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

        public CalculatorApiRequestsHandler(
            IMapper mapper,
            IServiceResolver services,
            ApplicationRequestContext requestContext,
            ILogger<CalculatorApiRequestsHandler> logger
        )
        {
            this.logger = logger;
            this.mapper = mapper;
            this.services = services;
            this.requestContext = requestContext;
        }

        public CalculateApiResponse Handle(CalculateApiRequest request)
        {
            try
            {
                var operation = this.services.ResolveNamed<ICalculatorOperation>(request.Operation);

                if (operation == null)
                {
                    this.logger.LogWarning($"Invalid operation has been requested: {request.Operation}");
                    return new CalculateApiResponse<string>(System.Net.HttpStatusCode.BadRequest, $"Invalid operation {request.Operation}");
                }

                var operationResult = operation.Calculate(this.mapper.Map<OperationCalculateDto>(request));

                var resultResolver = this.services.ResolveNamed<ICalculatorOperationResultResolver>(this.requestContext.ServiceName);

                if (resultResolver == null)
                {
                    this.logger.LogWarning($"Unknown service name has been generated: {this.requestContext.ServiceName}");
                    return new CalculateApiResponse<string>(System.Net.HttpStatusCode.BadRequest, "Unknown client");
                }

                var responseData = resultResolver.Resolve(operationResult);

                return new CalculateApiResponse<CalculateResultDto>(responseData);
            }
            catch (System.Exception exception)
            {
                this.logger.LogError(exception, "FAILED Handling {0}", typeof(CalculateApiRequest).Name);
                // TODO: Remove exception from response body! TEST PURPOSES ONLY!
                return new CalculateApiResponse<System.Exception>(System.Net.HttpStatusCode.InternalServerError, exception);
            }
        }
    }
}
