using AutoMapper;
using Calculator.Application.Models;
using Calculator.Presentation.Models;

namespace Calculator.Presentation.Services.Implementations.Mappers.AutomapperProfiles
{
    public class ResponseTypeValueResolver : IValueResolver<CalculateApiRequest, CalculateDto, string>
    {
        private readonly ApplicationRequestContext requestContext;

        public ResponseTypeValueResolver(ApplicationRequestContext requestContext)
        {
            this.requestContext = requestContext;
        }

        public string Resolve(CalculateApiRequest source, CalculateDto destination, string responseType, ResolutionContext context)
        {
            var platformVersion = string.IsNullOrEmpty(this.requestContext.PlatformVersion)
                ? string.Empty :
                $"_{this.requestContext.PlatformVersion}";

            return $"{this.requestContext.Platrofm}{platformVersion}_{this.requestContext.PlatformApplicationVersion}".ToUpperInvariant();
        }
    }
}
