using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using SmsHub.Application.Common.Services.Contracts;
using SmsHub.Application.Common.Services.Implementations;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Consumer.Handlers.Commands.Create.Implementations;
using SmsHub.Application.Features.Security.Handlers.Queries.Contracts;
using SmsHub.Application.Features.Security.Handlers.Queries.Implementations;
using System.Reflection;

namespace SmsHub.Application.Extensions
{
    public static class ConfigureServices
    {
        public static void AddApplicationInjections(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddScoped<IApiKeyFactory, ApiKeyFactory>();
            //services.AddScoped<ICreateConsumerCommandHandler, CreateConsumerCommandHandler>();
            //services.AddScoped<IApiKeyValidationHandler, ApiKeyValidationHandler>();
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.Scan(scan =>
                          scan
                            .FromCallingAssembly()
                            .AddClasses(publicOnly: false)
                            .UsingRegistrationStrategy(RegistrationStrategy.Throw)
                            .AsMatchingInterface()
                            .WithScopedLifetime());

            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            //services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            //services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        }
    }
}
