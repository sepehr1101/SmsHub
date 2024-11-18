using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    public class MessageStateControllerTest:BaseIntegrationTest
    {
        public MessageStateControllerTest(TestEnvironmentWebApplicationFactory factory)
            :base(factory)
        {
        }

        [Fact]
        public async void CreateMessageState_MessageStateDto_ShouldCreateMessageState()
        {
            //Arrange
            var messageStateCategory = new CreateMessageStateCategoryDto()
            {
                Css="Sample Css",
                IsError=true,
                Title="Sample Title",
                ProviderId=Domain.Constants.ProviderEnum.Kavenegar
            };
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
            await PostAsync<CreateMessageStateCategoryDto, CreateMessageStateCategoryDto>("/MessageStateCategory/Create", messageStateCategory);
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);
            await PostAsync<CreateMessagesHolderDto, CreateMessagesHolderDto>("/MessagesHolder/Create", messageHolder);

            var messagesHolders = await PostAsync<GetMessageHolderDto, List<GetMessageHolderDto>>("/MessagesHolder/GetList", null);

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
            var messageState = new CreateMessageStateDto()
            {
                MessagesDetailId=1,
                MessageStateCategoryId=1,
                InsertDateTime= DateTime.Now,
            };
            await PostAsync<CreateMessageDetailDto, CreateMessageDetailDto>("/MessagesDetail/Create", messageDetail);
            await PostAsync<CreateMessageStateDto, CreateMessageStateDto>("/MessageState/Create", messageState);

            //Assert
            Assert.True(true);
        }
        
        
        [Fact]
        public async void DeleteMessageState_MessageStateDto_ShouldDeleteMessageState()
        {
            //Arrange
            var messageStateCategory = new CreateMessageStateCategoryDto()
            {
                Css="Sample Css",
                IsError=true,
                Title="Sample Title",
                ProviderId=Domain.Constants.ProviderEnum.Kavenegar
            };
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
            await PostAsync<CreateMessageStateCategoryDto, CreateMessageStateCategoryDto>("/MessageStateCategory/Create", messageStateCategory);
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);
            await PostAsync<CreateMessagesHolderDto, CreateMessagesHolderDto>("/MessagesHolder/Create", messageHolder);

            var messagesHolders = await PostAsync<GetMessageHolderDto, List<GetMessageHolderDto>>("/MessagesHolder/GetList", null);

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
            var messageState = new CreateMessageStateDto()
            {
                MessagesDetailId=1,
                MessageStateCategoryId=1,
                InsertDateTime= DateTime.Now,
            };
            var deleteMessageState = new DeleteMessageStateDto()
            {
                Id=1
            };
            await PostAsync<CreateMessageDetailDto, CreateMessageDetailDto>("/MessagesDetail/Create", messageDetail);
            await PostAsync<CreateMessageStateDto, CreateMessageStateDto>("/MessageState/Create", messageState);

            await PostAsync<DeleteMessageStateDto, DeleteMessageStateDto>("/MessageState/Delete", deleteMessageState);

            //Assert
            Assert.True(true);
        }
        
        
        [Fact]
        public async void UpdateMessageState_MessageStateDto_ShouldUpdateMessageState()
        {
            //Arrange
            var messageStateCategory = new CreateMessageStateCategoryDto()
            {
                Css="Sample Css",
                IsError=true,
                Title="Sample Title",
                ProviderId=Domain.Constants.ProviderEnum.Kavenegar
            };
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
            await PostAsync<CreateMessageStateCategoryDto, CreateMessageStateCategoryDto>("/MessageStateCategory/Create", messageStateCategory);
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);
            await PostAsync<CreateMessagesHolderDto, CreateMessagesHolderDto>("/MessagesHolder/Create", messageHolder);

            var messagesHolders = await PostAsync<GetMessageHolderDto, List<GetMessageHolderDto>>("/MessagesHolder/GetList", null);

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
            var messageState = new CreateMessageStateDto()
            {
                MessagesDetailId=1,
                MessageStateCategoryId=1,
                InsertDateTime= DateTime.Now,
            };
            var updateMessageState = new UpdateMessageStateDto()
            {
                Id=1,
                MessagesDetailId = 1,
                MessageStateCategoryId = 1,
                InsertDateTime = DateTime.Now,
            };
            await PostAsync<CreateMessageDetailDto, CreateMessageDetailDto>("/MessagesDetail/Create", messageDetail);
            await PostAsync<CreateMessageStateDto, CreateMessageStateDto>("/MessageState/Create", messageState);

            await PostAsync<UpdateMessageStateDto, UpdateMessageStateDto>("/MessageState/Update", updateMessageState);

            //Assert
            Assert.True(true);
        }
    }
}
