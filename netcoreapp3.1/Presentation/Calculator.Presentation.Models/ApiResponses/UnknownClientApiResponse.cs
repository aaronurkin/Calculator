namespace Calculator.Presentation.Models
{
    public class UnknownClientApiResponse : ApiResponse<ApplicationApiError>
    {
        public UnknownClientApiResponse(string errorMessage)
            : this(new UnknownClientApplicationApiError(errorMessage))
        {
        }

        public UnknownClientApiResponse(UnknownClientApplicationApiError error)
            : base(System.Net.HttpStatusCode.BadRequest, error)
        {
        }
    }
}
