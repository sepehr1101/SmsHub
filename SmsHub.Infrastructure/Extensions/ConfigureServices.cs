using Microsoft.Extensions.DependencyInjection;
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
            services.AddScoped<IRestClient, RestClient>();
            services.AddScoped<IKavenegarHttpDateService, KavenegarHttpDateService>();
            services.AddScoped<IKavenegarHttpSendSimpleService, KavenegarHttpSendSimpleService>();            
        }
    }
}
