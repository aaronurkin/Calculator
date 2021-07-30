using AutoMapper;
using Calculator.Application.Models;

namespace Calculator.Application.Services.Implementations
{
    public class CalculatorOperationManager : ICalculatorOperationManager
    {
        private readonly IMapper mapper;
        private readonly IServiceResolver serviceResolver;

        public CalculatorOperationManager(
            IMapper mapper,
            IServiceResolver serviceResolver
        )
        {
            this.mapper = mapper;
            this.serviceResolver = serviceResolver;
        }

        public CalculateResultDto Calculate(CalculateDto data)
        {
            var operation = this.serviceResolver.ResolveNamed<ICalculatorOperation>(data.OperationType);
            var resultResolver = this.serviceResolver.ResolveNamed<ICalculatorOperationResultResolver>(data.ResponseType);

            var dto = this.mapper.Map<OperationCalculateDto>(data);

            var operationResult = operation.Calculate(dto);
            var result = resultResolver.Resolve(operationResult);

            return result;
        }
    }
}
