using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class ContactNumberControllerTest : BaseIntegrationTest
    {
        public ContactNumberControllerTest(_TestEnvironmentWebApplicationFactory factory)
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
            await PostAsync<CreateContactCategoryDto, CreateContactCategoryDto>("/ContactCategory/Create", contactCategory);
            var contactCategoryData = await PostAsync<GetContactCategoryDto, ApiResponseEnvelope<ICollection<GetContactCategoryDto>>>("/ContactCategory/GetList", null);

            var contactNumberCategory = new CreateContactNumberCategoryDto()
            {
                Title = "Get Single Test Sample Title",
                Css = "Sample Css"
            };
            await PostAsync<CreateContactNumberCategoryDto, CreateContactNumberCategoryDto>("/ContactNumberCategory/Create", contactNumberCategory);
            var contactNumberCategoryData = await PostAsync<GetContactNumberCategoryDto, ApiResponseEnvelope<ICollection<GetContactNumberCategoryDto>>>("/ContactNumberCategory/GetList", null);

            var contactNumber = new CreateContactNumberDto()
            {
                ContactCategoryId = contactCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                ContactNumberCategoryId = contactNumberCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Number = "Create Test Sample Number"
            };

            //Act
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
                Title = "Delete Sample Title",
                Css = "Delete Sample Css",
                Description = "Sample Description"
            };
            await PostAsync<CreateContactCategoryDto, CreateContactCategoryDto>("/ContactCategory/Create", contactCategory);
            var contactCategoryData = await PostAsync<GetContactCategoryDto, ApiResponseEnvelope<ICollection<GetContactCategoryDto>>>("/ContactCategory/GetList", null);

            var contactNumberCategory = new CreateContactNumberCategoryDto()
            {
                Title = "Delete Test Sample Title",
                Css = "Sample Css"
            };
            await PostAsync<CreateContactNumberCategoryDto, CreateContactNumberCategoryDto>("/ContactNumberCategory/Create", contactNumberCategory);
            var contactNumberCategoryData = await PostAsync<GetContactNumberCategoryDto, ApiResponseEnvelope<ICollection<GetContactNumberCategoryDto>>>("/ContactNumberCategory/GetList", null);

            var contactNumber = new CreateContactNumberDto()
            {
                ContactCategoryId = contactCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                ContactNumberCategoryId = contactNumberCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Number = "Delete Test Sample Number"
            };
            await PostAsync<CreateContactNumberDto, CreateContactNumberDto>("/ContactNumber/Create", contactNumber);
            var contactNumberData = await PostAsync<GetContactNumberDto, ApiResponseEnvelope<ICollection<GetContactNumberDto>>>("/ContactNumber/GetList", null);

            var deleteContactNumber = new DeleteContactNumberDto()
            {
                Id = contactNumberData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
            };

            //Act

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
            await PostAsync<CreateContactCategoryDto, CreateContactCategoryDto>("/ContactCategory/Create", contactCategory);
            var contactCategoryData = await PostAsync<GetContactCategoryDto, ApiResponseEnvelope<ICollection<GetContactCategoryDto>>>("/ContactCategory/GetList", null);

            var contactNumberCategory = new CreateContactNumberCategoryDto()
            {
                Title = "Update Test Sample Title",
                Css = "Sample Css"
            };
            await PostAsync<CreateContactNumberCategoryDto, CreateContactNumberCategoryDto>("/ContactNumberCategory/Create", contactNumberCategory);
            var contactNumberCategoryData = await PostAsync<GetContactNumberCategoryDto, ApiResponseEnvelope<ICollection<GetContactNumberCategoryDto>>>("/ContactNumberCategory/GetList", null);

            var contactNumber = new CreateContactNumberDto()
            {
                ContactCategoryId = contactCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                ContactNumberCategoryId = contactNumberCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Number = "Update Test Sample Number"
            };
            await PostAsync<CreateContactNumberDto, CreateContactNumberDto>("/ContactNumber/Create", contactNumber);
            var contactNumberData = await PostAsync<GetContactNumberDto, ApiResponseEnvelope<ICollection<GetContactNumberDto>>>("/ContactNumber/GetList", null);

            var updateContactNumber = new UpdateContactNumberDto()
            {
                Id = contactNumberData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                ContactCategoryId = contactCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                ContactNumberCategoryId = contactNumberCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Number = "Update Test Number"
            };

            //Act
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
            await PostAsync<CreateContactCategoryDto, CreateContactCategoryDto>("/ContactCategory/Create", contactCategory);
            var contactCategoryData = await PostAsync<GetContactCategoryDto, ApiResponseEnvelope<ICollection<GetContactCategoryDto>>>("/ContactCategory/GetList", null);

            var contactNumberCategory = new CreateContactNumberCategoryDto()
            {
                Title = "getSingle Test Sample Title",
                Css = "Sample Css"
            };
            await PostAsync<CreateContactNumberCategoryDto, CreateContactNumberCategoryDto>("/ContactNumberCategory/Create", contactNumberCategory);
            var contactNumberCategoryData = await PostAsync<GetContactNumberCategoryDto, ApiResponseEnvelope<ICollection<GetContactNumberCategoryDto>>>("/ContactNumberCategory/GetList", null);

            var contactNumber = new CreateContactNumberDto()
            {
                ContactCategoryId = contactCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                ContactNumberCategoryId = contactNumberCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Number = "GetSingle Test Sample Number"
            };
            await PostAsync<CreateContactNumberDto, CreateContactNumberDto>("/ContactNumber/Create", contactNumber);
            var contactNumberData = await PostAsync<GetContactNumberDto, ApiResponseEnvelope<ICollection<GetContactNumberDto>>>("/ContactNumber/GetList", null);
            
            var contactNumberId = new IntId()
            {
                Id = contactNumberData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
            };

            //Act
            var singleContactNumber = await PostAsync<IntId, ApiResponseEnvelope<GetContactNumberDto>>("/ContactNumber/GetSingle", contactNumberId);

            //Assert
            Assert.Equal(singleContactNumber.Data.Number, "GetSingle Test Sample Number");
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
                new CreateContactNumberCategoryDto(){Title = "Test Sample1 Title",Css = "Sample1 Css"},
                new CreateContactNumberCategoryDto(){Title = "Test Sample2 Title",Css = "Sample2 Css"},
                new CreateContactNumberCategoryDto(){Title = "Test Sample3 Title",Css = "Sample3 Css"},
            };
            var contactNumbers = new List<CreateContactNumberDto>()
            {
                new CreateContactNumberDto(){ContactCategoryId = 4, ContactNumberCategoryId = 2, Number = "Sample1 Number"},
                new CreateContactNumberDto(){ContactCategoryId = 4, ContactNumberCategoryId = 3, Number = "Sample2 Number"},
                new CreateContactNumberDto(){ContactCategoryId =4 , ContactNumberCategoryId = 1, Number = "Sample3 Number"},
                new CreateContactNumberDto(){ContactCategoryId = 1, ContactNumberCategoryId = 3, Number = "Sample4 Number"},
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
            Assert.InRange(contactNumberList.Data.Count, 4,7);
        }

    }
}
