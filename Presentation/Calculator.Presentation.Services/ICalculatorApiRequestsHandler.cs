using Calculator.Presentation.Models;

namespace Calculator.Presentation.Services
{
    public interface ICalculatorApiRequestsHandler
    {
        CalculateApiResponse Handle(CalculateApiRequest request);
    }
}
