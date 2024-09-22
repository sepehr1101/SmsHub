using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace SmsHub.Persistence.Extensions
{
    public static class ConfigureServices
    {
        public static void AddPersistenceInjections(this IServiceCollection services)
        {            
            services.Scan(scan =>
                          scan
                            .FromCallingAssembly()
                            .AddClasses(publicOnly: false)
                            .UsingRegistrationStrategy(RegistrationStrategy.Throw)
                            .AsImplementedInterfaces()
                            .WithScopedLifetime());
        }
    }
}
