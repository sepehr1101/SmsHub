using Serilog;

namespace SmsHub.Api.Extensions
{
    public static class SerilogExtension
    {
        public static void AddSerilog(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSerilog(options =>
            {
                //we can configure serilog from configuration
                options.ReadFrom.Configuration(configuration);
            });

        }
    }
}
