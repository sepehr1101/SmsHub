using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmsHub.Persistence.Contexts.Implementation;
using SmsHub.Persistence.Extensions;
using Testcontainers.MsSql;

namespace SmsHub.IntegrationTests.Api
{
    public class TestEnvironmentWebApplicationFactory
        : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private static int runSqlInPort = 33911, sqlDefaultPort = 1433;
        private readonly MsSqlContainer _container = new MsSqlBuilder()
                .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
                .WithPassword("Strongest_password_2024!")
                .WithName($"DockerTestSmsHub{Guid.NewGuid()}")
                .WithPortBinding(runSqlInPort, sqlDefaultPort)
                .Build();
        
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                var dbContextServiceDescriptor = services.SingleOrDefault(s =>
                        s.ServiceType == typeof(DbContextOptions<SmsHubContext>));

                if (dbContextServiceDescriptor is not null)
                {
                    // Remove the actual dbcontext registration.
                    services.Remove(dbContextServiceDescriptor);
                }

                // Register dbcontext with container connection string
                services.AddDbContext<SmsHubContext>(options =>
                {
                    var connectionString = MigrationRunner.GetConnectionInfo().Item1;
                    //string connectionString = _container.GetConnectionString();                   
                    options.UseSqlServer(connectionString);
                });
            });
        }

        public async Task InitializeAsync()
        {
            await _container.StartAsync();
        }

        async Task IAsyncLifetime.DisposeAsync()
        {
            await _container.StopAsync();
        }
    }
}
