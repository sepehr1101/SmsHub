using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.BaseHttp.Client.Implementation;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Implementations;

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
