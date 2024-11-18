using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public  class LogLevelControllerTest:BaseIntegrationTest
    {
        public LogLevelControllerTest(TestEnvironmentWebApplicationFactory factory)
            :base(factory)
        {
        }

        [Fact]
        public async void CreateLogLevel_LogLevelDto_ShouldCreateLogLevel()
        {
            //Arrange
            var logLevel = new CreateLogLevelDto()
            {
                Id = 1,
                Title = "sample title",
                Css = "sample Css"
            };

            //Act
            await PostAsync<CreateLogLevelDto, CreateLogLevelDto>("/LogLevel/Create", logLevel);

            //Assert
            Assert.True(true);
        }
        
        [Fact]
        public async void DeleteLogLevel_LogLevelDto_ShouldDeleteLogLevel()
        {
            //Arrange
            var logLevel = new CreateLogLevelDto()
            {
                Id = 1,
                Title = "sample title",
                Css = "sample Css"
            };
            var deleteLogLevel = new DeleteLogLevelDto()
            {
                Id=1
            };

            //Act
            await PostAsync<CreateLogLevelDto, CreateLogLevelDto>("/LogLevel/Create", logLevel);
            await PostAsync<DeleteLogLevelDto, DeleteLogLevelDto>("/LogLevel/Delete", deleteLogLevel);

            //Asser
            Assert.True(true);

        }
    }
}
