using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;

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
                Id = 1
            };

            //Act
            await PostAsync<CreateContactCategoryDto, CreateContactCategoryDto>("/ContactCategory/Create", contactCategory);
            await PostAsync<CreateContactNumberCategoryDto, CreateContactNumberCategoryDto>("/ContactNumberCategory/Create", contactNumberCategory);
            await PostAsync<CreateContactNumberDto, CreateContactNumberDto>("/ContactNumber/Create", contactNumber);

            await PostAsync<DeleteContactNumberDto, DeleteContactNumberDto>("/ContactNumber/Delete", deleteContactNumber);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void UpdateContactNumber_ContactNumberDto_ShouldUpdateContactNumber()
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
            var updateContactNumber = new UpdateContactNumberDto()
            {
                Id = 1,
                ContactCategoryId = 1,
                ContactNumberCategoryId = 1,
                Number = "Update Number"
            };

            //Act
            await PostAsync<CreateContactCategoryDto, CreateContactCategoryDto>("/ContactCategory/Create", contactCategory);
            await PostAsync<CreateContactNumberCategoryDto, CreateContactNumberCategoryDto>("/ContactNumberCategory/Create", contactNumberCategory);
            await PostAsync<CreateContactNumberDto, CreateContactNumberDto>("/ContactNumber/Create", contactNumber);

            await PostAsync<UpdateContactNumberDto, UpdateContactNumberDto>("/ContactNumber/Update", updateContactNumber);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void GetSingleContactNumber_ContactNumberDto_ShouldGetSingleContactNumber()
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
            var contactNumberId = new IntId()
            {
                Id = 1
            };

            //Act
            await PostAsync<CreateContactCategoryDto, CreateContactCategoryDto>("/ContactCategory/Create", contactCategory);
            await PostAsync<CreateContactNumberCategoryDto, CreateContactNumberCategoryDto>("/ContactNumberCategory/Create", contactNumberCategory);
            await PostAsync<CreateContactNumberDto, CreateContactNumberDto>("/ContactNumber/Create", contactNumber);

            var singleContactNumber = await PostAsync<IntId, ApiResponseEnvelope<GetContactNumberDto>>("/ContactNumber/GetSingle", contactNumberId);

            //Assert
            Assert.Equal(singleContactNumber.Data.Id, 1);
            Assert.Equal(singleContactNumber.HttpStatusCode, 200);
        }
        
        
        [Fact]
        public async void GetListContactNumber_ContactNumberDto_ShouldGetListContactNumber()
        {
            //Arrange
            var contactCategories = new List<CreateContactCategoryDto>()
            {
                new CreateContactCategoryDto(){Title = "Sample1 Title",Css = "Sample1 Css",Description = "Sample1 Description"},
                new CreateContactCategoryDto(){Title = "Sample2 Title",Css = "Sample2 Css",Description = "Sample2 Description"},
                new CreateContactCategoryDto(){Title = "Sample3 Title",Css = "Sample3 Css",Description = "Sample3 Description"},
                new CreateContactCategoryDto(){Title = "Sample4 Title",Css = "Sample4 Css",Description = "Sample4 Description"},
            };
            var contactNumberCategories = new List<CreateContactNumberCategoryDto>()
            {
                new CreateContactNumberCategoryDto(){Title = "Sample1 Title",Css = "Sample1 Css"},
                new CreateContactNumberCategoryDto(){Title = "Sample2 Title",Css = "Sample2 Css"},
                new CreateContactNumberCategoryDto(){Title = "Sample3 Title",Css = "Sample3 Css"},
            };
            var contactNumbers = new List<CreateContactNumberDto>()
            {
                new CreateContactNumberDto(){ContactCategoryId = 1, ContactNumberCategoryId = 2, Number = "Sample1 Number"},
                new CreateContactNumberDto(){ContactCategoryId = 4, ContactNumberCategoryId = 1, Number = "Sample2 Number"},
                new CreateContactNumberDto(){ContactCategoryId = 3, ContactNumberCategoryId = 3, Number = "Sample3 Number"},
                new CreateContactNumberDto(){ContactCategoryId = 2, ContactNumberCategoryId = 1, Number = "Sample4 Number"},
            };

            //Act
            foreach (var item in contactCategories)
            {
                await PostAsync<CreateContactCategoryDto, CreateContactCategoryDto>("/ContactCategory/Create", item);
            }
            foreach (var item in contactNumberCategories)
            {
                await PostAsync<CreateContactNumberCategoryDto, CreateContactNumberCategoryDto>("/ContactNumberCategory/Create", item);
            }
            foreach (var item in contactNumbers)
            {
                await PostAsync<CreateContactNumberDto, CreateContactNumberDto>("/ContactNumber/Create", item);
            }

            var contactNumberList = await PostAsync<GetContactNumberDto, ApiResponseEnvelope<ICollection<GetContactNumberDto>>>("/ContactNumber/GetList", null);

            //Assert
            Assert.Equal(contactNumberList.Data.Count, 4);
            Assert.Equal(contactNumberList.HttpStatusCode, 200);
        }

    }
}
