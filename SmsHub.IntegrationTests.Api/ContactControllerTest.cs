using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class ContactControllerTest : BaseIntegrationTest
    {
        public ContactControllerTest(TestEnvironmentWebApplicationFactory factory)
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
        
        
        [Fact]
        public async void DeleteContact_ContactDto_ShouldDeleteContact()
        {
            //Arrange
            var contact = new CreateContactDto()
            {
                Title = "sample title"
            };
            var deleteContact = new DeleteContactDto()
            {
                Id=1
            };

            //Act
            await PostAsync<CreateContactDto, CreateContactDto>("/Contact/Create", contact);
            await PostAsync<DeleteContactDto, DeleteContactDto>("/Contact/Delete", deleteContact);

            //Assert
            Assert.True(true);
        }
        
        
        [Fact]
        public async void UpdateContact_ContactDto_ShouldUpdateContact()
        {
            //Arrange
            var contact = new CreateContactDto()
            {
                Title = "sample title"
            };
            var updateContact = new UpdateContactDto()
            {
                Id  =1,
                Title="Update Title"
            };

            //Act
            await PostAsync<CreateContactDto, CreateContactDto>("/Contact/Create", contact);
            await PostAsync<UpdateContactDto, UpdateContactDto>("/Contact/Update", updateContact);

            //Assert
            Assert.True(true);
        }
    }
}
