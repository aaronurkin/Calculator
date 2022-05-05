namespace Calculator.Presentation.Models
{
    public class UnknownOperationApiResponse : ApiResponse<ApplicationApiError>
    {
        public UnknownOperationApiResponse(string errorMessage)
            : this(new UnknownOperationApplicationApiError(errorMessage))
        {
        }

        public UnknownOperationApiResponse(UnknownOperationApplicationApiError error)
            : base(System.Net.HttpStatusCode.BadRequest, error)
        {
        }
    }
}
