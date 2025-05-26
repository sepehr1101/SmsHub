using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.BaseHttp.Client.Implementation;
using SmsHub.Infrastructure.BaseHttp.Interceptors.Contracts;
using SmsHub.Infrastructure.BaseHttp.Interceptors.Implementations;
using SmsHub.Persistence.Features.Logging.Raw;

namespace SmsHub.Infrastructure.Extensions
{
    public static class ConfigureServices
    {
        public static void AddInfrastructureInjections(this IServiceCollection services)
        {
            services.AddSingleton<SqlLogger>();
            services.AddScoped<IHttpInterceptor, SqlLoggingInterceptor>();
            services.AddTransient<IRestClient, RestClient>();
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
