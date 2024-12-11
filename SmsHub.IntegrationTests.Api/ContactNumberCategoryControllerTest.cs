using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class ContactNumberCategoryControllerTest : BaseIntegrationTest
    {
        public ContactNumberCategoryControllerTest(_TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }


        [Fact]
        public async void CreateContactNumber_ContactNumberDto_ShouldCreateContactNumber()
        {
            //Arrange
            var contactNumberCategory = new CreateContactNumberCategoryDto()
            {
                Title = "Create Test Sample Title",
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
                Title = "Delete Test Sample Title",
                Css = "Sample Css"
            };
            await PostAsync<CreateContactNumberCategoryDto, CreateContactNumberCategoryDto>("/ContactNumberCategory/Create", contactNumberCategory);
            var contactNumberCategoryData = await PostAsync<GetContactNumberCategoryDto, ApiResponseEnvelope<ICollection<GetContactNumberCategoryDto>>>("/ContactNumberCategory/GetList", null);

            var deleteContactNumberCategory = new DeleteContactNumberCategoryDto()
            {
                Id = contactNumberCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };

            //Act
            await PostAsync<DeleteContactNumberCategoryDto, DeleteContactNumberCategoryDto>("/ContactNumberCategory/Delete", deleteContactNumberCategory);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void UpdateContactNumber_ContactNumberDto_ShouldUpdateContactNumber()
        {
            //Arrange
            var contactNumberCategory = new CreateContactNumberCategoryDto()
            {
                Title = "Update Test Sample Title",
                Css = "Sample Css"
            };
            await PostAsync<CreateContactNumberCategoryDto, CreateContactNumberCategoryDto>("/ContactNumberCategory/Create", contactNumberCategory);
            var contactNumberCategoryData = await PostAsync<GetContactNumberCategoryDto, ApiResponseEnvelope<ICollection<GetContactNumberCategoryDto>>>("/ContactNumberCategory/GetList", null);

            var updateContactNumberCategory = new UpdateContactNumberCategoryDto()
            {
                Id = contactNumberCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Title = "Update Title",
                Css = "Update Css"
            };

            //Act
            await PostAsync<UpdateContactNumberCategoryDto, UpdateContactNumberCategoryDto>("/ContactNumberCategory/Update", updateContactNumberCategory);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void GetSingleContactNumber_ContactNumberDto_ShouldGetSingleContactNumber()
        {
            //Arrange
            var contactNumberCategory = new CreateContactNumberCategoryDto()
            {
                Title = "Get Single Test Sample Title",
                Css = "Sample Css"
            };
            await PostAsync<CreateContactNumberCategoryDto, CreateContactNumberCategoryDto>("/ContactNumberCategory/Create", contactNumberCategory);
            var contactNumberCategoryData = await PostAsync<GetContactNumberCategoryDto, ApiResponseEnvelope<ICollection<GetContactNumberCategoryDto>>>("/ContactNumberCategory/GetList", null);

            IntId contactNumberCategoryId = contactNumberCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            //Act
            var singleContactNumberCategory = await PostAsync<IntId, ApiResponseEnvelope<GetContactNumberCategoryDto>>("/ContactNumberCategory/GetSingle", contactNumberCategoryId);

            //Assert
            Assert.Equal(singleContactNumberCategory.Data.Title, "Get Single Test Sample Title");
        }


        [Fact]
        public async void GetListContactNumber_ContactNumberDto_ShouldGetListContactNumber()
        {
            //Arrange
            var contactNumberCategories = new List<CreateContactNumberCategoryDto>()
            {
                new CreateContactNumberCategoryDto(){Title = "Sample1 Title",Css = "Sample1 Css"},
                new CreateContactNumberCategoryDto(){Title = "Sample2 Title",Css = "Sample2 Css"},
                new CreateContactNumberCategoryDto(){Title = "Sample3 Title",Css = "Sample3 Css"},
            };

            //Act
            foreach (var item in contactNumberCategories)
            {
                await PostAsync<CreateContactNumberCategoryDto, CreateContactNumberCategoryDto>("/ContactNumberCategory/Create", item);
            }
            var contactNumberCategoryList = await PostAsync<GetContactNumberCategoryDto, ApiResponseEnvelope<ICollection<GetContactNumberCategoryDto>>>("/ContactNumberCategory/GetList", null);

            //Assert
            Assert.InRange(contactNumberCategoryList.Data.Count, 3,7);
        }

    }
}
