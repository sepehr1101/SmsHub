using Microsoft.Extensions.DependencyInjection;
using SmsHub.Persistence.Contexts.Implementation;

namespace SmsHub.UnitTests.Application
{
    public class TestEnvironmentFixture : IDisposable
    {
        public _TestEnvironmentWebApplicationFactory Factory { get; }
        public SmsHubContext DbContext { get; }

        public TestEnvironmentFixture()
        {
            Factory = new _TestEnvironmentWebApplicationFactory();

            using var scope = Factory.Services.CreateScope();
            DbContext = scope.ServiceProvider.GetRequiredService<SmsHubContext>();
        }

        public void Dispose()
        {
            Factory.Dispose();
        }
    }
}
