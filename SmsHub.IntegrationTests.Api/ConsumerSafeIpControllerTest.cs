using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Delete;

//[assembly:CollectionBehavior(DisableTestParallelization =true )]
namespace SmsHub.IntegrationTests.Api
{
    public class ConsumerSafeIpControllerTest:BaseIntegrationTest
    {
        public ConsumerSafeIpControllerTest(TestEnvironmentWebApplicationFactory factory)
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
            await PostAsync<CreateConsumerSafeIpDto, CreateConsumerSafeIpDto>("/ConsumerSafeIp/Create", consumerSafeIp);
            
            //Assert
            Assert.True(true);
        }
        
        
        [Fact]
        public async void DeleteConsumerSafeIp_ConsumerSafeIpDto_ShouldDeleteConsumerSafeIp()
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
            var deleteConsumerSafeIp = new DeleteConsumerSafeIpDto()
            {
                Id=1
            };

            //Act
            await PostAsync<CreateConsumerDto, CreateConsumerDto>("/Consumer/Create", consumer);
            await PostAsync<CreateConsumerSafeIpDto, CreateConsumerSafeIpDto>("/ConsumerSafeIp/Create", consumerSafeIp);

            await PostAsync<DeleteConsumerSafeIpDto, DeleteConsumerSafeIpDto>("/ConsumerSafeIp/Delete", deleteConsumerSafeIp);
            //Assert
            Assert.True(true);
        }
        

        [Fact]
        public async void UpdateConsumerSafeIp_ConsumerSafeIpDto_ShouldUpdateConsumerSafeIp()
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
            var updateConsumerSafeIp = new UpdateConsumerSafeIpDto()
            {
                Id=1,
                ConsumerId=1,
                FromIp="198.162.1.3",
                IsV6=false,
                ToIp="192.168.1.4"
            };

            //Act
            await PostAsync<CreateConsumerDto, CreateConsumerDto>("/Consumer/Create", consumer);
            await PostAsync<CreateConsumerSafeIpDto, CreateConsumerSafeIpDto>("/ConsumerSafeIp/Create", consumerSafeIp);

            await PostAsync<UpdateConsumerSafeIpDto, UpdateConsumerSafeIpDto>("/ConsumerSafeIp/Update", updateConsumerSafeIp);
            //Assert
            Assert.True(true);
        }
    }
}
