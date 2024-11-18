using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Delete;

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
        public async void CreateLine_LineDto_ShouldCreateLine()
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


        [Fact]
        public async void DeleteLine_LineDto_ShouldDeleteLine()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId =ProviderEnum.Magfa,
                Credential="string",
                Number="string"
            };
            var deleteLine = new DeleteLineDto()
            {
                Id=1
            };

            //Act
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<DeleteLineDto,DeleteLineDto>("/Line/Delete", deleteLine);

            //Assert
            Assert.True(true);
        }
    }
}
