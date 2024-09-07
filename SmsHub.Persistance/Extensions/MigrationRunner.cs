using Microsoft.Extensions.DependencyInjection;
using FluentMigrator.Runner;
using System.Reflection;

namespace SmsHub.Persistence.Extensions
{
    public static class MigrationRunner
    {
        public static void UpdateDb(this IServiceCollection services, string connectionString)
        {
            using (var serviceProvider = CreateServices(services, connectionString))
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    UpdateDatabase(scope.ServiceProvider);
                }
            }
        }
        private static ServiceProvider CreateServices(IServiceCollection services, string connectionString)
        {
            var tmpConnectionString = "Data Source=.;Encrypt=False;Database=Test;Integrated Security=false;User ID=admin;Password=pspihp;";
            return services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(connectionString)
                    //.ScanIn(typeof(DbInitialDesign).Assembly).For.Migrations())
                    .ScanIn(Assembly.GetExecutingAssembly()).For.All())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}
