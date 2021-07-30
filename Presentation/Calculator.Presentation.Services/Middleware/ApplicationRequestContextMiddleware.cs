using Calculator.Application.Services;
using Calculator.Presentation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
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
                httpContext.Response.StatusCode = 400;
                return Task.CompletedTask;
            }

            applicationRequestContextResolver.Resolve(new ApplicationRequestContextResolverOptions
            {
                UserUserAgentHeader = userAgentHeader
            });

            return this.next(httpContext);
        }
    }
}
