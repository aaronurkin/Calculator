using AutoMapper;
using Calculator.Application.Models;
using Calculator.Application.Services;
using Calculator.Presentation.Models;

namespace Calculator.Presentation.Services.Implementations
{
    public class CalculatorApiRequestsHandler : ICalculatorApiRequestsHandler
    {
        private readonly IMapper mapper;
        private readonly ICalculatorOperationManager calculatorOperationManager;

        public CalculatorApiRequestsHandler(
            IMapper mapper,
            ICalculatorOperationManager calculatorOperationManager
        )
        {
            this.mapper = mapper;
            this.calculatorOperationManager = calculatorOperationManager;
        }

        public CalculateApiResponse<CalculateResultDto> Handle(CalculateApiRequest request)
        {
            var dto = this.mapper.Map<CalculateDto>(request);
            var result = this.calculatorOperationManager.Calculate(dto);

            return new CalculateApiResponse<CalculateResultDto>(result);
        }
    }
}
