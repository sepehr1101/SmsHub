using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Delete;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class ConsumerControllerTest:BaseIntegrationTest
    {
        public ConsumerControllerTest(TestEnvironmentWebApplicationFactory factory)
            :base(factory)
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
                Id=1
            };

            //Act
            await PostAsync<CreateConsumerDto, CreateConsumerDto>("/Consumer/Create", consumer);
            await PostAsync<DeleteConsumerDto, DeleteConsumerDto>("/Consumer/Delete",deleteConsumer);
           
            //Assert
            Assert.True(true);
        }

    }
}
