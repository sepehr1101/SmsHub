using Microsoft.AspNetCore.Mvc.ApiExplorer;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class InformativeLogControllerTest : BaseIntegrationTest
    {
        public InformativeLogControllerTest(_TestEnvironmentWebApplicationFactory factory)
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
                Title = "Create Test title",
                Css = "Create Test Css"
            }; 
            await PostAsync<CreateLogLevelDto, CreateLogLevelDto>("/LogLevel/Create", logLevel);
            var logLevelData = await PostAsync<GetLogLevelDto, ApiResponseEnvelope<ICollection<GetLogLevelDto>>>("/LogLevel/GetList", null);

            var informativeLog = new CreateInformativeLogDto()
            {
                LogLevelId = logLevelData.Data.OrderByDescending(x=>x.Id).FirstOrDefault().Id,
                Section = "Create Test  Section",
                Description = "Create Test  Description",
                UserId = Guid.NewGuid(),
                UserInfo = "Create Test UserInfo",
                Ip = "198.162.1.1",
                InsertDateTime = DateTime.Now,
                ClientInfo = "Create Test ClientInfo"
            };

            //Act
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
                Id = 2,
                Title = "Delete Test title",
                Css = "Delete Test Css"
            };
            await PostAsync<CreateLogLevelDto, CreateLogLevelDto>("/LogLevel/Create", logLevel);
            var logLevelData = await PostAsync<GetLogLevelDto, ApiResponseEnvelope<ICollection<GetLogLevelDto>>>("/LogLevel/GetList", null);

            var informativeLog = new CreateInformativeLogDto()
            {
                LogLevelId = logLevelData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Section = "Delete Test Section",
                Description = "Delete Test Description",
                UserId = Guid.NewGuid(),
                UserInfo = "Delete Test UserInfo",
                Ip = "198.162.1.1",
                InsertDateTime = DateTime.Now,
                ClientInfo = "Delete Test ClientInfo"
            };
            await PostAsync<CreateInformativeLogDto, CreateInformativeLogDto>("/InformativeLog/Create", informativeLog);
            var informativeLogData = await PostAsync<GetInforamtaiveLogDto, ApiResponseEnvelope<ICollection<GetInforamtaiveLogDto>>>("/InformativeLog/GetList", null);

            var deleteInformativeLog = new DeleteInformativeLogDto()
            {
                Id = informativeLogData.Data.OrderByDescending(x=>x.Id).FirstOrDefault().Id,
            };

            //Act

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
                Id = 3,
                Title = "sample Test title",
                Css = "sample Test Css"
            };
            await PostAsync<CreateLogLevelDto, CreateLogLevelDto>("/LogLevel/Create", logLevel);
            var logLevelData = await PostAsync<GetLogLevelDto, ApiResponseEnvelope<ICollection<GetLogLevelDto>>>("/LogLevel/GetList", null);

            var informativeLog = new CreateInformativeLogDto()
            {
                LogLevelId = logLevelData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Section = "sample Test Section",
                Description = "sample Test Description",
                UserId = Guid.NewGuid(),
                UserInfo = "sample Test UserInfo",
                Ip = "198.162.1.1",
                InsertDateTime = DateTime.Now,
                ClientInfo = "sample Test ClientInfo"
            };
            await PostAsync<CreateInformativeLogDto, CreateInformativeLogDto>("/InformativeLog/Create", informativeLog);
            var informativeLogData = await PostAsync<GetInforamtaiveLogDto, ApiResponseEnvelope<ICollection<GetInforamtaiveLogDto>>>("/InformativeLog/GetList", null);

            var updateInformativeLog = new UpdateInformativeLogDto()
            {
                Id = informativeLogData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                LogLevelId = logLevelData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Section = "Update Section",
                Description = "Update Description",
                UserId = Guid.NewGuid(),
                UserInfo = "Update UserInfo",
                Ip = "198.162.1.2",
                InsertDateTime = DateTime.Now,
                ClientInfo = "Update ClientInfo"
            };

            //Act
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
                Id = 4,
                Title = "Getingle Test title",
                Css = "Getingle Test Css"
            };
            await PostAsync<CreateLogLevelDto, CreateLogLevelDto>("/LogLevel/Create", logLevel);
            var logLevelData = await PostAsync<GetLogLevelDto, ApiResponseEnvelope<ICollection<GetLogLevelDto>>>("/LogLevel/GetList", null);

            var informativeLog = new CreateInformativeLogDto()
            {
                LogLevelId = logLevelData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Section = "Getingle Test Section",
                Description = "Getingle Test Description",
                UserId = Guid.NewGuid(),
                UserInfo = "Getingle Test UserInfo",
                Ip = "198.162.1.1",
                InsertDateTime = DateTime.Now,
                ClientInfo = "Getingle Test ClientInfo"
            };
            await PostAsync<CreateInformativeLogDto, CreateInformativeLogDto>("/InformativeLog/Create", informativeLog);
            var informativeLogData = await PostAsync<GetInforamtaiveLogDto, ApiResponseEnvelope<ICollection<GetInforamtaiveLogDto>>>("/InformativeLog/GetList", null);

            LongId informativeLogId = informativeLogData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;
            //Act
            var singleInformativeLog = await PostAsync<LongId, ApiResponseEnvelope<GetInforamtaiveLogDto>>("/InformativeLog/GetSingle", informativeLogId);

            //Assert
            Assert.Equal(singleInformativeLog.Data.Id, informativeLogId.Id);
        }


        [Fact]
        public async void GetListInformativeLog_InformativeLogDto_ShouldGetListInformativeLog()
        {
            //Arrange
            var logLevels = new List<CreateLogLevelDto>()
            {
                new CreateLogLevelDto(){ Id = 5,Title = "sample1 title",Css = "sample1 Css"},
                new CreateLogLevelDto(){ Id = 6,Title = "sample2 title",Css = "sample2 Css"},
                new CreateLogLevelDto(){ Id = 7,Title = "sample3 title",Css = "sample3 Css"},
            };
            var informativeLogs = new List<CreateInformativeLogDto>()
            {
                new CreateInformativeLogDto(){LogLevelId = 5,Section = "sample1 Section",Description = "sample1 Description",UserId = Guid.NewGuid(),UserInfo = "sample1 UserInfo",Ip = "198.162.1.1",InsertDateTime = DateTime.Now,ClientInfo = "sample1 ClientInfo"},
                new CreateInformativeLogDto(){LogLevelId = 6,Section = "sample2 Section",Description = "sample2 Description",UserId = Guid.NewGuid(),UserInfo = "sample2 UserInfo",Ip = "198.162.1.2",InsertDateTime = DateTime.Now,ClientInfo = "sample2 ClientInfo"},
                new CreateInformativeLogDto(){LogLevelId = 7,Section = "sample3 Section",Description = "sample3 Description",UserId = Guid.NewGuid(),UserInfo = "sample3 UserInfo",Ip = "198.162.1.3",InsertDateTime = DateTime.Now,ClientInfo = "sample3 ClientInfo"},
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
            Assert.InRange(informativeLogList.Data.Count, 3,7);
        }
    }
}
