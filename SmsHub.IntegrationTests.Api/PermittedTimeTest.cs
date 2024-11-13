using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;

namespace SmsHub.IntegrationTests.Api
{
    public class PermittedTimeTest:BaseIntegrationTest
    {
        public PermittedTimeTest(TestEnvironmentWebApplicationFactory factory)
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
                FromTime="12:30",
                ToTime="12:40"
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            //Assert
            Assert.True(true);

            //Act
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            //Assert
            Assert.True(true);

            //Act
            await PostAsync<CreatePermittedTimeDto, CreatePermittedTimeDto>("/PermittedTime/Create", permittedTime);
            //Assert
            Assert.True(true);
        }
    }
}
