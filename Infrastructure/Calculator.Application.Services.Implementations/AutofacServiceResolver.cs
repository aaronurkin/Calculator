using Autofac;
using Microsoft.Extensions.Logging;

namespace Calculator.Application.Services.Implementations
{
    public class AutofacServiceResolver : IServiceResolver
    {
        private readonly ILifetimeScope lifetimeScope;
        private readonly ILogger<AutofacServiceResolver> logger;

        public AutofacServiceResolver(
            ILifetimeScope lifetimeScope,
            ILogger<AutofacServiceResolver> logger
        )
        {
            this.logger = logger;
            this.lifetimeScope = lifetimeScope;
        }

        public TService Resolve<TService>()
        {
            try
            {
                return this.lifetimeScope.Resolve<TService>();
            }
            catch (System.Exception exception)
            {
                this.logger.LogError(exception, "FAILED resolving {0}", typeof(TService).FullName);
                return default(TService);
            }
        }

        public TService ResolveKeyed<TService>(object key)
        {
            try
            {
                return this.lifetimeScope.ResolveKeyed<TService>(key);
            }
            catch (System.Exception exception)
            {
                this.logger.LogError(exception, "FAILED resolving keyed {0}", typeof(TService).FullName);
                return default(TService);
            }
        }

        public TService ResolveNamed<TService>(string name)
        {
            try
            {
                return this.lifetimeScope.ResolveNamed<TService>(name);
            }
            catch (System.Exception exception)
            {
                this.logger.LogError(exception, "FAILED resolving named {0}", typeof(TService).FullName);
                return default(TService);
            }
        }
    }
}
