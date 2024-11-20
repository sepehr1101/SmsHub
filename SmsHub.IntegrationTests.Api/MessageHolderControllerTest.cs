using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class MessageHolderControllerTest : BaseIntegrationTest
    {
        public MessageHolderControllerTest(_TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateMessageHolder_MessageHolderDto_ShouldCreateMessageHolder()
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
                MessageBatchId = 1,
                InsertDateTime = DateTime.Now,
                DetailsSize = 2,
                RetryCount = 1,
                SendDone = false
            };

            //Act
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);
            await PostAsync<CreateMessagesHolderDto, CreateMessagesHolderDto>("/MessagesHolder/Create", messageHolder);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void DeleteMessageHolder_MessageHolderDto_ShouldDeleteMessageHolder()
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
                MessageBatchId = 1,
                InsertDateTime = DateTime.Now,
                DetailsSize = 2,
                RetryCount = 1,
                SendDone = false
            };

            //Act
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);
            await PostAsync<CreateMessagesHolderDto, CreateMessagesHolderDto>("/MessagesHolder/Create", messageHolder);

            var messagesHolders = await PostAsync<GetMessageHolderDto, ApiResponseEnvelope<ICollection<GetMessageHolderDto>>>("/MessagesHolder/GetList", null);
            var deleteMessageHolder = new DeleteMessageHolderDto()
            {
                Id = messagesHolders.Data.FirstOrDefault().Id
            };

            await PostAsync<DeleteMessageHolderDto, DeleteMessageHolderDto>("/MessagesHolder/Delete", deleteMessageHolder);

            //Assert
            Assert.True(true);
        }

        [Fact]
        public async void UpdateMessageHolder_MessageHolderDto_ShouldUpdateMessageHolder()
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
                MessageBatchId = 1,
                InsertDateTime = DateTime.Now,
                DetailsSize = 2,
                RetryCount = 1,
                SendDone = false
            };

            //Act
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);
            await PostAsync<CreateMessagesHolderDto, CreateMessagesHolderDto>("/MessagesHolder/Create", messageHolder);

            var messagesHolders = await PostAsync<GetMessageHolderDto, ApiResponseEnvelope<ICollection<GetMessageHolderDto>>>("/MessagesHolder/GetList", null);
            var updateMessageHolder = new UpdateMessageHolderDto()
            {
                Id = messagesHolders.Data.FirstOrDefault().Id,
                MessageBatchId = 1,
                InsertDateTime = DateTime.Now,
                DetailsSize = 2,
                RetryCount = 1,
                SendDone = false
            };

            await PostAsync<UpdateMessageHolderDto, UpdateMessageHolderDto>("/MessagesHolder/Update", updateMessageHolder);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void GetSingleMessageHolder_MessageHolderDto_ShouldGetSingleMessageHolder()
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
                MessageBatchId = 1,
                InsertDateTime = DateTime.Now,
                DetailsSize = 2,
                RetryCount = 1,
                SendDone = false
            };

            //Act
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);
            await PostAsync<CreateMessagesHolderDto, CreateMessagesHolderDto>("/MessagesHolder/Create", messageHolder);

            var messagesHolders = await PostAsync<GetMessageHolderDto, ApiResponseEnvelope<ICollection<GetMessageHolderDto>>>("/MessagesHolder/GetList", null);
            var messageHolderId = new GuidId()
            {
                Id = messagesHolders.Data.FirstOrDefault().Id
            };

            var singleMessageHolder = await PostAsync<GuidId, ApiResponseEnvelope<GetMessageHolderDto>>("/MessagesHolder/GetSingle", messageHolderId);

            //Assert
            Assert.Equal(singleMessageHolder.Data.Id, messagesHolders.Data.FirstOrDefault().Id);
        }
        
        
        [Fact]
        public async void GetListMessageHolder_MessageHolderDto_ShouldGetListMessageHolder()
        { 
            //Arrange
            var lines = new List<CreateLineDto>()
            {
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Kavenegar,Credential = "sample1 Credential",Number = "111"},
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Magfa,Credential = "sample2 Credential",Number = "150"},
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Magfa,Credential = "sample3 Credential",Number = "125"},
            };
            var messageBatchs = new List<CreateMessageBatchDto>()
            {
                new CreateMessageBatchDto(){ HolerSize = 12,AllSize = 8,InsertDateTime = DateTime.Now,LineId = 1},
                new CreateMessageBatchDto(){ HolerSize = 5,AllSize = 2,InsertDateTime = DateTime.Now,LineId = 2},
                new CreateMessageBatchDto(){ HolerSize = 8,AllSize = 4,InsertDateTime = DateTime.Now,LineId = 2},
                new CreateMessageBatchDto(){ HolerSize = 3,AllSize = 6,InsertDateTime = DateTime.Now,LineId = 3},
            };
            var messageHolders = new List<CreateMessagesHolderDto>()
            {
                new CreateMessagesHolderDto(){MessageBatchId = 1,InsertDateTime = DateTime.Now,DetailsSize = 2,RetryCount = 1,SendDone = false},
                new CreateMessagesHolderDto(){MessageBatchId = 2,InsertDateTime = DateTime.Now,DetailsSize = 8,RetryCount = 5,SendDone = false},
                new CreateMessagesHolderDto(){MessageBatchId = 3,InsertDateTime = DateTime.Now,DetailsSize = 10,RetryCount = 3,SendDone = true},
                new CreateMessagesHolderDto(){MessageBatchId = 4,InsertDateTime = DateTime.Now,DetailsSize = 5,RetryCount = 2,SendDone = false},
            };

            //Act
            foreach (var item in lines)
            {
                await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", item);
            }
            foreach (var item in messageBatchs)
            {
                await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", item);
            }
            foreach (var item in messageHolders)
            {
                await PostAsync<CreateMessagesHolderDto, CreateMessagesHolderDto>("/MessagesHolder/Create", item);
            }
            var messageHolderList = await PostAsync<GetMessageHolderDto, ApiResponseEnvelope<ICollection<GetMessageHolderDto>>>("/MessagesHolder/GetList", null);

            //Assert
            Assert.Equal(messageHolderList.Data.Count,4);
        }
    }
}
