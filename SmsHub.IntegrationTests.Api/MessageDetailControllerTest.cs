using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class MessageDetailControllerTest : BaseIntegrationTest
    {
        public MessageDetailControllerTest(TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateMessageDetailState_MessageDetailDto_ShouldCreateMessageDetail()
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


            ////Act
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);
            await PostAsync<CreateMessagesHolderDto, CreateMessagesHolderDto>("/MessagesHolder/Create", messageHolder);

            var messagesHolders = await PostAsync<GetMessageHolderDto, ApiResponseEnvelope<ICollection<GetMessageHolderDto>>>("/MessagesHolder/GetList", null);
            var messageHolderId = messagesHolders.Data.FirstOrDefault().Id;
            var messageDetail = new CreateMessageDetailDto()
            {
                MessagesHolderId = messageHolderId,
                ProviderResult = 12,
                Receptor = "sample Receptor",
                SendDateTime = DateTime.Now,
                SmsCount = 1,
                Text = "sample Text"
            };

            await PostAsync<CreateMessageDetailDto, CreateMessageDetailDto>("/MessagesDetail/Create", messageDetail);

            //Assert
            Assert.True(true);
        }



        [Fact]
        public async void DeleteMessageDetailState_MessageDetailDto_ShouldDeleteMessageDetail()
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
            var deleteMessageDetail = new DeleteMessageDetailDto()
            {
                Id = 1
            };

            ////Act
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);
            await PostAsync<CreateMessagesHolderDto, CreateMessagesHolderDto>("/MessagesHolder/Create", messageHolder);

            var messagesHolders = await PostAsync<GetMessageHolderDto, ApiResponseEnvelope<ICollection<GetMessageHolderDto>>>("/MessagesHolder/GetList", null);
            var messageHolderId = messagesHolders.Data.FirstOrDefault().Id;
            var messageDetail = new CreateMessageDetailDto()
            {
                MessagesHolderId = messageHolderId,
                ProviderResult = 12,
                Receptor = "sample Receptor",
                SendDateTime = DateTime.Now,
                SmsCount = 1,
                Text = "sample Text"
            };

            await PostAsync<CreateMessageDetailDto, CreateMessageDetailDto>("/MessagesDetail/Create", messageDetail);

            await PostAsync<DeleteMessageDetailDto, DeleteMessageDetailDto>("/MessagesDetail/Delete", deleteMessageDetail);

            //Assert
            Assert.True(true);
        }



        [Fact]
        public async void UpdateMessageDetailState_MessageDetailDto_ShouldUpdateMessageDetail()
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

            ////Act
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);
            await PostAsync<CreateMessagesHolderDto, CreateMessagesHolderDto>("/MessagesHolder/Create", messageHolder);

            var messagesHolders = await PostAsync<GetMessageHolderDto, ApiResponseEnvelope<ICollection<GetMessageHolderDto>>>("/MessagesHolder/GetList", null);
            var messageHolderId = messagesHolders.Data.FirstOrDefault().Id;
            var messageDetail = new CreateMessageDetailDto()
            {
                MessagesHolderId = messageHolderId,
                ProviderResult = 12,
                Receptor = "sample Receptor",
                SendDateTime = DateTime.Now,
                SmsCount = 1,
                Text = "sample Text"
            };
            await PostAsync<CreateMessageDetailDto, CreateMessageDetailDto>("/MessagesDetail/Create", messageDetail);


            var updateMessageDetail = new UpdateMessageDetailDto()
            {
                Id = 1,
                MessagesHolderId = messageHolderId,
                ProviderResult = 12,
                Receptor = "sample Receptor",
                SendDateTime = DateTime.Now,
                SmsCount = 1,
                Text = "sample Text"
            };
            await PostAsync<UpdateMessageDetailDto, UpdateMessageDetailDto>("/MessagesDetail/Update", updateMessageDetail);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void GetSingleUpdateMessageDetailState_MessageDetailDto_ShouldGetSingleMessageDetail()
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

            ////Act
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);
            await PostAsync<CreateMessagesHolderDto, CreateMessagesHolderDto>("/MessagesHolder/Create", messageHolder);

            var messagesHolders = await PostAsync<GetMessageHolderDto,ApiResponseEnvelope<ICollection<GetMessageHolderDto>>>("/MessagesHolder/GetList", null);
            var messageHolderId = messagesHolders.Data.FirstOrDefault().Id;
            var messageDetail = new CreateMessageDetailDto()
            {
                MessagesHolderId = messageHolderId,
                ProviderResult = 12,
                Receptor = "sample Receptor",
                SendDateTime = DateTime.Now,
                SmsCount = 1,
                Text = "sample Text"
            };
            var messageDetailId = new IntId()
            {
                Id = 1
            };
            await PostAsync<CreateMessageDetailDto, CreateMessageDetailDto>("/MessagesDetail/Create", messageDetail);
            var singleMessageDetail = await PostAsync<IntId, ApiResponseEnvelope<GetMessageDetailDto>>("/MessagesDetail/GetSingle", messageDetailId);

            //Assert
            Assert.Equal(singleMessageDetail.Data.Id, 1);
        }
        
        
        [Fact]
        public async void GetListUpdateMessageDetailState_MessageDetailDto_ShouldGetListMessageDetail()
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

            var messagesHolders = await PostAsync<GetMessageHolderDto, ApiResponseEnvelope<ICollection<GetMessageHolderDto>>>("/MessagesHolder/GetList", null);
            var messageHolderId_1 = messagesHolders.Data.FirstOrDefault().Id;
            var messageHolderId_2 = messagesHolders.Data.Where(x=>x.RetryCount==5).FirstOrDefault().Id;
            var messageHolderId_3 = messagesHolders.Data.Where(x=>x.RetryCount==3).FirstOrDefault().Id;
           
            var messageDetails = new List<CreateMessageDetailDto>()
            {
                new CreateMessageDetailDto(){MessagesHolderId = messageHolderId_1,ProviderResult =2,Receptor = "sample1",SendDateTime = DateTime.Now,SmsCount = 1,Text = "sample1 Text"},
                new CreateMessageDetailDto(){MessagesHolderId = messageHolderId_2,ProviderResult = 3,Receptor = "sample2",SendDateTime = DateTime.Now,SmsCount = 1,Text = "sample2 Text"},
                new CreateMessageDetailDto(){MessagesHolderId = messageHolderId_3,ProviderResult = 4,Receptor = "sample3",SendDateTime = DateTime.Now,SmsCount = 1,Text = "sample3 Text"},
            };

            foreach (var item in messageDetails)
            {
                await PostAsync<CreateMessageDetailDto, CreateMessageDetailDto>("/MessagesDetail/Create", item);
            }
            var messageDetailList = await PostAsync<GetMessageDetailDto, ApiResponseEnvelope<ICollection<GetMessageDetailDto>>>("/MessagesDetail/GetList", null);

            //Assert
            Assert.Equal(messageDetailList.Data.Count, 3);
        }
    }
}
