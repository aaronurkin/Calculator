namespace Calculator.Presentation.Models
{
    public class CalculateApiRequest
    {
        public string Operation { get; set; }

        public decimal LeftOperand { get; set; }

        public decimal RightOperand { get; set; }
    }
}
