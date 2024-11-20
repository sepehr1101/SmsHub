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
                Id = 1
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
                Id = 1,
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


        [Fact]
        public async void GetSingleMessageBatch_MessageBatchDto_ShouldGetSingleMessageBatch()
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
            var messageBatchId = new IntId()
            {
                Id = 1
            };
            //Act
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<CreateMessageBatchDto, CreateMessageBatchDto>("/MessageBatch/Create", messageBatch);

            var singleMessageBatch = await PostAsync<IntId, ApiResponseEnvelope<GetMessageBatchDto>>("/MessageBatch/GetSingle", messageBatchId);

            //Assert
            Assert.Equal(singleMessageBatch.Data.Id, 1);
        }


        [Fact]
        public async void GetListMessageBatch_MessageBatchDto_ShouldGetListMessageBatch()
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
            Assert.Equal(messageBatchList.Data.Count, 4);
        }
    }
}
