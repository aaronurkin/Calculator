using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Calculator.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMapping(this IServiceCollection services, System.Type type)
        {
            var assemblies = new List<Assembly>();

            var pattern = type.Assembly.FullName
                .Substring(0, type.Assembly.FullName.IndexOf('.', System.StringComparison.Ordinal));

            foreach (var item in type.Assembly.GetReferencedAssemblies())
            {
                if (item.FullName.StartsWith(pattern))
                {
                    assemblies.AddRange(
                        Assembly
                            .Load(item.FullName)
                            .GetReferencedAssemblies()
                            .Select(assembly => Assembly.Load(assembly.FullName))
                    );
                }
            }

            services.AddAutoMapper(assemblies);

            return services;
        }
    }
}
