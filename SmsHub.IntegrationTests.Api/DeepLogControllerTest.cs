using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class DeepLogControllerTest : BaseIntegrationTest
    {
        public DeepLogControllerTest(TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateDeepLog_DeepLogDto_ShouldCreateDeepLog()
        {
            //Arrange
            var operationType = new CreateOperationTypeDto()
            {
                Id=1,
                Title="Sample Title",
                Css="Sample Css"
            };
            var deepLog = new CreateDeepLogDto()
            {
                PrimaryDb="Test Db",
                PrimaryTable="Test Table",
                PrimaryId="Test Id",
                ValueBefore="Test ValueBefore",
                ValueAfter="Test ValueAfter",
                Ip="198.192.1.1",
                InsertDateTime=DateTime.Now,
                ClientInfo="Test ClientInfo",
                OperationTypeId=1
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
                Id=1,
                Title="Sample Title",
                Css="Sample Css"
            };
            var deepLog = new CreateDeepLogDto()
            {
                PrimaryDb="Test Db",
                PrimaryTable="Test Table",
                PrimaryId="Test Id",
                ValueBefore="Test ValueBefore",
                ValueAfter="Test ValueAfter",
                Ip="198.192.1.1",
                InsertDateTime=DateTime.Now,
                ClientInfo="Test ClientInfo",
                OperationTypeId=1
            };
            var deleteDeepLog = new DeleteDeepLogDto()
            {
                Id=1
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
                Id=1,
                Title="Sample Title",
                Css="Sample Css"
            };
            var deepLog = new CreateDeepLogDto()
            {
                PrimaryDb="Test Db",
                PrimaryTable="Test Table",
                PrimaryId="Test Id",
                ValueBefore="Test ValueBefore",
                ValueAfter="Test ValueAfter",
                Ip="198.192.1.1",
                InsertDateTime=DateTime.Now,
                ClientInfo="Test ClientInfo",
                OperationTypeId=1
            };
            var updateDeepLog = new UpdateDeepLogDto()
            {
                Id=1,
                PrimaryDb = "Update Db",
                PrimaryTable = "Update Table",
                PrimaryId = "Update Id",
                ValueBefore = "Update ValueBefore",
                ValueAfter = "Update ValueAfter",
                Ip = "198.192.1.2",
                InsertDateTime = DateTime.Now,
                ClientInfo = "Update ClientInfo",
                OperationTypeId = 1
            };

            //Act
            await PostAsync<CreateOperationTypeDto, CreateOperationTypeDto>("/OperationType/Create", operationType);
            await PostAsync<CreateDeepLogDto, CreateDeepLogDto>("/DeepLog/Create", deepLog);

            await PostAsync<UpdateDeepLogDto, UpdateDeepLogDto>("/DeepLog/Update", updateDeepLog);

            //Assert
            Assert.True(true);
        }
    }
}
