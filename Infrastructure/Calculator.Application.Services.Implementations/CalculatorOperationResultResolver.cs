using Calculator.Application.Models;

namespace Calculator.Application.Services.Implementations
{
    public class CalculatorOperationResultResolver : ICalculatorOperationResultResolver
    {
        public CalculateResultDto Resolve(OperationCalculateResult operationResult)
        {
            // TODO: Map using Automapper
            return new CalculateResultDto
            {
                Value = operationResult.Value
            };
        }
    }
}
