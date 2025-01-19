using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Api.Extensions
{
    public static class ConfigureOptions
    {
        public static void AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
            AddBearerTokens(services, configuration);
            AddApiSettings(services, configuration);
        }
        private static void AddBearerTokens(IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<BearerTokenOptions>()
                .Bind(configuration.GetSection("BearerTokens"))
                .Validate(bearerTokens =>
                {
                    return bearerTokens.AccessTokenExpirationMinutes < bearerTokens.RefreshTokenExpirationMinutes;
                }, MessageResources.RefreshTokenIsLessThanToken);
        }
        private static void AddApiSettings(IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<ApiSettings>().Bind(configuration.GetSection("ApiSettings"));
        }
    }
}
