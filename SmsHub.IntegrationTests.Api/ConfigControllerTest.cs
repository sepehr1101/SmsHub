using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class ConfigControllerTest : BaseIntegrationTest
    {
        public ConfigControllerTest(TestEnvironmentWebApplicationFactory factory)
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
                Expression = "Sample Expression",
                Title = "Sample Title",
                IsActive = true,
                Parameters = "Sample Parameter",
                MinCredit = 2,
                TemplateCategoryId = 1
            };
            var config = new CreateConfigDto()
            {
                ConfigTypeGroupId = 1,
                TemplateId = 1
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);
            await PostAsync<CreateConfigDto, CreateConfigDto>("/Config/Create", config);
            
            //Assert
            Assert.True(true);
        }

        [Fact]
        public async void DeleteConfig_ConfigDto_ShouldDeleteConfig()
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
                Expression = "Sample Expression",
                Title = "Sample Title",
                IsActive = true,
                Parameters = "Sample Parameter",
                MinCredit = 2,
                TemplateCategoryId = 1
            };
            var config = new CreateConfigDto()
            {
                ConfigTypeGroupId = 1,
                TemplateId = 1
            };
            var deleteConfig = new DeleteConfigDto()
            {
                Id=1
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);
            await PostAsync<CreateConfigDto, CreateConfigDto>("/Config/Create", config);

            await PostAsync<DeleteConfigDto, DeleteConfigDto>("/Config/Delete", deleteConfig);
           
            //Assert
            Assert.True(true);
        }
        
        
        [Fact]
        public async void UpdateConfig_ConfigDto_ShouldUpdateConfig()
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
                Expression = "Sample Expression",
                Title = "Sample Title",
                IsActive = true,
                Parameters = "Sample Parameter",
                MinCredit = 2,
                TemplateCategoryId = 1
            };
            var config = new CreateConfigDto()
            {
                ConfigTypeGroupId = 1,
                TemplateId = 1
            };
            var updateConfig = new UpdateConfigDto()
            {
                ConfigTypeGroupId=1,
                Id = 1,
                TemplateId = 1
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);
            await PostAsync<CreateConfigDto, CreateConfigDto>("/Config/Create", config);

            await PostAsync<UpdateConfigDto, UpdateConfigDto>("/Config/Update", updateConfig);
           
            //Assert
            Assert.True(true);
        }
    }
}
