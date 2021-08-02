using Calculator.Application.Models;

namespace Calculator.Application.Services
{
    public interface ICalculatorOperationResultResolver
    {
        CalculateResultDto Resolve(OperationCalculateResult operationResult);
    }
}
