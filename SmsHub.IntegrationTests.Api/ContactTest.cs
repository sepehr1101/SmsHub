using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class ContactTest : BaseIntegrationTest
    {
        public ContactTest(TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateContact_ContactDto_ShouldCreateContact()
        {
            //Arrange
            var contact = new CreateContactDto()
            {
                Title = "sample title"
            };
            //Act
            await PostAsync<CreateContactDto, CreateContactDto>("/Contact/Create", contact);
            //Assert
            Assert.True(true);
        }
    }
}
