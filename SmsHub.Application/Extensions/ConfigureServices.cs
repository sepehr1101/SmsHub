using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using SmsHub.Application.Features.Sending.Factories;
using SmsHub.Application.Features.Sending.Services.Implementations;
using System.Reflection;

namespace SmsHub.Application.Extensions
{
    public static class ConfigureServices
    {
        public static void AddApplicationInjections(this IServiceCollection services)
        {
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddScoped<ISmsProvider, MagfaProvider>();
            //services.AddScoped<ISmsProvider, KavenegarProvider>();
            
            services.AddScoped<KavenegarProvider>();
            services.AddScoped<MagfaProvider>();
            services.AddSingleton<ISmsProviderFactory, SmsProviderFactory>();


            services.Scan(scan =>
                          scan
                            .FromCallingAssembly()
                            .AddClasses(publicOnly: false)
                            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                            .AsImplementedInterfaces()
                            .WithScopedLifetime());
        }
    }
}
