using Calculator.Presentation.Models;
using System.Threading.Tasks;

namespace Calculator.Presentation.Services
{
    public interface IApplicationRequestContextResolver
    {
        Task Resolve(ApplicationRequestContextResolverOptions options);
    }
}
