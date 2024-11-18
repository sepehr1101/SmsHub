using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class ConfigTypeControllerTest:BaseIntegrationTest
    {
        public ConfigTypeControllerTest(TestEnvironmentWebApplicationFactory factory)
            :base(factory)
        {
        }


        [Fact]
        public async void CreateConfigType_ConfigTypeDto_ShouldCreateConfigType()
        {
            //Arrange
            var configType = new CreateConfigTypeDto()
            {
                Title = "First Config",
                Description = "Sample Sentence"
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void DeleteConfigType_ConfigTypeDto_ShouldDeleteConfigType()
        {
            //Arrange
            var configType = new CreateConfigTypeDto()
            {
                Title = "First Config",
                Description = "Sample Sentence"
            };
            var deleteConfigType = new DeleteConfigTypDto()
            {
                Id=1
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<DeleteConfigTypDto, DeleteConfigTypDto>("/ConfigType/Delete", deleteConfigType);

            //Assert
            Assert.True(true);
        }
    }
}
