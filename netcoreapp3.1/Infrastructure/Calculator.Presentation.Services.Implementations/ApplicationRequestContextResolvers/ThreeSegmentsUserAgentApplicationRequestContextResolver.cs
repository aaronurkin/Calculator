using Calculator.Presentation.Models;
using System.Threading.Tasks;

namespace Calculator.Presentation.Services.Implementations
{
    public class ThreeSegmentsUserAgentApplicationRequestContextResolver : IApplicationRequestContextResolver
    {
        private readonly ApplicationRequestContext requestContext;

        public ThreeSegmentsUserAgentApplicationRequestContextResolver(ApplicationRequestContext requestContext)
        {
            this.requestContext = requestContext;
        }

        public Task Resolve(ApplicationRequestContextResolverOptions options)
        {
            this.requestContext.Platrofm = options.UserUserAgentHeader[1];
            this.requestContext.PlatformVersion = options.UserUserAgentHeader[0];
            this.requestContext.PlatformApplicationVersion = options.UserUserAgentHeader[2];

            return Task.CompletedTask;
        }
    }
}
