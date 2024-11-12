using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;

namespace SmsHub.IntegrationTests.Api
{
    public class ProviderControllerTests : BaseIntegrationTest
    {
        public ProviderControllerTests(TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateProvider_ProviderDataDto_ShouldCreatProvider()
        {
            // Arrange
            var provider = new CreateProviderDto
            {
                BaseUri="http://baseurl",
                BatchSize=10,
                DefaultPreNumber="2000",
                FallbackBaseUri="https://fallbackurl",
                Title="title",
                Website="www.someProvider.ir"
            };

            // Act
            await PostAsync<CreateProviderDto, CreateProviderDto>("/Provider/Create", provider);

            // Assert 
            Assert.True(true);
        }

    }
}
