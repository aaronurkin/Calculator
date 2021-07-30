using System.Net;

namespace Calculator.Presentation.Models
{
    public class CalculateApiResponse
    {
        public CalculateApiResponse(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; set; }
    }

    public class CalculateApiResponse<TData> : CalculateApiResponse
    {
        public CalculateApiResponse(TData data)
            : this(HttpStatusCode.OK, data)
        {
        }

        public CalculateApiResponse(HttpStatusCode statusCode)
            : this(statusCode, default(TData))
        {
        }

        public CalculateApiResponse(HttpStatusCode statusCode, TData data)
            : base(statusCode)
        {
            Data = data;
        }

        public TData Data { get; set; }
    }
}
