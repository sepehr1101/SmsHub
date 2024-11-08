using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;

namespace SmsHub.IntegrationTests.Api
{
    public class CompaniesControllerTests : BaseIntegrationTest
    {
        public CompaniesControllerTests(TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        //[Fact]
        //public async void GetCompanies_WhenCalled_ShouldReturnAllCompanies()
        //{
        //    // Act
        //    // This request retrieves the companies created during migration.
        //    var companies = await GetAsync<List<Provider>>("/api/Companies");

        //    // Assert
        //    Assert.True(true);
        //}

        [Fact]
        public async void CreateCompany_GivenCompanyData_ShouldCreateCompany()
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
            await PostAsync<CreateProviderDto, int>("/Provider/Create", provider);
        }

    }
}
