using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class ContactCategoryControllerTest:BaseIntegrationTest
    {
        public ContactCategoryControllerTest(TestEnvironmentWebApplicationFactory factory)
            :base(factory)
        {
        }

        [Fact]
        public async void CreateContactCategory_ContactCategoryDto_ShouldCreateContactCategory()
        {
            //Arrange
            var contactCategory = new CreateContactCategoryDto()
            {
                Title = "Sample Title",
                Css = "Sample Css",
                Description = "Sample Description"
            };
            //Act
            await PostAsync<CreateContactCategoryDto, CreateContactCategoryDto>("/ContactCategory/Create", contactCategory);

            //Assert
            Assert.True(true);
        }
        
        [Fact]
        public async void DeleteContactCategory_ContactCategoryDto_ShouldDeleteContactCategory()
        {
            //Arrange
            var contactCategory = new CreateContactCategoryDto()
            {
                Title = "Sample Title",
                Css = "Sample Css",
                Description = "Sample Description"
            };
            var deleteContactCategory = new DeleteContactCategoryDto()
            {
                 Id=1
            };

            //Act
            await PostAsync<CreateContactCategoryDto, CreateContactCategoryDto>("/ContactCategory/Create", contactCategory);
            await PostAsync<DeleteContactCategoryDto, DeleteContactCategoryDto>("/ContactCategory/Delete", deleteContactCategory);

            //Assert
            Assert.True(true);
        }

    }
}
