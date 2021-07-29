using Calculator.Application.Models;
using Calculator.Presentation.Models;

namespace Calculator.Presentation.Services
{
    public interface ICalculatorApiRequestsHandler
    {
        CalculateApiResponse<CalculateResultDto> Handle(CalculateApiRequest request);
    }
}
