using Microsoft.Extensions.DependencyInjection;
using SmsHub.Application.Features.Security.Services.Contracts;
using SmsHub.Common.Contrats;

namespace SmsHub.Common.Extensions
{
    public static class ConfigureServices
    {
        public static void AddCommonInjections(this IServiceCollection services)
        {
            services.AddScoped<ISecurityOpertions, SecurityOperations>();
        }
    }
}
