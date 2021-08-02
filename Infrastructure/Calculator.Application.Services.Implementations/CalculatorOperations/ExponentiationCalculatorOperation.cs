using Calculator.Application.Models;

namespace Calculator.Application.Services.Implementations
{
    public class ExponentiationCalculatorOperation : ICalculatorOperation
    {
        public OperationCalculateResult Calculate(OperationCalculateDto input)
        {
            if (input == null)
            {
                throw new System.ArgumentNullException($"{nameof(input)} of type {typeof(OperationCalculateDto).FullName}");
            }

            var value = System.Math.Pow(input.LeftOperand, input.RightOperand);
            return new OperationCalculateResult { Value = value };
        }
    }
}
