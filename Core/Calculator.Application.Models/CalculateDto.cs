namespace Calculator.Application.Models
{
    public class CalculateDto
    {
        public string ResponseType { get; set; }

        public string OperationType { get; set; }

        public decimal LeftOperand { get; set; }

        public decimal RightOperand { get; set; }
    }
}
