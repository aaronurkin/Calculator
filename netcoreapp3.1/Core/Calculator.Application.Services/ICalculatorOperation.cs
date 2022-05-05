using Calculator.Application.Models;

namespace Calculator.Application.Services
{
    public interface ICalculatorOperation
    {
        OperationCalculateResult Calculate(OperationCalculateDto input);
    }
}
