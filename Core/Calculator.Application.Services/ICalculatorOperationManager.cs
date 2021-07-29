using Calculator.Application.Models;

namespace Calculator.Application.Services
{
    public interface ICalculatorOperationManager
    {
        CalculateResultDto Calculate(CalculateDto data);
    }
}
