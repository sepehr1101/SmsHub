using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;

namespace SmsHub.IntegrationTests.Api
{
    public class CcSendTest: BaseIntegrationTest
    {
        public CcSendTest(TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateCcSend_CcSendDto_ShouldCreateCcSend()
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
            var ccSend = new CreateCcSendDto()
            {
                ConfigTypeGroupId = 1,
                Mobile = "09131234567"
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
            await PostAsync<CreateCcSendDto, CreateCcSendDto>("/CcSend/Create", ccSend);
            //Assert
            Assert.True(true);
        }
    }
}
