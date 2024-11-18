using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class ConsumerLineControllerTest : BaseIntegrationTest
    {
        public ConsumerLineControllerTest(TestEnvironmentWebApplicationFactory factory)
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
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<CreateConsumerLineDto, CreateConsumerLineDto>("/ConsumerLine/Create", consumerLine);
          
            //Assert
            Assert.True(true);
            
        }


        [Fact]
        public async void DeleteConsumerLine_ConsumerLineDto_ShouldDeleteConsumerLine()
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
            var deleteConsumerLine = new DeleteConsumerLineDto()
            {
                Id=1
            };

            //Act
            await PostAsync<CreateConsumerDto, CreateConsumerDto>("/Consumer/Create", consumer);
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<CreateConsumerLineDto, CreateConsumerLineDto>("/ConsumerLine/Create", consumerLine);

            await PostAsync<DeleteConsumerLineDto, DeleteConsumerLineDto>("/ConsumerLine/Delete", deleteConsumerLine);
            //Assert
            Assert.True(true);
            
        }
        
        
        [Fact]
        public async void UpdateConsumerLine_ConsumerLineDto_ShouldUpdateConsumerLine()
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
           var updateConsumerLine = new UpdateConsumerLineDto()
           {
               Id=1,
               ConsumerId=1,
               LineId=1,    
           };

            //Act
            await PostAsync<CreateConsumerDto, CreateConsumerDto>("/Consumer/Create", consumer);
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            await PostAsync<CreateConsumerLineDto, CreateConsumerLineDto>("/ConsumerLine/Create", consumerLine);

            await PostAsync<UpdateConsumerLineDto, UpdateConsumerLineDto>("/ConsumerLine/Update", updateConsumerLine);
            //Assert
            Assert.True(true);
            
        }
    }
}
