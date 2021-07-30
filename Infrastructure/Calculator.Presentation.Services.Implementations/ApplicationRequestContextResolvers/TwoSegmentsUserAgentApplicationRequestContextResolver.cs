using Calculator.Presentation.Models;
using System.Threading.Tasks;

namespace Calculator.Presentation.Services.Implementations
{
    public class TwoSegmentsUserAgentApplicationRequestContextResolver : IApplicationRequestContextResolver
    {
        private readonly ApplicationRequestContext requestContext;

        public TwoSegmentsUserAgentApplicationRequestContextResolver(ApplicationRequestContext requestContext)
        {
            this.requestContext = requestContext;
        }

        public Task Resolve(ApplicationRequestContextResolverOptions options)
        {
            this.requestContext.Platrofm = options.UserUserAgentHeader[0];
            this.requestContext.PlatformApplicationVersion = options.UserUserAgentHeader[1];

            return Task.CompletedTask;
        }
    }
}
