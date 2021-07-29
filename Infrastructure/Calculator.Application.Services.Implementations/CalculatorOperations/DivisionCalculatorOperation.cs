using Calculator.Application.Models;

namespace Calculator.Application.Services.Implementations
{
    public class DivisionCalculatorOperation : ICalculatorOperation
    {
        public OperationCalculateResult Calculate(OperationCalculateDto input)
        {
            if (input == null)
            {
                throw new System.ArgumentNullException($"{nameof(input)} of type {typeof(OperationCalculateDto).FullName}");
            }

            if (input.RightOperand == 0)
            {
                throw new System.ArgumentException("Right operand must not equal to 0", $"{nameof(input)} of type {typeof(OperationCalculateDto).FullName}");
            }

            var value = input.LeftOperand / input.RightOperand;
            return new OperationCalculateResult { Value = value };
        }
    }
}
