namespace Calculator.Presentation.Models
{
    public class UnknownClientCalculateApiResponse : CalculateApiResponse<string>
    {
        public UnknownClientCalculateApiResponse()
            : base(System.Net.HttpStatusCode.BadRequest, "Unknown client")
        {
        }
    }
}
