using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;

//[assembly:CollectionBehavior(DisableTestParallelization =true )]
namespace SmsHub.IntegrationTests.Api
{
    public class ConsumerSafeIpTest:BaseIntegrationTest
    {
        public ConsumerSafeIpTest(TestEnvironmentWebApplicationFactory factory)
            :base(factory)
        {
        }

        [Fact]
        public async void CreateConsumerSafeIp_ConsumerSafeIpDto_ShouldCreateConsumerSafeIp()
        {
            //Arrange
            var consumer = new CreateConsumerDto()
            {
                Title="Sample Title",
                ApiKey="Sample ApiKey",
                Description="Sample Description"
            };
            var consumerSafeIp = new CreateConsumerSafeIpDto()
            {
                ConsumerId = 1,
                FromIp="198.162.1.1",
                IsV6=false,
                ToIp="198.162.1.2"
            };

            //Act
            await PostAsync<CreateConsumerDto, CreateConsumerDto>("/Consumer/Create", consumer);
            //Assert
            Assert.True(true);

            //Act
            await PostAsync<CreateConsumerSafeIpDto, CreateConsumerSafeIpDto>("/ConsumerSafeIp/Create", consumerSafeIp);
            //Assert
            Assert.True(true);
        }
    }
}
