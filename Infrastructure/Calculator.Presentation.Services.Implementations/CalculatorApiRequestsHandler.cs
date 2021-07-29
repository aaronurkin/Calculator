using Calculator.Application.Models;
using Calculator.Application.Services;
using Calculator.Presentation.Models;
using System;
using System.Net;

namespace Calculator.Presentation.Services.Implementations
{
    public class CalculatorApiRequestsHandler : ICalculatorApiRequestsHandler
    {
        private readonly ICalculatorOperationManager calculatorOperationManager;

        public CalculatorApiRequestsHandler(
            ICalculatorOperationManager calculatorOperationManager
        )
        {
            this.calculatorOperationManager = calculatorOperationManager;
        }

        public CalculateApiResponse<CalculateResultDto> Handle(CalculateApiRequest request)
        {
            // TODO: Map using Automapper
            var dto = new CalculateDto
            {
                OperationType = request.Operation,
                LeftOperand = request.LeftOperand,
                RightOperand = request.RightOperand,
                ResponseType = request.ResponseType ?? "COMMON"
            };
            var result = this.calculatorOperationManager.Calculate(dto);
            return new CalculateApiResponse<CalculateResultDto>(result);
        }
    }
}
