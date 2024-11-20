using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Template.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class TemplateCategoryControllerTest : BaseIntegrationTest
    {
        public TemplateCategoryControllerTest(_TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateTemplateCategory_TemplateCategoryDto_ShouldCreateTemplateCategory()
        {
            //Arrange
            var templateCategory = new CreateTemplateCategoryDto()
            {
                Title = "First TemplateCategory",
                Description = "Sample Sentence"
            };

            //Act
            await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void DeleteTemplateCategory_TemplateCategoryDto_ShouldDeleteTemplateCategory()
        {
            //Arrange
            var templateCategory = new CreateTemplateCategoryDto()
            {
                Title = "First TemplateCategory",
                Description = "Sample Sentence"
            };
            var deleteTemplateCategory = new DeleteTemplateCategoryDto()
            {
                Id = 1
            };

            //Act
            await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);
            await PostAsync<DeleteTemplateCategoryDto, DeleteTemplateCategoryDto>("/TemplateCategory/Delete", deleteTemplateCategory);

            //Assert
            Assert.True(true);
        }



        [Fact]
        public async void UpdateTemplateCategory_TemplateCategoryDto_ShouldUpdateTemplateCategory()
        {
            //Arrange
            var templateCategory = new CreateTemplateCategoryDto()
            {
                Title = "First TemplateCategory",
                Description = "Sample Sentence"
            };
            var updateTemplateCategory = new UpdateTemplateCategoryDto()
            {
                Id = 1,
                Title = "Update TemplateCategory",
                Description = "Update Sentence"
            };

            //Act
            await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);
            await PostAsync<UpdateTemplateCategoryDto, UpdateTemplateCategoryDto>("/TemplateCategory/Update", updateTemplateCategory);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void GetSingleTemplateCategory_TemplateCategoryDto_ShouldGetSingleTemplateCategory()
        {
            //Arrange
            var templateCategory = new CreateTemplateCategoryDto()
            {
                Title = "First TemplateCategory",
                Description = "Sample Sentence"
            };
            var templateCategoryId = new IntId()
            {
                Id = 1
            };

            //Act
            await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);
            var singleTemplateCategory = await PostAsync<IntId, ApiResponseEnvelope<GetTemplateCategoryDto>>("/TemplateCategory/GetSingle", templateCategoryId);

            //Assert
            Assert.Equal(singleTemplateCategory.Data.Title, "First TemplateCategory");
        }


        [Fact]
        public async void GetListTemplateCategory_TemplateCategoryDto_ShouldGetListTemplateCategory()
        {
            //Arrange
            var templateCategories = new List<CreateTemplateCategoryDto>()
            {
                new CreateTemplateCategoryDto(){ Title = "First TemplateCategory",Description = "Sample1 Sentence"},
                new CreateTemplateCategoryDto(){ Title = "Second TemplateCategory",Description = "Sample2 Sentence"},
                new CreateTemplateCategoryDto(){ Title = "Third TemplateCategory",Description = "Sample3 Sentence"},
            };

            //Act
            foreach (var item in templateCategories)
            {
                await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", item);
            }
            var templateCategoryList = await PostAsync<GetTemplateCategoryDto, ApiResponseEnvelope<ICollection<GetTemplateCategoryDto>>>("/TemplateCategory/GetList", null);

            //Assert
            Assert.Equal(templateCategoryList.Data.Count, 3);
        }
    }
}
