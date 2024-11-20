using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class ConsumerControllerTest : BaseIntegrationTest
    {
        public ConsumerControllerTest(TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateConsumer_ConsumerDto_ShouldCreateConsumer()
        {
            //Arrange
            var consumer = new CreateConsumerDto()
            {
                Title = "Sample Title",
                ApiKey = "Sample ApiKey",
                Description = "Sample Description"
            };

            //Act
            await PostAsync<CreateConsumerDto, CreateConsumerDto>("/Consumer/Create", consumer);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void DeleteConsumer_ConsumerDto_ShouldDeleteConsumer()
        {
            //Arrange
            var consumer = new CreateConsumerDto()
            {
                Title = "Sample Title",
                ApiKey = "Sample ApiKey",
                Description = "Sample Description"
            };
            var deleteConsumer = new DeleteConsumerDto()
            {
                Id = 1
            };

            //Act
            await PostAsync<CreateConsumerDto, CreateConsumerDto>("/Consumer/Create", consumer);
            await PostAsync<DeleteConsumerDto, DeleteConsumerDto>("/Consumer/Delete", deleteConsumer);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void UpdateConsumer_ConsumerDto_ShouldUpdateConsumer()
        {
            //Arrange
            var consumer = new CreateConsumerDto()
            {
                Title = "Sample Title",
                ApiKey = "Sample ApiKey",
                Description = "Sample Description"
            };
            var updateConsumer = new UpdateConsumerDto()
            {
                Id = 1,
                Title = "Update Title",
                ApiKey = "Update ApiKey",
                Description = "Update Description"
            };

            //Act
            await PostAsync<CreateConsumerDto, CreateConsumerDto>("/Consumer/Create", consumer);
            await PostAsync<UpdateConsumerDto, UpdateConsumerDto>("/Consumer/Update", updateConsumer);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void GetSingleConsumer_ConsumerDto_ShouldGetSingleConsumer()
        {
            //Arrange
            var consumer = new CreateConsumerDto()
            {
                Title = "Sample Title",
                ApiKey = "Sample ApiKey",
                Description = "Sample Description"
            };
            var consumerId = new IntId()
            {
                Id = 1
            };

            //Act
            await PostAsync<CreateConsumerDto, CreateConsumerDto>("/Consumer/Create", consumer);
            var singleConsumer = await PostAsync<IntId, ApiResponseEnvelope<GetConsumerDto>>("/Consumer/GetSingle", consumerId);

            //Assert
            Assert.Equal(singleConsumer.Data.Id, 1);
            Assert.Equal(singleConsumer.HttpStatusCode,200);
        }
        
        [Fact]
        public async void GetListConsumer_ConsumerDto_ShouldGetListConsumer()
        {
            //Arrange
            var consumer = new List<CreateConsumerDto>()
            {
                new CreateConsumerDto(){Title = "Sample1 Title", ApiKey = "Sample1 ApiKey",Description = "Sample1 Description"},
                new CreateConsumerDto(){Title = "Sample2 Title", ApiKey = "Sample2 ApiKey",Description = "Sample2 Description"},
                new CreateConsumerDto(){Title = "Sample3 Title", ApiKey = "Sample3 ApiKey",Description = "Sample3 Description"},
                new CreateConsumerDto(){Title = "Sample4 Title", ApiKey = "Sample4 ApiKey",Description = "Sample4 Description"},
            };

            //Act
            foreach (var item in consumer)
            {
                await PostAsync<CreateConsumerDto, CreateConsumerDto>("/Consumer/Create", item);
            }
            var consumerList = await PostAsync<GetConsumerDto, ApiResponseEnvelope<ICollection<GetConsumerDto>>>("/Consumer/GetList", null);

            //Assert
            Assert.Equal(consumerList.Data.Count, 4);
            Assert.Equal(consumerList.HttpStatusCode,200);
        }

    }
}
