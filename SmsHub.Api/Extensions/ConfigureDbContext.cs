using Microsoft.EntityFrameworkCore;
using SmsHub.Persistence.Contexts.Implementation;
using SmsHub.Persistence.Extensions;

namespace SmsHub.Api.Extensions
{
    public static class ConfigureDbContext
    {
        public static void AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = MigrationRunner.GetConnectionInfo().Item1;
            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SmsHubContext>((sp, options) =>
            {
                options.UseSqlServer(connectionString,
                        serverDbContextOptionsBuilder =>
                        {
                            var minutes = (int)TimeSpan.FromMinutes(3).TotalSeconds;
                            serverDbContextOptionsBuilder.CommandTimeout(minutes);
                            //serverDbContextOptionsBuilder.EnableRetryOnFailure();
                        });
                //options.AddInterceptors(new PersianYeKeCommandInterceptor());
                //options.AddInterceptors(new RowLevelAuthenticitySaveChangeInterceptor());
            });
        }
    }
}
