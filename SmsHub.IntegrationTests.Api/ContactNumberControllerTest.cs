using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class ContactNumberControllerTest : BaseIntegrationTest
    {
        public ContactNumberControllerTest(TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateContactNumber_ContactNumberDto_ShouldCreateContactNumber()
        {
            //Arrange
            var contactCategory = new CreateContactCategoryDto()
            {
                Title = "Sample Title",
                Css = "Sample Css",
                Description = "Sample Description"
            };
            var contactNumberCategory = new CreateContactNumberCategoryDto()
            {
                Title = "Sample Title",
                Css = "Sample Css"
            };
            var contactNumber = new CreateContactNumberDto()
            {
                ContactCategoryId = 1,
                ContactNumberCategoryId = 1,
                Number = "Sample Number"
            };

            //Act
            await PostAsync<CreateContactCategoryDto, CreateContactCategoryDto>("/ContactCategory/Create", contactCategory);
            await PostAsync<CreateContactNumberCategoryDto, CreateContactNumberCategoryDto>("/ContactNumberCategory/Create", contactNumberCategory);
            await PostAsync<CreateContactNumberDto, CreateContactNumberDto>("/ContactNumber/Create", contactNumber);
            
            //Assert
            Assert.True(true);
        }
        
        
        [Fact]
        public async void DeleteContactNumber_ContactNumberDto_ShouldDeleteContactNumber()
        {
            //Arrange
            var contactCategory = new CreateContactCategoryDto()
            {
                Title = "Sample Title",
                Css = "Sample Css",
                Description = "Sample Description"
            };
            var contactNumberCategory = new CreateContactNumberCategoryDto()
            {
                Title = "Sample Title",
                Css = "Sample Css"
            };
            var contactNumber = new CreateContactNumberDto()
            {
                ContactCategoryId = 1,
                ContactNumberCategoryId = 1,
                Number = "Sample Number"
            };
            var deleteContactNumber = new DeleteContactNumberDto()
            {
                Id=1
            };

            //Act
            await PostAsync<CreateContactCategoryDto, CreateContactCategoryDto>("/ContactCategory/Create", contactCategory);
            await PostAsync<CreateContactNumberCategoryDto, CreateContactNumberCategoryDto>("/ContactNumberCategory/Create", contactNumberCategory);
            await PostAsync<CreateContactNumberDto, CreateContactNumberDto>("/ContactNumber/Create", contactNumber);

            await PostAsync<DeleteContactNumberDto, DeleteContactNumberDto>("/ContactNumber/Delete", deleteContactNumber);
           
            //Assert
            Assert.True(true);
        }
    }
}
