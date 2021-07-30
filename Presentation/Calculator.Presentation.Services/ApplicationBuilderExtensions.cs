using Calculator.Presentation.Services.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Calculator.Presentation.Services
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseApplicationRequestContext(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ApplicationRequestContextMiddleware>();
        }
    }
}
