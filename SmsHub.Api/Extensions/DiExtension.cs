using SmsHub.Application.Extensions;
using SmsHub.Common.Extensions;
using SmsHub.Infrastructure.Extensions;
using SmsHub.Persistence.Extensions;

namespace SmsHub.Api.Extensions
{
    public static class DiExtension
    {
        public static void AddDI(this IServiceCollection services)
        {
            // DI
            services.AddCommonInjections();
            services.AddInfrastructureInjections();
            services.AddPersistenceInjections();
            services.AddApplicationInjections();
        }
    }
}
