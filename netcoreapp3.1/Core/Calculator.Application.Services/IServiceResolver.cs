namespace Calculator.Application.Services
{
    public interface IServiceResolver
    {
        TService Resolve<TService>();
        TService ResolveKeyed<TService>(object key);
        TService ResolveNamed<TService>(string name);
    }
}
