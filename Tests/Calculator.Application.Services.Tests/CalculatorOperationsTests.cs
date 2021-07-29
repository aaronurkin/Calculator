using Calculator.Application.Models;
using Calculator.Application.Services.Implementations;
using System;
using Xunit;

namespace Calculator.Application.Services.Tests
{
    public class CalculatorOperationsTests
    {
        [Theory]
        [InlineData(1,2,3)]
        [InlineData(3,2,5)]
        [InlineData(7,3,10)]
        [InlineData(6,3,9)]
        public void CalculateAdditionCalculatorOperationTests(decimal leftOperand, decimal rightOperand, decimal expected)
        {
            var addition = new AdditionCalculatorOperation();
            var model = new OperationCalculateDto
            {
                LeftOperand = leftOperand,
                RightOperand = rightOperand
            };
            var actual = addition.Calculate(model);

            Assert.Equal(expected, actual.Value);
        }

        [Theory]
        [InlineData(3,2,1)]
        [InlineData(5,3,2)]
        [InlineData(10,7,3)]
        [InlineData(9,3,6)]
        public void CalculateSubtractionCalculatorOperationTests(decimal leftOperand, decimal rightOperand, decimal expected)
        {
            var subtraction = new SubtractionCalculatorOperation();
            var model = new OperationCalculateDto
            {
                LeftOperand = leftOperand,
                RightOperand = rightOperand
            };
            var actual = subtraction.Calculate(model);

            Assert.Equal(expected, actual.Value);
        }

        [Theory]
        [InlineData(1,2,2)]
        [InlineData(2,3,6)]
        [InlineData(7,10,70)]
        [InlineData(6,3,18)]
        public void CalculateMultiplicationCalculatorOperationTests(decimal leftOperand, decimal rightOperand, decimal expected)
        {
            var multiplication = new MultiplicationCalculatorOperation();
            var model = new OperationCalculateDto
            {
                LeftOperand = leftOperand,
                RightOperand = rightOperand
            };
            var actual = multiplication.Calculate(model);

            Assert.Equal(expected, actual.Value);
        }

        [Fact]
        public void Calculate_GetRightOperandEqualToZero_ThrowsArgumentException()
        {
            var division = new DivisionCalculatorOperation();
            var input = new OperationCalculateDto
            {
                LeftOperand = 10,
                RightOperand = 0
            };

            Action calculation = () => division.Calculate(input);
            ArgumentException exception = Assert.Throws<ArgumentException>(calculation);

            Assert.Equal($"{nameof(input)} of type {typeof(OperationCalculateDto).FullName}", exception.ParamName);
            Assert.Equal($"Right operand must not equal to 0 (Parameter '{nameof(input)} of type {typeof(OperationCalculateDto).FullName}')", exception.Message);
        }

        [Theory]
        [InlineData(70,10,7)]
        [InlineData(18,3,6)]
        [InlineData(10,2,5)]
        [InlineData(6,3,2)]
        public void CalculateDivisionCalculatorOperationTests(decimal leftOperand, decimal rightOperand, decimal expected)
        {
            var division = new DivisionCalculatorOperation();
            var model = new OperationCalculateDto
            {
                LeftOperand = leftOperand,
                RightOperand = rightOperand
            };
            var actual = division.Calculate(model);

            Assert.Equal(expected, actual.Value);
        }
    }
}
