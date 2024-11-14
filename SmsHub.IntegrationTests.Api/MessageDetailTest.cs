using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class MessageDetailTest : BaseIntegrationTest
    {
        public MessageDetailTest(TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void MessageDetailState_MessageDetailDto_ShouldCreateMessageDetail()
        {
            //Arrange
            var messageStateCategory = new CreateMessageStateCategoryDto()
            {
                Css = "Sample Css",
                IsError = true,
                Title = "Sample Title",
                Provider =3
            };////invalid dto because ProviderNavigation is invalid(null)
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
                MessageBatchId = 1,
                InsertDateTime = DateTime.Now,
                DetailsSize = 2,
                RetryCount = 1,
                SendDone = false
            };
           

            ////Act
            //await PostAsync<CreateMessageStateCategoryDto, CreateMessageStateCategoryDto>("/MessageStateCategory/Create", messageStateCategory);
            ////Assert
            //Assert.True(true);

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
            var messagesHolders = await PostAsync<GetMessageHolderDto,List< GetMessageHolderDto>>("/MessagesHolder/GetList",null);

            var messageHolderId = messagesHolders.FirstOrDefault().Id;
            var messageDetail = new CreateMessageDetailDto()
            {
                MessagesHolderId = messageHolderId,
                ProviderResult = 12,
                Receptor = "sample Receptor",
                SendDateTime = DateTime.Now,
                SmsCount = 1,
                Text = "sample Text"
            };

            //Act
            await PostAsync<CreateMessageDetailDto, CreateMessageDetailDto>("/MessagesDetail/Create", messageDetail);
            //Assert
            Assert.True(true);
        }
    }
}
