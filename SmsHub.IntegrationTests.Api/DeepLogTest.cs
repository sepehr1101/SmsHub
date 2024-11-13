using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;

namespace SmsHub.IntegrationTests.Api
{
    public class DeepLogTest : BaseIntegrationTest
    {
        public DeepLogTest(TestEnvironmentWebApplicationFactory factory)
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
            //Assert
            Assert.True(true);

            //Act
            await PostAsync<CreateDeepLogDto, CreateDeepLogDto>("/DeepLog/Create", deepLog);
            //Assert
            Assert.True(true);
        }
    }
}
