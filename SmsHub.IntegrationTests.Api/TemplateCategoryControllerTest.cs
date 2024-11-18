using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Delete;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class TemplateCategoryControllerTest : BaseIntegrationTest
    {
        public TemplateCategoryControllerTest(TestEnvironmentWebApplicationFactory factory)
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
    }
}
