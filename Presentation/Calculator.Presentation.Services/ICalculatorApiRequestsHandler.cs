using Calculator.Presentation.Models;

namespace Calculator.Presentation.Services
{
    public interface ICalculatorApiRequestsHandler
    {
        ApiResponse Handle(CalculateApiRequest request);
    }
}
