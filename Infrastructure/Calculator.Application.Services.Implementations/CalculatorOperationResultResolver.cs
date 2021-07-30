using AutoMapper;
using Calculator.Application.Models;

namespace Calculator.Application.Services.Implementations
{
    public class CalculatorOperationResultResolver : ICalculatorOperationResultResolver
    {
        private readonly IMapper mapper;

        public CalculatorOperationResultResolver(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public CalculateResultDto Resolve(OperationCalculateResult operationResult)
        {
            var result = this.mapper.Map<CalculateResultDto>(operationResult);
            return result;
        }
    }
}
