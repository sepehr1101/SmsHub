using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Template.MediatorDtos.Queries;
using SQLitePCL;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class TemplateControllerTest : BaseIntegrationTest
    {
        public TemplateControllerTest(TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }
        [Fact]
        public async void CreateTemplate_TemplateDto_ShouldCreateTemplate()
        {
            //Arrange
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

            //Act
            await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);

            //Assert
            Assert.True(true);
        }

        [Fact]
        public async void DeleteTemplate_TemplateDto_ShouldDeleteTemplate()
        {
            //Arrange
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
            var deleteTemplate = new DeleteTemplateDto()
            {
                Id = 1
            };

            //Act
            await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);

            await PostAsync<DeleteTemplateDto, DeleteTemplateDto>("/Template/Delete", deleteTemplate);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void UpdateTemplate_TemplateDto_ShouldUpdateTemplate()
        {
            //Arrange
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
            var updateTemplate = new UpdateTemplateDto()
            {
                Id = 1,
                Expression = "Update Expression",
                Title = "Update Title",
                IsActive = true,
                Parameters = "UpdateParameter",
                MinCredit = 5,
                TemplateCategoryId = 1
            };

            //Act
            await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);

            await PostAsync<UpdateTemplateDto, UpdateTemplateDto>("/Template/Update", updateTemplate);

            //Assert
            Assert.True(true);
        }



        [Fact]
        public async void GetSingleTemplate_TemplateDto_ShouldGetSingleTemplate()
        {
            //Arrange
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
            var templateId = new IntId()
            {
                Id = 1
            };

            //Act
            await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);

            var singleTemplate = await PostAsync<IntId, ApiResponseEnvelope<GetTemplateDto>>("/Template/GetSingle", templateId);

            //Assert
            Assert.Equal(singleTemplate.Data.Title, "Sample Title");
        }

        [Fact]
        public async void GetListTemplate_TemplateDto_ShouldGetListTemplate()
        {
            //Arrange
            var templateCategories = new List<CreateTemplateCategoryDto>()
            {
                new CreateTemplateCategoryDto(){ Title = "First TemplateCategory",Description = "Sample1 Sentence"},
                new CreateTemplateCategoryDto(){ Title = "Second TemplateCategory",Description = "Sample2 Sentence"},
                new CreateTemplateCategoryDto(){ Title = "Third TemplateCategory",Description = "Sample3 Sentence"},
            };
            var templates = new List<CreateTemplateDto>()
            {
                new CreateTemplateDto(){ Expression = "Sample1 Expression",Title = "Sample1 Title",IsActive = true,Parameters = "Sample1 Parameter",MinCredit = 2,TemplateCategoryId = 1},
                new CreateTemplateDto(){ Expression = "Sample2 Expression",Title = "Sample2 Title",IsActive = true,Parameters = "Sample2 Parameter",MinCredit = 10,TemplateCategoryId = 2},
                new CreateTemplateDto(){ Expression = "Sample3 Expression",Title = "Sample3 Title",IsActive = true,Parameters = "Sample3 Parameter",MinCredit = 5,TemplateCategoryId = 2},
                new CreateTemplateDto(){ Expression = "Sample4 Expression",Title = "Sample4 Title",IsActive = true,Parameters = "Sample4 Parameter",MinCredit = 3,TemplateCategoryId = 3},
            };

            //Act
            foreach (var item in templateCategories)
            {
                await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", item);
            }
            foreach (var item in templates)
            {
                await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", item);
            }

            var templateList = await PostAsync<GetTemplateDto, ApiResponseEnvelope<ICollection<GetTemplateDto>>>("/Template/GetList",null);

            //Assert
            Assert.Equal(templateList.Data.Count, 4);
        }
    }
}
