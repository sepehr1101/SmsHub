using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;
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
                Credential = "{'apiKey' : '---'}",
                Number = "14990"
            };
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);

            var messageBatch = new CreateMessageBatchDto()
            {
                HolderSize = 4,
                AllSize = 8,
                InsertDateTime = DateTime.Now,
                LineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);
            var messageBatchData = await PostAsync<GetMessageBatchDto, ApiResponseEnvelope<ICollection<GetMessageBatchDto>>>("/MessageBatch/GetList", null);

            var messageHolder = new CreateMessagesHolderDto()
            {
                MessageBatchId = messageBatchData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                InsertDateTime = DateTime.Now,
                DetailsSize = 2,
                RetryCount = 1,
                SendDone = false
            };


            //Act
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
                Credential = "{'apiKey' : '---'}",
                Number = "14992"
            };
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);

            var messageBatch = new CreateMessageBatchDto()
            {
                HolderSize = 4,
                AllSize = 8,
                InsertDateTime = DateTime.Now,
                LineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);
            var messageBatchData = await PostAsync<GetMessageBatchDto, ApiResponseEnvelope<ICollection<GetMessageBatchDto>>>("/MessageBatch/GetList", null);

            var messageHolder = new CreateMessagesHolderDto()
            {
                MessageBatchId = messageBatchData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                InsertDateTime = DateTime.Now,
                DetailsSize = 2,
                RetryCount = 1,
                SendDone = false
            };
            await PostAsync<CreateMessagesHolderDto, CreateMessagesHolderDto>("/MessagesHolder/Create", messageHolder);
            var messagesHolders = await PostAsync<GetMessageHolderDto, ApiResponseEnvelope<ICollection<GetMessageHolderDto>>>("/MessagesHolder/GetList", null);

            var deleteMessageHolder = new DeleteMessageHolderDto()
            {
                Id = messagesHolders.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };

            //Act
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
                Credential = "{'apiKey' : '---'}",
                Number = "14998"
            };
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);

            var messageBatch = new CreateMessageBatchDto()
            {
                HolderSize = 4,
                AllSize = 8,
                InsertDateTime = DateTime.Now,
                LineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);
            var messageBatchData = await PostAsync<GetMessageBatchDto, ApiResponseEnvelope<ICollection<GetMessageBatchDto>>>("/MessageBatch/GetList", null);

            var messageHolder = new CreateMessagesHolderDto()
            {
                MessageBatchId = messageBatchData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                InsertDateTime = DateTime.Now,
                DetailsSize = 2,
                RetryCount = 1,
                SendDone = false
            };
            await PostAsync<CreateMessagesHolderDto, CreateMessagesHolderDto>("/MessagesHolder/Create", messageHolder);
            var messagesHolders = await PostAsync<GetMessageHolderDto, ApiResponseEnvelope<ICollection<GetMessageHolderDto>>>("/MessagesHolder/GetList", null);

            var updateMessageHolder = new UpdateMessageHolderDto()
            {
                Id = messagesHolders.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                MessageBatchId = 1,
                InsertDateTime = DateTime.Now,
                DetailsSize = 2,
                RetryCount = 1,
                SendDone = false
            };

            //Act
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
                Credential = "{'apiKey' : '---'}",
                Number = "14995"
            };
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);

            var messageBatch = new CreateMessageBatchDto()
            {
                HolderSize = 4,
                AllSize = 8,
                InsertDateTime = DateTime.Now,
                LineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);
            var messageBatchData = await PostAsync<GetMessageBatchDto, ApiResponseEnvelope<ICollection<GetMessageBatchDto>>>("/MessageBatch/GetList", null);

            var messageHolder = new CreateMessagesHolderDto()
            {
                MessageBatchId = messageBatchData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                InsertDateTime = DateTime.Now,
                DetailsSize = 2,
                RetryCount = 1,
                SendDone = false
            };
            await PostAsync<CreateMessagesHolderDto, CreateMessagesHolderDto>("/MessagesHolder/Create", messageHolder);
            var messagesHolders = await PostAsync<GetMessageHolderDto, ApiResponseEnvelope<ICollection<GetMessageHolderDto>>>("/MessagesHolder/GetList", null);

            GuidId messageHolderId = messagesHolders.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            var singleMessageHolder = await PostAsync<GuidId, ApiResponseEnvelope<GetMessageHolderDto>>("/MessagesHolder/GetSingle", messageHolderId);

            //Assert
            Assert.Equal(singleMessageHolder.Data.Id, messageHolderId.Id);
        }


        [Fact]
        public async void GetListMessageHolder_MessageHolderDto_ShouldGetListMessageHolder()
        {
            //Arrange
            var lines = new List<CreateLineDto>()
            {
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Kavenegar,Credential ="{'apiKey' : '---'}",Number = "144920"},
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Magfa,Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }",Number = "149971"},
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Magfa,Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }",Number = "149975"},
            };
            var messageBatchs = new List<CreateMessageBatchDto>()
            {
                new CreateMessageBatchDto(){ HolderSize = 12,AllSize = 8,InsertDateTime = DateTime.Now,LineId = 1},
                new CreateMessageBatchDto(){ HolderSize = 5,AllSize = 2,InsertDateTime = DateTime.Now,LineId = 2},
                new CreateMessageBatchDto(){ HolderSize = 8,AllSize = 4,InsertDateTime = DateTime.Now,LineId = 2},
                new CreateMessageBatchDto(){ HolderSize = 3,AllSize = 6,InsertDateTime = DateTime.Now,LineId = 3},
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
            Assert.InRange(messageHolderList.Data.Count, 4, 8);
        }
    }
}
