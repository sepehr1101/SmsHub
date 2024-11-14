using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class LineControllerTest:BaseIntegrationTest
    {
        public LineControllerTest(TestEnvironmentWebApplicationFactory factory)
            :base(factory)
        {
        }

        [Fact]
        public async void CreateLine_LineDataDto_ShouldCreateLine()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId =ProviderEnum.Magfa,
                Credential="string",
                Number="string"
            };

            //Act
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);

            //Assert
            Assert.True(true);
        }
    }
}
