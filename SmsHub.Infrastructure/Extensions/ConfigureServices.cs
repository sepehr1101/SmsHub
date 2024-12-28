using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace SmsHub.Infrastructure.Extensions
{
    public static class ConfigureServices
    {
        public static void AddInfrastructureInjections(this IServiceCollection services)
        {
            services.AddHttpClient();

            services.Scan(scan =>
                          scan
                            .FromCallingAssembly()
                            .AddClasses(publicOnly: false)
                            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                            .AsMatchingInterface()
                            .WithScopedLifetime());
        }
    }
}
