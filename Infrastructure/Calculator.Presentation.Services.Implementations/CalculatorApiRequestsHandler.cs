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

        public CalculateApiResponse<CalculateResultDto> Handle(CalculateApiRequest request)
        {
            try
            {
                var operation = this.services.ResolveNamed<ICalculatorOperation>(request.Operation);
                var operationResult = operation.Calculate(this.mapper.Map<OperationCalculateDto>(request));

                var resultResolver = this.services.ResolveNamed<ICalculatorOperationResultResolver>(this.requestContext.ServiceName);
                var result = resultResolver.Resolve(operationResult);

                return new CalculateApiResponse<CalculateResultDto>(result);
            }
            catch (System.Exception exception)
            {
                this.logger.LogError(exception, "FAILED Handling {0}", typeof(CalculateApiRequest).Name);
                return new CalculateApiResponse<CalculateResultDto>(System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
