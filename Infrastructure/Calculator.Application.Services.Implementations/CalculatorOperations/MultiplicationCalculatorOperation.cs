using Calculator.Application.Models;

namespace Calculator.Application.Services.Implementations
{
    public class MultiplicationCalculatorOperation : ICalculatorOperation
    {
        public const string NAME = "MULTIPLICATION";

        public OperationCalculateResult Calculate(OperationCalculateDto input)
        {
            if (input == null)
            {
                throw new System.ArgumentNullException($"{nameof(input)} of type {typeof(OperationCalculateDto).FullName}");
            }

            var value = input.LeftOperand * input.RightOperand;
            return new OperationCalculateResult { Value = value };
        }
    }
}
