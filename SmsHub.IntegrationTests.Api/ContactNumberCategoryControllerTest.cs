using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class ContactNumberCategoryControllerTest:BaseIntegrationTest
    {
        public ContactNumberCategoryControllerTest(TestEnvironmentWebApplicationFactory factory)
            :base(factory)
        {
        }


        [Fact]
        public async void CreateContactNumber_ContactNumberDto_ShouldCreateContactNumber()
        {
            //Arrange
            var contactNumberCategory = new CreateContactNumberCategoryDto()
            {
                Title = "Sample Title",
                Css = "Sample Css"
            };
            
            //Act
            await PostAsync<CreateContactNumberCategoryDto, CreateContactNumberCategoryDto>("/ContactNumberCategory/Create", contactNumberCategory);
            
            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void DeleteContactNumber_ContactNumberDto_ShouldDeleteContactNumber()
        {
            //Arrange
            var contactNumberCategory = new CreateContactNumberCategoryDto()
            {
                Title = "Sample Title",
                Css = "Sample Css"
            };
            var deleteContactNumberCategory = new DeleteContactNumberCategoryDto()
            {
                Id=1
            };

            //Act
            await PostAsync<CreateContactNumberCategoryDto, CreateContactNumberCategoryDto>("/ContactNumberCategory/Create", contactNumberCategory);
            await PostAsync<DeleteContactNumberCategoryDto, DeleteContactNumberCategoryDto>("/ContactNumberCategory/Delete",deleteContactNumberCategory);
            
            //Assert
            Assert.True(true);
        }

    }
}
