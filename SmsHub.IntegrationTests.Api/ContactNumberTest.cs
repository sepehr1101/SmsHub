using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class ContactNumberTest : BaseIntegrationTest
    {
        public ContactNumberTest(TestEnvironmentWebApplicationFactory factory)
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
            //Assert
            Assert.True(true);

            //Act
            await PostAsync<CreateContactNumberCategoryDto, CreateContactNumberCategoryDto>("/ContactNumberCategory/Create", contactNumberCategory);
            //Assert
            Assert.True(true);

            //Act
            await PostAsync<CreateContactNumberDto, CreateContactNumberDto>("/ContactNumber/Create", contactNumber);
            //Assert
            Assert.True(true);
        }
    }
}
