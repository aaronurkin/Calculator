namespace Calculator.Presentation.Models
{
    public class UnknownClientApiResponse : ApiResponse<string>
    {
        public UnknownClientApiResponse()
            : base(System.Net.HttpStatusCode.BadRequest, "Unknown client")
        {
        }
    }
}
