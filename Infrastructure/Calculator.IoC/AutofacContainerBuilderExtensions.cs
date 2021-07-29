using Autofac;
using Microsoft.Extensions.Configuration;

namespace Calculator.IoC
{
    public static class AutofacContainerBuilderExtensions
    {
        public static ContainerBuilder AddApplication(this ContainerBuilder builder, IConfiguration configuration)
        {
            return builder;
        }
    }
}
