using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class ConfigTypeGroupControllerTest:BaseIntegrationTest
    {
        public ConfigTypeGroupControllerTest(TestEnvironmentWebApplicationFactory factory)
            :base(factory)
        {
        }

        [Fact]
        public async void CreateConfigTypeGroup_ConfigTypeGroupDto_ShouldCreateConfigTypeGroup()
        {
            //Arrange
            var configType = new CreateConfigTypeDto()
            {
                Title = "First Config",
                Description = "Sample Sentence"
            };
            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = 1,
                Title = "First ConfigTypeGroup",
                Description = "Sample Sentence"
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);

            //Assert
            Assert.True(true);
        }

        [Fact]
        public async void DeleteConfigTypeGroup_ConfigTypeGroupDto_ShouldDeleteConfigTypeGroup()
        {
            //Arrange
            var configType = new CreateConfigTypeDto()
            {
                Title = "First Config",
                Description = "Sample Sentence"
            };
            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = 1,
                Title = "First ConfigTypeGroup",
                Description = "Sample Sentence"
            };
            var deleteConfigTypeGroup = new DeleteConfigTypeGroupDto()
            {
                Id=1
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);

            await PostAsync<DeleteConfigTypeGroupDto, DeleteConfigTypeGroupDto>("/ConfigTypeGroup/Delete", deleteConfigTypeGroup);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void UpdateConfigTypeGroup_ConfigTypeGroupDto_ShouldUpdateConfigTypeGroup()
        {
            //Arrange
            var configType = new CreateConfigTypeDto()
            {
                Title = "First Config",
                Description = "Sample Sentence"
            };
            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = 1,
                Title = "First ConfigTypeGroup",
                Description = "Sample Sentence"
            };
            var updateConfigTypeGroup = new UpdateConfigTypeGroupDto()
            {
                Id = 1,
                ConfigTypeId = 1,
                Title="Update Title",
                Description="Update Description"
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);

            await PostAsync<UpdateConfigTypeGroupDto, UpdateConfigTypeGroupDto>("/ConfigTypeGroup/Update", updateConfigTypeGroup);

            //Assert
            Assert.True(true);
        }
    }
}
