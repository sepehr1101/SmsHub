using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class LogLevelControllerTest : BaseIntegrationTest
    {
        public LogLevelControllerTest(_TestEnvironmentWebApplicationFactory factory)
            : base(factory)
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
                Id = 1
            };

            //Act
            await PostAsync<CreateLogLevelDto, CreateLogLevelDto>("/LogLevel/Create", logLevel);
            await PostAsync<DeleteLogLevelDto, DeleteLogLevelDto>("/LogLevel/Delete", deleteLogLevel);

            //Asser
            Assert.True(true);

        }

        [Fact]
        public async void UpdateLogLevel_LogLevelDto_ShouldUpdateLogLevel()
        {
            //Arrange
            var logLevel = new CreateLogLevelDto()
            {
                Id = 1,
                Title = "sample title",
                Css = "sample Css"
            };
            var updateLogLevel = new UpdateLogLevelDto()
            {
                Id = 1,
                Title = "Update title",
                Css = "Update Css"
            };

            //Act
            await PostAsync<CreateLogLevelDto, CreateLogLevelDto>("/LogLevel/Create", logLevel);
            await PostAsync<UpdateLogLevelDto, UpdateLogLevelDto>("/LogLevel/Update", updateLogLevel);

            //Asser
            Assert.True(true);

        }


        [Fact]
        public async void GetSingleLogLevel_LogLevelDto_ShouldGetSingleLogLevel()
        {
            //Arrange
            var logLevel = new CreateLogLevelDto()
            {
                Id = 1,
                Title = "sample title",
                Css = "sample Css"
            };
            var logLevelId = new IntId()
            {
                Id = 1
            };

            //Act
            await PostAsync<CreateLogLevelDto, CreateLogLevelDto>("/LogLevel/Create", logLevel);
            var singleLogLevel = await PostAsync<IntId, ApiResponseEnvelope<GetLogLevelDto>>("/LogLevel/GetSingle", logLevelId);

            //Asser
            Assert.Equal(singleLogLevel.Data.Id, 1);
            Assert.Equal(singleLogLevel.HttpStatusCode, 200);

        }
        
        
        [Fact]
        public async void GetListLogLevel_LogLevelDto_ShouldGetListLogLevel()
        {
            //Arrange
            var logLevels = new List<CreateLogLevelDto>()
            {
                new CreateLogLevelDto(){Id = 1,Title = "sample1 title",Css = "sample1 Css"},
                new CreateLogLevelDto(){Id = 2,Title = "sample2 title",Css = "sample2 Css"},
                new CreateLogLevelDto(){Id = 3,Title = "sample3 title",Css = "sample3 Css"},
            };

            //Act
            foreach (var item in logLevels)
            {
                await PostAsync<CreateLogLevelDto, CreateLogLevelDto>("/LogLevel/Create", item);
            }
            var logLevelList = await PostAsync<GetLogLevelDto, ApiResponseEnvelope<ICollection<GetLogLevelDto>>>("/LogLevel/GetList", null);

            //Asser
            Assert.Equal(logLevelList.Data.Count, 3);
            Assert.Equal(logLevelList.HttpStatusCode, 200);

        }
    }
}
