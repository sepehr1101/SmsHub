using Microsoft.Extensions.DependencyInjection;
using SmsHub.Common.Contrats;
using SmsHub.Common.Implementations;

namespace SmsHub.Common.Extensions
{
    public static class ConfigureServices
    {
        public static void AddCommonInjections(this IServiceCollection services)
        {
            services.AddScoped<ISecurityOperations, SecurityOperations>();
        }
    }
}
