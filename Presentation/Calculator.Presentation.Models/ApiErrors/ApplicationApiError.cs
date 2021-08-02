namespace Calculator.Presentation.Models
{

    public class ApplicationApiError
    {
        public ApplicationApiError(string errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public string ErrorCode { get; }

        public string ErrorMessage { get; }
    }
}
