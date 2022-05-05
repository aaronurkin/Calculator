namespace Calculator.Presentation.Models
{
    public class CalculateApiRequest
    {
        public string Operation { get; set; }

        public double LeftOperand { get; set; }

        public double RightOperand { get; set; }
    }
}
