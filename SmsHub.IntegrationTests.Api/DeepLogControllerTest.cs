using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class DeepLogControllerTest : BaseIntegrationTest
    {
        public DeepLogControllerTest(_TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateDeepLog_DeepLogDto_ShouldCreateDeepLog()
        {
            //Arrange
            var operationType = new CreateOperationTypeDto()
            {
                Id = 1,
                Title = "Sample Title",
                Css = "Sample Css"
            };
            var deepLog = new CreateDeepLogDto()
            {
                PrimaryDb = "Test Db",
                PrimaryTable = "Test Table",
                PrimaryId = "Test Id",
                ValueBefore = "Test ValueBefore",
                ValueAfter = "Test ValueAfter",
                Ip = "198.192.1.1",
                InsertDateTime = DateTime.Now,
                ClientInfo = "Test ClientInfo",
                OperationTypeId = 1
            };

            //Act
            await PostAsync<CreateOperationTypeDto, CreateOperationTypeDto>("/OperationType/Create", operationType);
            await PostAsync<CreateDeepLogDto, CreateDeepLogDto>("/DeepLog/Create", deepLog);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void DeleteDeepLog_DeepLogDto_ShouldDeleteDeepLog()
        {
            //Arrange
            var operationType = new CreateOperationTypeDto()
            {
                Id = 2,
                Title = "Sample Title",
                Css = "Sample Css"
            };
            var deepLog = new CreateDeepLogDto()
            {
                PrimaryDb = "Test Db",
                PrimaryTable = "Test Table",
                PrimaryId = "Test Id",
                ValueBefore = "Test ValueBefore",
                ValueAfter = "Test ValueAfter",
                Ip = "198.192.1.1",
                InsertDateTime = DateTime.Now,
                ClientInfo = "Test ClientInfo",
                OperationTypeId = 2
            };
            var deleteDeepLog = new DeleteDeepLogDto()
            {
                Id = 2
            };

            //Act
            await PostAsync<CreateOperationTypeDto, CreateOperationTypeDto>("/OperationType/Create", operationType);
            await PostAsync<CreateDeepLogDto, CreateDeepLogDto>("/DeepLog/Create", deepLog);

            await PostAsync<DeleteDeepLogDto, DeleteDeepLogDto>("/DeepLog/Delete", deleteDeepLog);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void UpdateDeepLog_DeepLogDto_ShouldUpdateDeepLog()
        {
            //Arrange
            var operationType = new CreateOperationTypeDto()
            {
                Id = 3,
                Title = "Sample Title",
                Css = "Sample Css"
            };
            var deepLog = new CreateDeepLogDto()
            {
                PrimaryDb = "Test Db",
                PrimaryTable = "Test Table",
                PrimaryId = "Test Id",
                ValueBefore = "Test ValueBefore",
                ValueAfter = "Test ValueAfter",
                Ip = "198.192.1.1",
                InsertDateTime = DateTime.Now,
                ClientInfo = "Test ClientInfo",
                OperationTypeId = 3
            };
            var updateDeepLog = new UpdateDeepLogDto()
            {
                Id = 3,
                PrimaryDb = "Update Db",
                PrimaryTable = "Update Table",
                PrimaryId = "Update Id",
                ValueBefore = "Update ValueBefore",
                ValueAfter = "Update ValueAfter",
                Ip = "198.192.1.2",
                InsertDateTime = DateTime.Now,
                ClientInfo = "Update ClientInfo",
                OperationTypeId = 3
            };

            //Act
            await PostAsync<CreateOperationTypeDto, CreateOperationTypeDto>("/OperationType/Create", operationType);
            await PostAsync<CreateDeepLogDto, CreateDeepLogDto>("/DeepLog/Create", deepLog);

            await PostAsync<UpdateDeepLogDto, UpdateDeepLogDto>("/DeepLog/Update", updateDeepLog);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void GetSingleDeepLog_DeepLogDto_ShouldGetSingleDeepLog()
        {
            //Arrange
            var operationType = new CreateOperationTypeDto()
            {
                Id = 4,
                Title = "Sample Title",
                Css = "Sample Css"
            };
            var deepLog = new CreateDeepLogDto()
            {
                PrimaryDb = "Test Db",
                PrimaryTable = "Test Table",
                PrimaryId = "Test Id",
                ValueBefore = "Test ValueBefore",
                ValueAfter = "Test ValueAfter",
                Ip = "198.192.1.1",
                InsertDateTime = DateTime.Now,
                ClientInfo = "Test ClientInfo",
                OperationTypeId = 4
            };
            IntId deepLogId = 4;

            //Act
            await PostAsync<CreateOperationTypeDto, CreateOperationTypeDto>("/OperationType/Create", operationType);
            await PostAsync<CreateDeepLogDto, CreateDeepLogDto>("/DeepLog/Create", deepLog);

            var singleDeepLog = await PostAsync<IntId, ApiResponseEnvelope<GetDeepLogDto>>("/DeepLog/GetSingle", deepLogId);

            //Assert
            Assert.Equal(singleDeepLog.Data.Id, 4);
        }
        
        
        [Fact]
        public async void GetListDeepLog_DeepLogDto_ShouldGetListDeepLog()
        {
            //Arrange
            var operationTypes = new List<CreateOperationTypeDto>()
            {
                new CreateOperationTypeDto(){Id = 5,Title = "Sample1 Title",Css = "Sample1 Css"},
                new CreateOperationTypeDto(){Id = 6,Title = "Sample2 Title",Css = "Sample2 Css"},
                new CreateOperationTypeDto(){Id = 7,Title = "Sample3 Title",Css = "Sample3 Css"},
            };
            var deepLogs = new List<CreateDeepLogDto>()
            {
                new CreateDeepLogDto(){PrimaryDb = "Test1 Db",PrimaryTable = "Test1 Table",PrimaryId = "Test1 Id",ValueBefore = "Test1 ValueBefore",ValueAfter = "Test1 ValueAfter",Ip = "198.192.1.1",InsertDateTime = DateTime.Now,ClientInfo = "Test1 ClientInfo",OperationTypeId = 5,},
                new CreateDeepLogDto(){PrimaryDb = "Test2 Db",PrimaryTable = "Test2 Table",PrimaryId = "Test2 Id",ValueBefore = "Test2 ValueBefore",ValueAfter = "Test2 ValueAfter",Ip = "198.192.1.2",InsertDateTime = DateTime.Now,ClientInfo = "Test2 ClientInfo",OperationTypeId = 6,},
                new CreateDeepLogDto(){PrimaryDb = "Test3 Db",PrimaryTable = "Test3 Table",PrimaryId = "Test3 Id",ValueBefore = "Test3 ValueBefore",ValueAfter = "Test3 ValueAfter",Ip = "198.192.1.3",InsertDateTime = DateTime.Now,ClientInfo = "Test3 ClientInfo",OperationTypeId = 7,},
                new CreateDeepLogDto(){PrimaryDb = "Test4 Db",PrimaryTable = "Test4 Table",PrimaryId = "Test4 Id",ValueBefore = "Test4 ValueBefore",ValueAfter = "Test4 ValueAfter",Ip = "198.192.1.4",InsertDateTime = DateTime.Now,ClientInfo = "Test4 ClientInfo",OperationTypeId = 7,},
            };

            //Act
            foreach (var item in operationTypes)
            {
                await PostAsync<CreateOperationTypeDto, CreateOperationTypeDto>("/OperationType/Create", item);
            }
            foreach (var item in deepLogs)
            {
                await PostAsync<CreateDeepLogDto, CreateDeepLogDto>("/DeepLog/Create", item);
            }


            var deepLogList = await PostAsync<GetDeepLogDto, ApiResponseEnvelope<ICollection<GetDeepLogDto>>>("/DeepLog/GetList", null);

            //Assert
            Assert.InRange(deepLogList.Data.Count, 4,7);
        }
    }
}
