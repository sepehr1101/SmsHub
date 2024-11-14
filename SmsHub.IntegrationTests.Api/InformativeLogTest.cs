using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;

[assembly:CollectionBehavior(DisableTestParallelization =true)]
namespace SmsHub.IntegrationTests.Api
{
    public class InformativeLogTest:BaseIntegrationTest
    {
        public InformativeLogTest(TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateInformativeLog_InformativeLogDto_ShouldInformativeLog()
        {
            //Arrange
            var logLevel = new CreateLogLevelDto()
            {
                Id=1,
                Title="sample title",
                Css="sample Css"
            };
            var informativeLog = new CreateInformativeLogDto()
            {
                LogLevelId=1,
                Section="sample Section",
                Description="sample Description",
                UserId=Guid.NewGuid(),
                UserInfo="sample UserInfo",
                Ip="198.162.1.1",
                InsertDateTime=DateTime.Now,    
                ClientInfo="sample ClientInfo"
            };

            //Act
            await PostAsync<CreateLogLevelDto, CreateLogLevelDto>("/LogLevel/Create", logLevel);
            //Assert
            Assert.True(true);
            
            //Act
            await PostAsync<CreateInformativeLogDto, CreateInformativeLogDto>("/InformativeLog/Create", informativeLog);
            //Assert
            Assert.True(true);

        }
    }
}
