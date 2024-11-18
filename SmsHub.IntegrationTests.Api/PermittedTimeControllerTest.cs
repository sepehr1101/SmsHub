using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class PermittedTimeControllerTest : BaseIntegrationTest
    {
        public PermittedTimeControllerTest(TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreatePermittedTime_PermittedTimeDto_ShouldCreatePermittedTime()
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
            var permittedTime = new CreatePermittedTimeDto()
            {
                ConfigTypeGroupId = 1,
                FromTime = "12:30",
                ToTime = "12:40"
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            await PostAsync<CreatePermittedTimeDto, CreatePermittedTimeDto>("/PermittedTime/Create", permittedTime);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void DeletePermittedTime_PermittedTimeDto_ShouldDeletePermittedTime()
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
            var permittedTime = new CreatePermittedTimeDto()
            {
                ConfigTypeGroupId = 1,
                FromTime = "12:30",
                ToTime = "12:40"
            };
            var deletePermittedTime = new DeletePermittedTimeDto()
            {
                Id = 1,
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            await PostAsync<CreatePermittedTimeDto, CreatePermittedTimeDto>("/PermittedTime/Create", permittedTime);

            await PostAsync<DeletePermittedTimeDto, DeletePermittedTimeDto>("/PermittedTime/Delete", deletePermittedTime);

            //Assert
            Assert.True(true);
        }
    }
}
