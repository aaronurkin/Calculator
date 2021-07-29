using Calculator.Application.Models;

namespace Calculator.Application.Services.Implementations
{
    public class CalculatorOperationManager : ICalculatorOperationManager
    {
        private readonly IServiceResolver serviceResolver;

        public CalculatorOperationManager(IServiceResolver serviceResolver)
        {
            this.serviceResolver = serviceResolver;
        }

        public CalculateResultDto Calculate(CalculateDto data)
        {
            var operation = this.serviceResolver.ResolveNamed<ICalculatorOperation>(data.OperationType);
            var resultResolver = this.serviceResolver.ResolveNamed<ICalculatorOperationResultResolver>(data.ResponseType);
            // TODO: Map using Automapper
            var operationResult = operation.Calculate(new OperationCalculateDto { LeftOperand = data.LeftOperand, RightOperand = data.RightOperand });
            var result = resultResolver.Resolve(operationResult);

            return result;
        }
    }
}
