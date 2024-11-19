using Microsoft.AspNetCore.Mvc.ApiExplorer;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;

//[assembly:CollectionBehavior(DisableTestParallelization =true)]
namespace SmsHub.IntegrationTests.Api
{
    public class InformativeLogControllerTest : BaseIntegrationTest
    {
        public InformativeLogControllerTest(TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateInformativeLog_InformativeLogDto_ShouldCreateInformativeLog()
        {
            //Arrange
            var logLevel = new CreateLogLevelDto()
            {
                Id = 1,
                Title = "sample title",
                Css = "sample Css"
            };
            var informativeLog = new CreateInformativeLogDto()
            {
                LogLevelId = 1,
                Section = "sample Section",
                Description = "sample Description",
                UserId = Guid.NewGuid(),
                UserInfo = "sample UserInfo",
                Ip = "198.162.1.1",
                InsertDateTime = DateTime.Now,
                ClientInfo = "sample ClientInfo"
            };

            //Act
            await PostAsync<CreateLogLevelDto, CreateLogLevelDto>("/LogLevel/Create", logLevel);
            await PostAsync<CreateInformativeLogDto, CreateInformativeLogDto>("/InformativeLog/Create", informativeLog);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void DeleteInformativeLog_InformativeLogDto_ShouldDeleteInformativeLog()
        {
            //Arrange
            var logLevel = new CreateLogLevelDto()
            {
                Id = 1,
                Title = "sample title",
                Css = "sample Css"
            };
            var informativeLog = new CreateInformativeLogDto()
            {
                LogLevelId = 1,
                Section = "sample Section",
                Description = "sample Description",
                UserId = Guid.NewGuid(),
                UserInfo = "sample UserInfo",
                Ip = "198.162.1.1",
                InsertDateTime = DateTime.Now,
                ClientInfo = "sample ClientInfo"
            };
            var deleteInformativeLog = new DeleteInformativeLogDto()
            {
                Id = 1
            };

            //Act
            await PostAsync<CreateLogLevelDto, CreateLogLevelDto>("/LogLevel/Create", logLevel);
            await PostAsync<CreateInformativeLogDto, CreateInformativeLogDto>("/InformativeLog/Create", informativeLog);

            await PostAsync<DeleteInformativeLogDto, DeleteInformativeLogDto>("/InformativeLog/Delete", deleteInformativeLog);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void UpdateInformativeLog_InformativeLogDto_ShouldUpdateInformativeLog()
        {
            //Arrange
            var logLevel = new CreateLogLevelDto()
            {
                Id = 1,
                Title = "sample title",
                Css = "sample Css"
            };
            var informativeLog = new CreateInformativeLogDto()
            {
                LogLevelId = 1,
                Section = "sample Section",
                Description = "sample Description",
                UserId = Guid.NewGuid(),
                UserInfo = "sample UserInfo",
                Ip = "198.162.1.1",
                InsertDateTime = DateTime.Now,
                ClientInfo = "sample ClientInfo"
            };
            var updateInformativeLog = new UpdateInformativeLogDto()
            {
                Id = 1,
                LogLevelId = 1,
                Section = "Update Section",
                Description = "Update Description",
                UserId = Guid.NewGuid(),
                UserInfo = "Update UserInfo",
                Ip = "198.162.1.2",
                InsertDateTime = DateTime.Now,
                ClientInfo = "Update ClientInfo"
            };

            //Act
            await PostAsync<CreateLogLevelDto, CreateLogLevelDto>("/LogLevel/Create", logLevel);
            await PostAsync<CreateInformativeLogDto, CreateInformativeLogDto>("/InformativeLog/Create", informativeLog);

            await PostAsync<UpdateInformativeLogDto, UpdateInformativeLogDto>("/InformativeLog/Update", updateInformativeLog);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void GetSingleInformativeLog_InformativeLogDto_ShouldGetSingleInformativeLog()
        {
            //Arrange
            var logLevel = new CreateLogLevelDto()
            {
                Id = 1,
                Title = "sample title",
                Css = "sample Css"
            };
            var informativeLog = new CreateInformativeLogDto()
            {
                LogLevelId = 1,
                Section = "sample Section",
                Description = "sample Description",
                UserId = Guid.NewGuid(),
                UserInfo = "sample UserInfo",
                Ip = "198.162.1.1",
                InsertDateTime = DateTime.Now,
                ClientInfo = "sample ClientInfo"
            };
            var informativeLogId = new IntId()
            {
                Id = 1
            };

            //Act
            await PostAsync<CreateLogLevelDto, CreateLogLevelDto>("/LogLevel/Create", logLevel);
            await PostAsync<CreateInformativeLogDto, CreateInformativeLogDto>("/InformativeLog/Create", informativeLog);

            var singleInformativeLog = await PostAsync<IntId, ApiResponseEnvelope<GetInforamtaiveLogDto>>("/InformativeLog/GetSingle", informativeLogId);

            //Assert
            Assert.Equal(singleInformativeLog.Data.Id, 1);
            Assert.Equal(singleInformativeLog.HttpStatusCode, 200);
        }


        [Fact]
        public async void GetListInformativeLog_InformativeLogDto_ShouldGetListInformativeLog()
        {
            //Arrange
            var logLevels = new List<CreateLogLevelDto>()
            {
                new CreateLogLevelDto(){ Id = 1,Title = "sample1 title",Css = "sample1 Css"},
                new CreateLogLevelDto(){ Id = 2,Title = "sample2 title",Css = "sample2 Css"},
                new CreateLogLevelDto(){ Id = 3,Title = "sample3 title",Css = "sample3 Css"},
            };
            var informativeLogs = new List<CreateInformativeLogDto>()
            {
                new CreateInformativeLogDto(){LogLevelId = 1,Section = "sample1 Section",Description = "sample1 Description",UserId = Guid.NewGuid(),UserInfo = "sample1 UserInfo",Ip = "198.162.1.1",InsertDateTime = DateTime.Now,ClientInfo = "sample1 ClientInfo"},
                new CreateInformativeLogDto(){LogLevelId = 2,Section = "sample2 Section",Description = "sample2 Description",UserId = Guid.NewGuid(),UserInfo = "sample2 UserInfo",Ip = "198.162.1.2",InsertDateTime = DateTime.Now,ClientInfo = "sample2 ClientInfo"},
                new CreateInformativeLogDto(){LogLevelId = 3,Section = "sample3 Section",Description = "sample3 Description",UserId = Guid.NewGuid(),UserInfo = "sample3 UserInfo",Ip = "198.162.1.3",InsertDateTime = DateTime.Now,ClientInfo = "sample3 ClientInfo"},
            };

            //Act
            foreach (var item in logLevels)
            {
                await PostAsync<CreateLogLevelDto, CreateLogLevelDto>("/LogLevel/Create", item);
            }
            foreach (var item in informativeLogs)
            {
                await PostAsync<CreateInformativeLogDto, CreateInformativeLogDto>("/InformativeLog/Create", item);
            }

            var informativeLogList = await PostAsync<GetInforamtaiveLogDto, ApiResponseEnvelope<ICollection<GetInforamtaiveLogDto>>>("/InformativeLog/GetList", null);

            //Assert
            Assert.Equal(informativeLogList.Data.Count, 3);
            Assert.Equal(informativeLogList.HttpStatusCode, 200);
        }
    }
}
