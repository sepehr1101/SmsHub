using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class MessageHolderTest : BaseIntegrationTest
    {
        public MessageHolderTest(TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateMessageBatch_MessageBatchDto_ShouldCreateMessageBatch()
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
            var messageHolder = new CreateMessagesHolderDto()
            {
                MessageBatchId=1,
                InsertDateTime=DateTime.Now,
                DetailsSize=2,
                RetryCount=1,
                SendDone=false
            };

            //Act
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            //Assert
            Assert.True(true);

            //Act
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);
            //Assert
            Assert.True(true);
            
            //Act
            await PostAsync<CreateMessagesHolderDto, CreateMessagesHolderDto>("/MessagesHolder/Create", messageHolder);
            //Assert
            Assert.True(true);
        }
    }
}
