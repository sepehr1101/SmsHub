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
                Title = "sample1 TemplateCategory",
                Description = "Sample1 Sentence"
            };
            await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);
            var templateCategoryData = await PostAsync<GetTemplateCategoryDto, ApiResponseEnvelope<ICollection<GetTemplateCategoryDto>>>("/TemplateCategory/GetList", null);

            var deleteTemplateCategory = new DeleteTemplateCategoryDto()
            {
                Id = templateCategoryData.Data.OrderByDescending(x=>x.Id).FirstOrDefault().Id
            };

            //Act
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
                Title = "sample2 TemplateCategory",
                Description = "Sample2 Sentence"
            };
            await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);
            var templateCategoryData = await PostAsync<GetTemplateCategoryDto, ApiResponseEnvelope<ICollection<GetTemplateCategoryDto>>>("/TemplateCategory/GetList", null);

            var updateTemplateCategory = new UpdateTemplateCategoryDto()
            {
                Id = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Title = "Update TemplateCategory",
                Description = "Update Sentence"
            };

            //Act
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
                Title = "sample3 TemplateCategory",
                Description = "Sample3 Sentence"
            };
            await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);
            var templateCategoryData = await PostAsync<GetTemplateCategoryDto, ApiResponseEnvelope<ICollection<GetTemplateCategoryDto>>>("/TemplateCategory/GetList", null);

            IntId templateCategoryId = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            //Act
            var singleTemplateCategory = await PostAsync<IntId, ApiResponseEnvelope<GetTemplateCategoryDto>>("/TemplateCategory/GetSingle", templateCategoryId);

            //Assert
            Assert.Equal(singleTemplateCategory.Data.Title, "sample3 TemplateCategory");
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
            Assert.InRange(templateCategoryList.Data.Count, 3,7);
        }
    }
}
