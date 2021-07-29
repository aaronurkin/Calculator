using Calculator.Presentation.Models;
using Calculator.Presentation.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Presentation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorApiRequestsHandler requestsHandler;

        public CalculatorController(ICalculatorApiRequestsHandler requestsHandler)
        {
            this.requestsHandler = requestsHandler;
        }

        public IActionResult Post(CalculateApiRequest model)
        {
            var response = this.requestsHandler.Handle(model);
            return this.StatusCode((int)response.StatusCode, response.Data);
        }
    }
}
