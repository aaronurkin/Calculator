namespace Calculator.Application.Models
{
    public class CalculateDto
    {
        public string Operation { get; set; }

        public string ResponseType { get; set; }

        public decimal LeftOperand { get; set; }

        public decimal RightOperand { get; set; }
    }
}
