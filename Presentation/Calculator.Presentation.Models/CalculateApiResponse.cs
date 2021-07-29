using System.Net;

namespace Calculator.Presentation.Models
{
    public class CalculateApiResponse<TData>
    {
        public CalculateApiResponse(TData data)
            : this(HttpStatusCode.OK, data)
        {
        }

        public CalculateApiResponse(HttpStatusCode statusCode, TData data)
        {
            StatusCode = statusCode;
            Data = data;
        }

        public TData Data { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
