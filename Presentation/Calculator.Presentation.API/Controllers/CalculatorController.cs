using Calculator.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Calculator.Presentation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        public IActionResult Post(CalculateApiRequest model)
        {
            throw new NotImplementedException();
        }
    }
}
