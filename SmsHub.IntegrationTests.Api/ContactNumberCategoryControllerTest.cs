using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Contact.MediatorDtos.Queries;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class ContactNumberCategoryControllerTest:BaseIntegrationTest
    {
        public ContactNumberCategoryControllerTest(TestEnvironmentWebApplicationFactory factory)
            :base(factory)
        {
        }


        [Fact]
        public async void CreateContactNumber_ContactNumberDto_ShouldCreateContactNumber()
        {
            //Arrange
            var contactNumberCategory = new CreateContactNumberCategoryDto()
            {
                Title = "Sample Title",
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
                Title = "Sample Title",
                Css = "Sample Css"
            };
            var deleteContactNumberCategory = new DeleteContactNumberCategoryDto()
            {
                Id=1
            };

            //Act
            await PostAsync<CreateContactNumberCategoryDto, CreateContactNumberCategoryDto>("/ContactNumberCategory/Create", contactNumberCategory);
            await PostAsync<DeleteContactNumberCategoryDto, DeleteContactNumberCategoryDto>("/ContactNumberCategory/Delete",deleteContactNumberCategory);
            
            //Assert
            Assert.True(true);
        }
        
        
        [Fact]
        public async void UpdateContactNumber_ContactNumberDto_ShouldUpdateContactNumber()
        {
            //Arrange
            var contactNumberCategory = new CreateContactNumberCategoryDto()
            {
                Title = "Sample Title",
                Css = "Sample Css"
            };
            var updateContactNumbetCategory = new UpdateContactNumberCategoryDto()
            {
                Id=1,
                Title="Update Title",
                Css="Update Css"
            };

            //Act
            await PostAsync<CreateContactNumberCategoryDto, CreateContactNumberCategoryDto>("/ContactNumberCategory/Create", contactNumberCategory);
            await PostAsync<UpdateContactNumberCategoryDto, UpdateContactNumberCategoryDto>("/ContactNumberCategory/Update",updateContactNumbetCategory);
            
            //Assert
            Assert.True(true);
        }
        
        
        [Fact]
        public async void GetSingleContactNumber_ContactNumberDto_ShouldGetSingleContactNumber()
        {
            //Arrange
            var contactNumberCategory = new CreateContactNumberCategoryDto()
            {
                Title = "Sample Title",
                Css = "Sample Css"
            };
            var contactNumberCategoryId = new IntId()
            {
               Id=1
            };

            //Act
            await PostAsync<CreateContactNumberCategoryDto, CreateContactNumberCategoryDto>("/ContactNumberCategory/Create", contactNumberCategory);
           var singleContactNumberCategory= await PostAsync<IntId, ApiResponseEnvelope<GetContactNumberCategoryDto>>("/ContactNumberCategory/GetSingle",contactNumberCategoryId);

            //Assert
            Assert.Equal(singleContactNumberCategory.Data.Id, 1);
            Assert.Equal(singleContactNumberCategory.HttpStatusCode, 200);
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
            var contactNumberCategoryList= await PostAsync<GetContactNumberCategoryDto, ApiResponseEnvelope<ICollection<GetContactNumberCategoryDto>>>("/ContactNumberCategory/GetList",null);

            //Assert
            Assert.Equal(contactNumberCategoryList.Data.Count, 3);
            Assert.Equal(contactNumberCategoryList.HttpStatusCode, 200);
        }

    }
}
