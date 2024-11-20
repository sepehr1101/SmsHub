using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class ContactCategoryControllerTest : BaseIntegrationTest
    {
        public ContactCategoryControllerTest(_TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateContactCategory_ContactCategoryDto_ShouldCreateContactCategory()
        {
            //Arrange
            var contactCategory = new CreateContactCategoryDto()
            {
                Title = "Sample Title",
                Css = "Sample Css",
                Description = "Sample Description"
            };
            //Act
            await PostAsync<CreateContactCategoryDto, CreateContactCategoryDto>("/ContactCategory/Create", contactCategory);

            //Assert
            Assert.True(true);
        }

        [Fact]
        public async void DeleteContactCategory_ContactCategoryDto_ShouldDeleteContactCategory()
        {
            //Arrange
            var contactCategory = new CreateContactCategoryDto()
            {
                Title = "Sample Title",
                Css = "Sample Css",
                Description = "Sample Description"
            };
            var deleteContactCategory = new DeleteContactCategoryDto()
            {
                Id = 1
            };

            //Act
            await PostAsync<CreateContactCategoryDto, CreateContactCategoryDto>("/ContactCategory/Create", contactCategory);
            await PostAsync<DeleteContactCategoryDto, DeleteContactCategoryDto>("/ContactCategory/Delete", deleteContactCategory);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void UpdateContactCategory_ContactCategoryDto_ShouldUpdateContactCategory()
        {
            //Arrange
            var contactCategory = new CreateContactCategoryDto()
            {
                Title = "Sample Title",
                Css = "Sample Css",
                Description = "Sample Description"
            };
            await PostAsync<CreateContactCategoryDto, CreateContactCategoryDto>("/ContactCategory/Create", contactCategory);
            var contactCategoryData= await PostAsync<GetContactCategoryDto, ApiResponseEnvelope<ICollection<GetContactCategoryDto>>>("/ContactCategory/GetList", null);

            var updateContactCategory = new UpdateContactCategoryDto()
            {
                Id = contactCategoryData.Data.OrderByDescending(x=>x.Id).FirstOrDefault().Id,
                Title = "Update Title",
                Css = "Update Css",
                Description = "Update Description"
            };

            //Act
            await PostAsync<UpdateContactCategoryDto, UpdateContactCategoryDto>("/ContactCategory/Update", updateContactCategory);

            //Assert
            Assert.True(true);
        }

        [Fact]
        public async void GetSingleContactCategory_ContactCategoryDto_ShouldGetSingleContactCategory()
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

            var ContactCategoryId = new IntId()
            {
                Id = contactCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
            };

            //Act
            var singleContactCategory = await PostAsync<IntId, ApiResponseEnvelope<GetContactCategoryDto>>("/ContactCategory/GetSingle", ContactCategoryId);

            //Assert
            Assert.Equal(singleContactCategory.Data.Id, 1);
            Assert.Equal(singleContactCategory.HttpStatusCode, 200);
        }


        [Fact]
        public async void GetListContactCategory_ContactCategoryDto_ShouldGetListContactCategory()
        {
            //Arrange
            var contactCategories = new List<CreateContactCategoryDto>()
            {
                new CreateContactCategoryDto(){Title = "Sample1 Title",Css = "Sample1 Css",Description = "Sample1 Description"},
                new CreateContactCategoryDto(){Title = "Sample2 Title",Css = "Sample2 Css",Description = "Sample2 Description"},
                new CreateContactCategoryDto(){Title = "Sample3 Title",Css = "Sample3 Css",Description = "Sample3 Description"},
                new CreateContactCategoryDto(){Title = "Sample4 Title",Css = "Sample4 Css",Description = "Sample4 Description"},
            };

            //Act
            foreach (var item in contactCategories)
            {
                await PostAsync<CreateContactCategoryDto, CreateContactCategoryDto>("/ContactCategory/Create", item);
            }
            var contactCategoryList= await PostAsync<GetContactCategoryDto, ApiResponseEnvelope<ICollection<GetContactCategoryDto>>>("/ContactCategory/GetList", null);

            //Assert
            Assert.InRange(contactCategoryList.Data.Count, 4,7);
        }

    }
}
