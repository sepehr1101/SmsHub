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
                Title = "Create Test Sample title"
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
                Title = "Delete Test Sample title"
            };
            await PostAsync<CreateContactDto, CreateContactDto>("/Contact/Create", contact);
            var contactData = await PostAsync<GetContactDto, ApiResponseEnvelope<ICollection<GetContactDto>>>("/Contact/GetList", null);
            
            var deleteContact = new DeleteContactDto()
            {
                Id = contactData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
            };

            //Act
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
                Title = "Update Test Sample title"
            };
            await PostAsync<CreateContactDto, CreateContactDto>("/Contact/Create", contact);
            var contactData = await PostAsync<GetContactDto, ApiResponseEnvelope<ICollection<GetContactDto>>>("/Contact/GetList", null);

            var updateContact = new UpdateContactDto()
            {
                Id = contactData.Data.OrderByDescending(x=>x.Id).FirstOrDefault().Id,
                Title = "Update Title"
            };

            //Act
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
                Title = "GetSingle Test Sample title"
            };
            await PostAsync<CreateContactDto, CreateContactDto>("/Contact/Create", contact);
            var contactData = await PostAsync<GetContactDto, ApiResponseEnvelope<ICollection<GetContactDto>>>("/Contact/GetList", null);

            var contactId = new IntId()
            {
                Id = contactData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
            };

            //Act
            var singleContact = await PostAsync<IntId, ApiResponseEnvelope<GetContactDto>>("/Contact/GetSingle", contactId);

            //Assert
            Assert.Equal(singleContact.Data.Id, contactId.Id);
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
            Assert.InRange(contactList.Data.Count, 3,7);
        }
    }
}
