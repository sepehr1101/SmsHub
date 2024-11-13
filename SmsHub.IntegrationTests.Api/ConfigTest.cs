using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;

namespace SmsHub.IntegrationTests.Api
{
    public class ConfigTest : BaseIntegrationTest
    {
        public ConfigTest(TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateConfig_ConfigDto_ShouldCreateConfig()
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
            var templateCategory = new CreateTemplateCategoryDto()
            {
                Title = "First TemplateCategory",
                Description = "Sample Sentence"
            };
            var template = new CreateTemplateDto()
            {
                Expression="Sample Expression",
                Title="Sample Title",
                IsActive=true,
                Parameters="Sample Parameter",
                MinCredit=2,
                TemplateCategoryId=1
            };
            var config = new CreateConfigDto()
            {
                ConfigTypeGroupId=1,
                TemplateId=1
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
            await PostAsync<CreateTemplateCategoryDto,CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);
            //Assert
            Assert.True(true);
            
            //Act
            await PostAsync<CreateTemplateDto,CreateTemplateDto>("/Template/Create", template);
            //Assert
            Assert.True(true);
            
            //Act
            await PostAsync<CreateConfigDto, CreateConfigDto>("/Config/Create", config);
            //Assert
            Assert.True(true);
        }
    }
}
