using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Template.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class ConfigControllerTest : BaseIntegrationTest
    {
        public ConfigControllerTest(_TestEnvironmentWebApplicationFactory factory)
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
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            var configTypeData = await PostAsync<GetConfigTypeDto, ApiResponseEnvelope<ICollection<GetConfigTypeDto>>>("ConfigType/GetList", null);

            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = configTypeData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Title = "First ConfigTypeGroup",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            var configTypeGroupData = await PostAsync<GetConfigTypeGroupDto, ApiResponseEnvelope<ICollection<GetConfigTypeGroupDto>>>("/ConfigTypeGroup/GetList", null);

            var templateCategory = new CreateTemplateCategoryDto()
            {
                Title = "First TemplateCategory",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);
            var templateCategoryData = await PostAsync<GetTemplateCategoryDto, ApiResponseEnvelope<ICollection<GetTemplateCategoryDto>>>("/TemplateCategory/GetList", null);

            var template = new CreateTemplateDto()
            {
                Expression = "Sample Expression",
                Title = "Sample Title",
                IsActive = true,
                MinCredit = 2,
                TemplateCategoryId = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);
            var templateData = await PostAsync<GetTemplateDto, ApiResponseEnvelope<ICollection<GetTemplateDto>>>("/Template/GetList", null);

            var config = new CreateConfigDto()
            {
                ConfigTypeGroupId = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                TemplateId = templateData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };

            //Act
            await PostAsync<CreateConfigDto, CreateConfigDto>("/Config/Create", config);

            var configData = await PostAsync<GetConfigDto, ApiResponseEnvelope<List<GetConfigDto>>>("/Config/GetList", null);

            var deleteConfig = new DeleteConfigDto()
            {
                Id = configData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
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
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            var configTypeData = await PostAsync<GetConfigTypeDto, ApiResponseEnvelope<ICollection<GetConfigTypeDto>>>("ConfigType/GetList", null);

            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = configTypeData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Title = "First ConfigTypeGroup",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            var configTypeGroupData = await PostAsync<GetConfigTypeGroupDto, ApiResponseEnvelope<ICollection<GetConfigTypeGroupDto>>>("/ConfigTypeGroup/GetList", null);

            var templateCategory = new CreateTemplateCategoryDto()
            {
                Title = "First TemplateCategory",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);
            var templateCategoryData = await PostAsync<GetTemplateCategoryDto, ApiResponseEnvelope<ICollection<GetTemplateCategoryDto>>>("/TemplateCategory/GetList", null);

            var template = new CreateTemplateDto()
            {
                Expression = "Sample Expression",
                Title = "Sample Title",
                IsActive = true,
                MinCredit = 2,
                TemplateCategoryId = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);
            var templateData = await PostAsync<GetTemplateDto, ApiResponseEnvelope<ICollection<GetTemplateDto>>>("/Template/GetList", null);

            var config = new CreateConfigDto()
            {
                ConfigTypeGroupId = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                TemplateId = templateData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateConfigDto, CreateConfigDto>("/Config/Create", config);
            var configData = await PostAsync<GetConfigDto, ApiResponseEnvelope<List<GetConfigDto>>>("/Config/GetList", null);

            var updateConfig = new UpdateConfigDto()
            {
                Id = configData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                ConfigTypeGroupId = 1,
                TemplateId = 1
            };
            await PostAsync<UpdateConfigDto, UpdateConfigDto>("/Config/Update", updateConfig);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void GetSingleConfig_ConfigDto_ShouldGetSingleConfig()
        {
            //Arrange
            var configType = new CreateConfigTypeDto()
            {
                Title = "First Config",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            var configTypeData = await PostAsync<GetConfigTypeDto, ApiResponseEnvelope<ICollection<GetConfigTypeDto>>>("ConfigType/GetList", null);

            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = configTypeData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Title = "First ConfigTypeGroup",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            var configTypeGroupData = await PostAsync<GetConfigTypeGroupDto, ApiResponseEnvelope<ICollection<GetConfigTypeGroupDto>>>("/ConfigTypeGroup/GetList", null);

            var templateCategory = new CreateTemplateCategoryDto()
            {
                Title = "First TemplateCategory",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);
            var templateCategoryData = await PostAsync<GetTemplateCategoryDto, ApiResponseEnvelope<ICollection<GetTemplateCategoryDto>>>("/TemplateCategory/GetList", null);

            var template = new CreateTemplateDto()
            {
                Expression = "Sample Expression",
                Title = "Sample Title for Test1230",
                IsActive = true,
                MinCredit = 2,
                TemplateCategoryId = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);
            var templateData = await PostAsync<GetTemplateDto, ApiResponseEnvelope<ICollection<GetTemplateDto>>>("/Template/GetList", null);

            var config = new CreateConfigDto()
            {
                ConfigTypeGroupId = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                TemplateId = templateData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateConfigDto, CreateConfigDto>("/Config/Create", config);
            var configData = await PostAsync<GetConfigDto, ApiResponseEnvelope<List<GetConfigDto>>>("/Config/GetList", null);

            var configId = new IntId()
            {
                Id = configData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
            };


            var singleConfig = await PostAsync<IntId, ApiResponseEnvelope<GetConfigDto>>("/Config/GetSingle", configId);

            //Assert
            Assert.Equal(singleConfig.Data.Id,configId.Id );
        }


        [Fact]
        public async void GetListConfig_ConfigDto_ShouldGetListConfig()
        {
            //Arrange
            var configType = new List<CreateConfigTypeDto>()
            {
                new CreateConfigTypeDto(){Title = "First Config", Description = "Sample1 Sentence"},
                new CreateConfigTypeDto(){Title = "Second Config", Description = "Sample2 Sentence"},
                new CreateConfigTypeDto(){Title = "Third Config", Description = "Sample3 Sentence"},
            };
            var configTypeGroup = new List<CreateConfigTypeGroupDto>()
            {
                new CreateConfigTypeGroupDto(){ConfigTypeId = 1,Title = "First ConfigTypeGroup",Description = "Sample1 Sentence"},
                new CreateConfigTypeGroupDto(){ConfigTypeId = 2,Title = "Second ConfigTypeGroup",Description = "Sample2 Sentence"},
                new CreateConfigTypeGroupDto(){ConfigTypeId = 2,Title = "Third ConfigTypeGroup",Description = "Sample3 Sentence"},
                new CreateConfigTypeGroupDto(){ConfigTypeId = 3,Title = "Forth ConfigTypeGroup",Description = "Sample4 Sentence"},
            };
            var templateCategory = new List<CreateTemplateCategoryDto>()
            {
                new CreateTemplateCategoryDto(){Title = "First TemplateCategory",Description = "Sample1 Sentence"},
                new CreateTemplateCategoryDto(){Title = "Second TemplateCategory",Description = "Sample2 Sentence"},
                new CreateTemplateCategoryDto(){Title = "Third TemplateCategory",Description = "Sample3 Sentence"},
            };
            var template = new List<CreateTemplateDto>()
            {
                new CreateTemplateDto(){Expression = "Sample1 Expression",Title = "Sample1 Title",IsActive = true,MinCredit = 2,TemplateCategoryId = 1},
                new CreateTemplateDto(){Expression = "Sample2 Expression",Title = "Sample2 Title",IsActive = true,MinCredit = 2,TemplateCategoryId = 2},
                new CreateTemplateDto(){Expression = "Sample3 Expression",Title = "Sample3 Title",IsActive = true,MinCredit = 2,TemplateCategoryId = 3},
                new CreateTemplateDto(){Expression = "Sample4 Expression",Title = "Sample4 Title",IsActive = true,MinCredit = 2,TemplateCategoryId = 3},
            };
            var config = new List<CreateConfigDto>()
            {
                new CreateConfigDto(){ConfigTypeGroupId = 1,TemplateId = 3},
                new CreateConfigDto(){ConfigTypeGroupId = 2,TemplateId = 2},
                new CreateConfigDto(){ConfigTypeGroupId = 3,TemplateId = 2},
                new CreateConfigDto(){ConfigTypeGroupId = 4,TemplateId = 3},
            };

            //Act
            foreach (var item in configType)
            {
                await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", item);
            }
            foreach (var item in configTypeGroup)
            {
                await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", item);
            }
            foreach (var item in templateCategory)
            {
                await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", item);
            }
            foreach (var item in template)
            {
                await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", item);
            }
            foreach (var item in config)
            {
                await PostAsync<CreateConfigDto, CreateConfigDto>("/Config/Create", item);
            }

            var configList = await PostAsync<GetConfigDto, ApiResponseEnvelope<ICollection<GetConfigDto>>>("/Config/GetList", null);

            //Assert
            Assert.InRange(configList.Data.Count, 4, 8);
        }
    }
}
