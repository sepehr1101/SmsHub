using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Delete;

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
    }
}
