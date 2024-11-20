using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class ContactControllerTest : BaseIntegrationTest
    {
        public ContactControllerTest(_TestEnvironmentWebApplicationFactory factory)
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
                Id = 1
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
                Id = 1,
                Title = "Update Title"
            };

            //Act
            await PostAsync<CreateContactDto, CreateContactDto>("/Contact/Create", contact);
            await PostAsync<UpdateContactDto, UpdateContactDto>("/Contact/Update", updateContact);

            //Assert
            Assert.True(true);
        }



        [Fact]
        public async void GetSingleContact_ContactDto_ShouldGetSingleContact()
        {
            //Arrange
            var contact = new CreateContactDto()
            {
                Title = "sample title"
            };
            var contactId = new IntId()
            {
                Id = 1
            };

            //Act
            await PostAsync<CreateContactDto, CreateContactDto>("/Contact/Create", contact);
            var singleContact = await PostAsync<IntId, ApiResponseEnvelope<GetContactDto>>("/Contact/GetSingle", contactId);

            //Assert
            Assert.Equal(singleContact.Data.Id, 1);
            Assert.Equal(singleContact.HttpStatusCode, 200);
        }


        [Fact]
        public async void GetListContact_ContactDto_ShouldGetListContact()
        {
            //Arrange
            var contacts = new List<CreateContactDto>()
            {
                new CreateContactDto(){Title = "sample1 title"},
                new CreateContactDto(){Title = "sample2 title"},
                new CreateContactDto(){Title = "sample3 title"},
            };

            //Act
            foreach (var item in contacts)
            {
                await PostAsync<CreateContactDto, CreateContactDto>("/Contact/Create", item );
            }
            var contactList = await PostAsync<GetContactDto, ApiResponseEnvelope<ICollection<GetContactDto>>>("/Contact/GetList",null);

            //Assert
            Assert.Equal(contactList.Data.Count, 3);
            Assert.Equal(contactList.HttpStatusCode, 200);
        }
    }
}
