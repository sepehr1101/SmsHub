using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class MessageBatchControllerTest : BaseIntegrationTest
    {
        public MessageBatchControllerTest(_TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateMessageBatch_MessageBatchDto_ShouldDeleteMessageBatch()
        {
            //Arrange
            var line = new CreateLineDto()
            {
                ProviderId = Domain.Constants.ProviderEnum.Kavenegar,
                Credential = "{'apiKey': '---'}",
                Number = "13000"
            };
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);

            var messageBatch = new CreateMessageBatchDto()
            {
                HolerSize = 2,
                AllSize = 4,
                InsertDateTime = DateTime.Now,
                LineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id

            };
            //Act
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
                Credential = "{'apiKey': '---'}",
                Number = "13001"
            };
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);

            var messageBatch = new CreateMessageBatchDto()
            {
                HolerSize = 4,
                AllSize = 8,
                InsertDateTime = DateTime.Now,
                LineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);
            var messageBatchData = await PostAsync<GetMessageBatchDto, ApiResponseEnvelope<ICollection<GetMessageBatchDto>>>("/MessageBatch/GetList", null);

            var deleteMessageBatch = new DeleteMessageBatchDto()
            {
                Id = messageBatchData.Data.OrderByDescending(x=>x.Id).FirstOrDefault().Id
            };

            //Act
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
                Credential = "{'apiKey': '---'}",
                Number = "13002"
            };
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);

            var messageBatch = new CreateMessageBatchDto()
            {
                HolerSize = 4,
                AllSize = 9,
                InsertDateTime = DateTime.Now,
                LineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);
            var messageBatchData = await PostAsync<GetMessageBatchDto, ApiResponseEnvelope<ICollection<GetMessageBatchDto>>>("/MessageBatch/GetList", null);

            var updateMessageBatch = new UpdateMessageBatchDto()
            {
                Id = messageBatchData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                HolerSize = 3,
                AllSize = 4,
                InsertDateTime = DateTime.Now,
                LineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };

            //Act
            await PostAsync<UpdateMessageBatchDto, UpdateMessageBatchDto>("/MessageBatch/Update", updateMessageBatch);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void GetSingleMessageBatch_MessageBatchDto_ShouldGetSingleMessageBatch()
        {
            //Arrange
            var line = new CreateLineDto()
            {
                ProviderId = Domain.Constants.ProviderEnum.Kavenegar,
                Credential = "{'apiKey': '---'}",
                Number = "13004"
            };
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);

            var messageBatch = new CreateMessageBatchDto()
            {
                HolerSize = 4,
                AllSize = 10,
                InsertDateTime = DateTime.Now,
                LineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);
            var messageBatchData = await PostAsync<GetMessageBatchDto, ApiResponseEnvelope<ICollection<GetMessageBatchDto>>>("/MessageBatch/GetList", null);

            IntId messageBatchId = messageBatchData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;
            //Act
            var singleMessageBatch = await PostAsync<IntId, ApiResponseEnvelope<GetMessageBatchDto>>("/MessageBatch/GetSingle", messageBatchId);

            //Assert
            Assert.Equal(singleMessageBatch.Data.Id, messageBatchId.Id);
        }


        [Fact]
        public async void GetListMessageBatch_MessageBatchDto_ShouldGetListMessageBatch()
        {
            //Arrange
            var lines = new List<CreateLineDto>()
            {
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Kavenegar,Credential = "{'apiKey': '---'}",Number = "1180"},
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Magfa,Credential= "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }",Number = "1500"},
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Magfa,Credential= "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }",Number = "1250"},
            };
            var messageBatchs = new List<CreateMessageBatchDto>()
            {
                new CreateMessageBatchDto(){ HolerSize = 12,AllSize = 8,InsertDateTime = DateTime.Now,LineId = 1},
                new CreateMessageBatchDto(){ HolerSize = 5,AllSize = 2,InsertDateTime = DateTime.Now,LineId = 2},
                new CreateMessageBatchDto(){ HolerSize = 8,AllSize = 4,InsertDateTime = DateTime.Now,LineId = 2},
                new CreateMessageBatchDto(){ HolerSize = 3,AllSize = 6,InsertDateTime = DateTime.Now,LineId = 3},
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

            var messageBatchList = await PostAsync<GetMessageBatchDto, ApiResponseEnvelope<ICollection<GetMessageBatchDto>>>("/MessageBatch/GetList", null);

            //Assert
            Assert.InRange(messageBatchList.Data.Count, 4,8);
        }
    }
}
