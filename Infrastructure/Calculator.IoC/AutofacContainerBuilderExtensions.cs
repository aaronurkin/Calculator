using Autofac;
using Calculator.Application.Services;
using Calculator.Application.Services.Implementations;
using Calculator.Presentation.Models;
using Calculator.Presentation.Services;
using Calculator.Presentation.Services.Implementations;
using Microsoft.Extensions.Configuration;

namespace Calculator.IoC
{
    public static class AutofacContainerBuilderExtensions
    {
        public static ContainerBuilder AddApplication(this ContainerBuilder builder, IConfiguration configuration)
        {
            builder
                .RegisterType<ApplicationRequestContext>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<AutofacServiceResolver>()
                .As<IServiceResolver>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<CalculatorApiRequestsHandler>()
                .As<ICalculatorApiRequestsHandler>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<TwoSegmentsUserAgentApplicationRequestContextResolver>()
                .Keyed<IApplicationRequestContextResolver>(2);

            builder
                .RegisterType<ThreeSegmentsUserAgentApplicationRequestContextResolver>()
                .Keyed<IApplicationRequestContextResolver>(3);

            builder
                .RegisterType<CalculatorOperationResultResolver>()
                .Named<ICalculatorOperationResultResolver>("ANGULAR_0.1.23");

            builder
                .RegisterType<CalculatorOperationResultResolver>()
                .Named<ICalculatorOperationResultResolver>("IOS_14.4_0.0.1");

            builder
                .RegisterType<CalculatorOperationResultResolver>()
                .Named<ICalculatorOperationResultResolver>("ANDROID_8_0.0.2");

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

            builder
                .RegisterType<ExponentiationCalculatorOperation>()
                .Named<ICalculatorOperation>("EXPONENTIATION");

            return builder;
        }
    }
}
