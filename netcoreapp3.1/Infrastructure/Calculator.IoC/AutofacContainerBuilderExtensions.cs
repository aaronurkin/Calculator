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
                .Named<ICalculatorOperationResultResolver>(ApplicationApiClient.ANGULAR_0_1_23);

            builder
                .RegisterType<CalculatorOperationResultResolver>()
                .Named<ICalculatorOperationResultResolver>(ApplicationApiClient.IOS_14_4_0_0_1);

            builder
                .RegisterType<CalculatorOperationResultResolver>()
                .Named<ICalculatorOperationResultResolver>(ApplicationApiClient.ANDROID_8_0_0_2);

            builder
                .RegisterType<AdditionCalculatorOperation>()
                .Named<ICalculatorOperation>(AdditionCalculatorOperation.NAME);

            builder
                .RegisterType<SubtractionCalculatorOperation>()
                .Named<ICalculatorOperation>(SubtractionCalculatorOperation.NAME);

            builder
                .RegisterType<MultiplicationCalculatorOperation>()
                .Named<ICalculatorOperation>(MultiplicationCalculatorOperation.NAME);

            builder
                .RegisterType<DivisionCalculatorOperation>()
                .Named<ICalculatorOperation>(DivisionCalculatorOperation.NAME);

            builder
                .RegisterType<ExponentiationCalculatorOperation>()
                .Named<ICalculatorOperation>(ExponentiationCalculatorOperation.NAME);

            return builder;
        }
    }
}
