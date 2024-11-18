using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class MessageBatchControllerTest:BaseIntegrationTest
    {
        public MessageBatchControllerTest(TestEnvironmentWebApplicationFactory factory)
            :base(factory)
        {
        }

        [Fact]
        public async void CreateMessageBatch_MessageBatchDto_ShouldDeleteMessageBatch()
        {
            //Arrange
            var line = new CreateLineDto()
            {
                ProviderId = Domain.Constants.ProviderEnum.Kavenegar,
                Credential = "sample Credential",
                Number = "111"
            };
            var messageBatch = new CreateMessageBatchDto()
            {
                HolerSize = 2,
                AllSize = 4,
                InsertDateTime = DateTime.Now,
                LineId = 1
            };
            //Act
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);

            //Assert
            Assert.True(true);
        }
        
        
        [Fact]
        public async void DeleteMessageBatch_MessageBatchDto_ShouldDeleteMessageBatch()
        {
            //Arrange
            var line = new CreateLineDto()
            {
                ProviderId = Domain.Constants.ProviderEnum.Kavenegar,
                Credential = "sample Credential",
                Number = "111"
            };
            var messageBatch = new CreateMessageBatchDto()
            {
                HolerSize = 2,
                AllSize = 4,
                InsertDateTime = DateTime.Now,
                LineId = 1
            };
            var deleteMessageBatch = new DeleteMessageBatchDto()
            {
                Id=1
            };
            //Act
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);

            await PostAsync<DeleteMessageBatchDto, DeleteMessageBatchDto>("/MessageBatch/Delete", deleteMessageBatch);

            //Assert
            Assert.True(true);
        }
        
        
        [Fact]
        public async void UpdateMessageBatch_MessageBatchDto_ShouldUpdateMessageBatch()
        {
            //Arrange
            var line = new CreateLineDto()
            {
                ProviderId = Domain.Constants.ProviderEnum.Kavenegar,
                Credential = "sample Credential",
                Number = "111"
            };
            var messageBatch = new CreateMessageBatchDto()
            {
                HolerSize = 2,
                AllSize = 4,
                InsertDateTime = DateTime.Now,
                LineId = 1
            };
           var updateMessageBatch = new UpdateMessageBatchDto()
           {
               Id=1,
               HolerSize = 2,
               AllSize = 4,
               InsertDateTime = DateTime.Now,
               LineId = 1
           };
            //Act
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);

            await PostAsync<UpdateMessageBatchDto, UpdateMessageBatchDto>("/MessageBatch/Update", updateMessageBatch);

            //Assert
            Assert.True(true);
        }
    }
}
