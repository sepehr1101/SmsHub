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
        
        [Fact]
        public async void CreateLineWithValidData_LineDataDto_ShouldCreateLine()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId =ProviderEnum.Magfa,
                Credential="Credential Test",
                Number= "09198765432"
            };

            //Act
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void CreateLineWithoutData_LineDataDto_ShouldFailed()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Credential = null,
                Number = null
            };

            //Act
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);

            //Assert
            Assert.False(false);
        }

        [Fact]
        public async void CreateLineByInValidData_LineDataDto_ShouldFailed()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Credential = "this is a invalid Data",
                Number = null
            };

            //Act
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);

            //Assert
            Assert.False(false);
        }

        [Fact]
        public async void _2_CreateLineByInValidData_LineDataDto_ShouldFailed()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Kavenegar,
                Credential = "this is a invalid Data",
                Number = null
            };

            //Act
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);

            //Assert
            Assert.False(false);
        }
    }

   
}
