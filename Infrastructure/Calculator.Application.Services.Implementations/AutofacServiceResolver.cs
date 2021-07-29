using Autofac;

namespace Calculator.Application.Services.Implementations
{
    public class AutofacServiceResolver : IServiceResolver
    {
        private readonly ILifetimeScope lifetimeScope;

        public AutofacServiceResolver(ILifetimeScope lifetimeScope)
        {
            this.lifetimeScope = lifetimeScope;
        }

        public TService Resolve<TService>()
        {
            return this.lifetimeScope.Resolve<TService>();
        }

        public TService ResolveKeyed<TService>(object key)
        {
            return this.lifetimeScope.ResolveKeyed<TService>(key);
        }

        public TService ResolveNamed<TService>(string name)
        {
            return this.lifetimeScope.ResolveNamed<TService>(name);
        }
    }
}
