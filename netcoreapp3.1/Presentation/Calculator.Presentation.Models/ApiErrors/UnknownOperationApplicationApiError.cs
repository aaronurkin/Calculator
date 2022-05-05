namespace Calculator.Presentation.Models
{
    public class UnknownOperationApplicationApiError : ApplicationApiError
    {
        public UnknownOperationApplicationApiError(string errorMessage)
            : base(ApplicationApiErrorCode.UNKNOWN_OPERATION, errorMessage)
        {
        }
    }
}
