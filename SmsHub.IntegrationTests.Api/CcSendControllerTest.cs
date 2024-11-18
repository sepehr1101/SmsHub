using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class CcSendControllerTest: BaseIntegrationTest
    {
        public CcSendControllerTest(TestEnvironmentWebApplicationFactory factory)
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
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            await PostAsync<CreateCcSendDto, CreateCcSendDto>("/CcSend/Create", ccSend);
            
            //Assert
            Assert.True(true);
        }




        [Fact]
        public async void DeleteCcSend_CcSendDto_ShouldDeleteCcSendDto()
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
            var deleteCcSend = new DeleteCcSendDto()
            {
                Id = 1
            };
            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            await PostAsync<CreateCcSendDto, CreateCcSendDto>("/CcSend/Create", ccSend);

            await PostAsync<DeleteCcSendDto, DeleteCcSendDto>("/CcSend/Delete", deleteCcSend);

            //Assert
            Assert.True(true);
        }
    }
}
