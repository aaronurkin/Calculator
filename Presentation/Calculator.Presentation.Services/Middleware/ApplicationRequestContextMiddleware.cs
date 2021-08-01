using Calculator.Application.Services;
using Calculator.Presentation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Calculator.Presentation.Services.Middleware
{
    public class ApplicationRequestContextMiddleware
    {
        private readonly RequestDelegate next;

        public ApplicationRequestContextMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext httpContext, IServiceResolver serviceResolver)
        {
            var userAgentHeader = $"{httpContext.Request.Headers[HeaderNames.UserAgent]}".Split('/');
            var applicationRequestContextResolver = serviceResolver
                .ResolveKeyed<IApplicationRequestContextResolver>(userAgentHeader.Length);

            if (applicationRequestContextResolver == null)
            {
                var responseContent = JsonConvert.SerializeObject(new UnknownClientCalculateApiResponse());

                httpContext.Response.StatusCode = 400;
                httpContext.Response.ContentType = $"{System.Net.Mime.MediaTypeNames.Application.Json}; charset=utf-8";

                return httpContext.Response.WriteAsync(responseContent);
            }

            applicationRequestContextResolver.Resolve(new ApplicationRequestContextResolverOptions
            {
                UserUserAgentHeader = userAgentHeader
            });

            return this.next(httpContext);
        }
    }
}
