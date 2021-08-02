using System.Net;

namespace Calculator.Presentation.Models
{
    public class ApiResponse
    {
        public ApiResponse(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; set; }
    }

    public class ApiResponse<TData> : ApiResponse
    {
        public ApiResponse(TData data)
            : this(HttpStatusCode.OK, data)
        {
        }

        public ApiResponse(HttpStatusCode statusCode)
            : this(statusCode, default(TData))
        {
        }

        public ApiResponse(HttpStatusCode statusCode, TData data)
            : base(statusCode)
        {
            Data = data;
        }

        public TData Data { get; set; }
    }
}
