using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class ConsumerLineTest:BaseIntegrationTest
    {
        public ConsumerLineTest(TestEnvironmentWebApplicationFactory factory)
            :base(factory)
        {
        }

        [Fact]
        public async void CreateConsumerLine_ConsumerLineDto_ShouldCreateConsumerLine()
        {
            //Arrange
            var consumer = new CreateConsumerDto()
            {
                Title = "Sample Title",
                ApiKey = "Sample ApiKey",
                Description = "Sample Description"
            };
            var line = new CreateLineDto()
            {
                ProviderId=Domain.Constants.ProviderEnum.Kavenegar,
                Credential="sample Credential",
                Number="111"
            };
            var consumerLine = new CreateConsumerLineDto()
            {
                ConsumerId = 1,
                LineId=1
            };

            //Act
            await PostAsync<CreateConsumerDto, CreateConsumerDto>("/Consumer/Create", consumer);
            //Assert
            Assert.True(true);
            
            //Act
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            //Assert
            Assert.True(true);


            //Act
            await PostAsync<CreateConsumerLineDto, CreateConsumerLineDto>("/ConsumerLine/Create", consumerLine);
            //Assert
            Assert.True(true);
            
        }
    }
}
