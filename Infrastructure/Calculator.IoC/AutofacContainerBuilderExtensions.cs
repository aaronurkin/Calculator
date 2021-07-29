using Autofac;
using Calculator.Application.Services;
using Calculator.Application.Services.Implementations;
using Microsoft.Extensions.Configuration;

namespace Calculator.IoC
{
    public static class AutofacContainerBuilderExtensions
    {
        public static ContainerBuilder AddApplication(this ContainerBuilder builder, IConfiguration configuration)
        {
            builder
                .RegisterType<AutofacServiceResolver>()
                .As<IServiceResolver>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<CalculatorOperationResultResolver>()
                .As<ICalculatorOperationResultResolver>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<CalculatorOperationManager>()
                .As<ICalculatorOperationManager>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<AdditionCalculatorOperation>()
                .Named<ICalculatorOperation>("ADDITION");

            builder
                .RegisterType<SubtractionCalculatorOperation>()
                .Named<ICalculatorOperation>("SUBTRACTION");

            builder
                .RegisterType<MultiplicationCalculatorOperation>()
                .Named<ICalculatorOperation>("MULTIPLICATION");

            builder
                .RegisterType<DivisionCalculatorOperation>()
                .Named<ICalculatorOperation>("DIVISION");

            return builder;
        }
    }
}
