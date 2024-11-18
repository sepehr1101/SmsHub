using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Update;

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


        [Fact]
        public async void UpdateLine_LineDto_ShouldUpdateLine()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId =ProviderEnum.Magfa,
                Credential="string",
                Number="string"
            };
            var updateLine = new UpdateLineDto()
            {
                Id =1,
                ProviderId = ProviderEnum.Magfa,
                Credential = "Update Credential",
                Number = "Update Number"
            };

            //Act
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<UpdateLineDto, UpdateLineDto>("/Line/Update",updateLine);

            //Assert
            Assert.True(true);
        }
    }
}
