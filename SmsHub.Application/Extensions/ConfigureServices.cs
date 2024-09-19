using Microsoft.Extensions.DependencyInjection;
using SmsHub.Application.Features.Security.Services.Contracts;
using SmsHub.Application.Features.Security.Services.Implementations;
using System.Reflection;

namespace SmsHub.Application.Extensions
{
    public static class ConfigureServices
    {
        public static void AddApplicationInjections(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IApiKeyFactory, ApiKeyFactory>();
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            //services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            //services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        }
    }
}
