using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using SmsHub.Persistence.Contexts.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testcontainers.MsSql;

namespace SmsHub.IntegrationTests.Api
{
    public class TestEnvironmentWebApplicationFactory
        : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly MsSqlContainer _container = new MsSqlBuilder()
                .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
                .WithPassword("Strongest_password_2024!")
                .Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                var dbContextServiceDescriptor = services.SingleOrDefault(s =>
                        s.ServiceType == typeof(DbContextOptions<TestContext>));

                if (dbContextServiceDescriptor is not null)
                {
                    // Remove the actual dbcontext registration.
                    services.Remove(dbContextServiceDescriptor);
                }

                // Register dbcontext with container connection string
                services.AddDbContext<TestContext>(options =>
                {
                    string containerConnectionString = _container.GetConnectionString();
                    options.UseSqlServer(containerConnectionString);
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
