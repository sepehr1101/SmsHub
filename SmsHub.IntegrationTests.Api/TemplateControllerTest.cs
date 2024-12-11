using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Template.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class TemplateControllerTest : BaseIntegrationTest
    {
        public TemplateControllerTest(_TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }
        [Fact]
        public async void CreateTemplate_TemplateDto_ShouldCreateTemplate()
        {
            //Arrange
            var templateCategory = new CreateTemplateCategoryDto()
            {
                Title = "sample TemplateCategory",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);
            var templateCategoryData = await PostAsync<GetTemplateCategoryDto, ApiResponseEnvelope<ICollection<GetTemplateCategoryDto>>>("/TemplateCategory/GetList", null);

            var template = new CreateTemplateDto()
            {
                Expression = "this is a sample template by {UserName} and {Mobile} prop",
                Title = "Sample Title",
                IsActive = true,
                MinCredit = 2,
                TemplateCategoryId = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };

            //Act
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
                Title = "sample TemplateCategory",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);
            var templateCategoryData = await PostAsync<GetTemplateCategoryDto, ApiResponseEnvelope<ICollection<GetTemplateCategoryDto>>>("/TemplateCategory/GetList", null);

            var template = new CreateTemplateDto()
            {
                Expression = "this is a sample template by {UserName} and {Mobile} prop",
                Title = "Sample Title",
                IsActive = true,
                MinCredit = 2,
                TemplateCategoryId = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);
            var templateData = await PostAsync<GetTemplateDto, ApiResponseEnvelope<ICollection<GetTemplateDto>>>("/Template/GetList", null);

            var deleteTemplate = new DeleteTemplateDto()
            {
                Id = templateData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };

            //Act
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
                Title = "sample TemplateCategory",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);
            var templateCategoryData = await PostAsync<GetTemplateCategoryDto, ApiResponseEnvelope<ICollection<GetTemplateCategoryDto>>>("/TemplateCategory/GetList", null);

            var template = new CreateTemplateDto()
            {
                Expression = "this is a sample template by {UserName} and {Mobile} prop",
                Title = "Sample Title",
                IsActive = true,
                MinCredit = 2,
                TemplateCategoryId = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);
            var templateData = await PostAsync<GetTemplateDto, ApiResponseEnvelope<ICollection<GetTemplateDto>>>("/Template/GetList", null);

            var updateTemplate = new UpdateTemplateDto()
            {
                Id = templateData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Expression = "Update Expression",
                Title = "Update Title",
                IsActive = true,
                MinCredit = 5,
                TemplateCategoryId = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };

            //Act
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
                Title = "sample TemplateCategory",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);
            var templateCategoryData = await PostAsync<GetTemplateCategoryDto, ApiResponseEnvelope<ICollection<GetTemplateCategoryDto>>>("/TemplateCategory/GetList", null);

            var template = new CreateTemplateDto()
            {
                Expression = "this is a sample template by {UserName} and {Mobile} prop",
                Title = "Sample GetSingle Title",
                IsActive = true,
                MinCredit = 2,
                TemplateCategoryId = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);
            var templateData = await PostAsync<GetTemplateDto, ApiResponseEnvelope<ICollection<GetTemplateDto>>>("/Template/GetList", null);

            IntId templateId = templateData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            //Act
            var singleTemplate = await PostAsync<IntId, ApiResponseEnvelope<GetTemplateDto>>("/Template/GetSingle", templateId);

            //Assert
            Assert.Equal(singleTemplate.Data.Title, "Sample GetSingle Title");
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
                new CreateTemplateDto(){ Expression =  "this is a First sample template by {UserName} and {Mobile} prop",Title = "Sample1 Title",IsActive = true,MinCredit = 2,TemplateCategoryId = 1},
                new CreateTemplateDto(){ Expression =  "this is a Second sample template by {UserName} and {Mobile} prop",Title = "Sample2 Title",IsActive = true,MinCredit = 10,TemplateCategoryId = 2},
                new CreateTemplateDto(){ Expression =  "this is a Third sample template by {UserName} and {Mobile} prop",Title = "Sample3 Title",IsActive = true,MinCredit = 5,TemplateCategoryId = 2},
                new CreateTemplateDto(){ Expression =  "this is a Forth sample template by {UserName} and {Mobile} prop",Title = "Sample4 Title",IsActive = true,MinCredit = 3,TemplateCategoryId = 3},
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

            var templateList = await PostAsync<GetTemplateDto, ApiResponseEnvelope<ICollection<GetTemplateDto>>>("/Template/GetList", null);

            //Assert
            Assert.InRange(templateList.Data.Count, 4, 8);
        }
    }
}
