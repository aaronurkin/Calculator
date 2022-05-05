namespace Calculator.Presentation.Models
{
    public class UnknownClientApplicationApiError : ApplicationApiError
    {
        public UnknownClientApplicationApiError(string errorMessage)
            : base(ApplicationApiErrorCode.UNKNOWN_CLIENT, errorMessage)
        {
        }
    }
}
