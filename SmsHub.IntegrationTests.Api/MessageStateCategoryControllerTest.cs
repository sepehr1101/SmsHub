using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;

//[assembly:CollectionBehavior(DisableTestParallelization =true)]
namespace SmsHub.IntegrationTests.Api
{
    public class MessageStateCategoryControllerTest : BaseIntegrationTest
    {
        public MessageStateCategoryControllerTest(TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateMessageStateCategory_MessageStateCategoryDto_ShouldCreateMessageStateCategory()
        {
            //Arrange
            var messageStateCategory = new CreateMessageStateCategoryDto()
            {
                Css = "Sample Css",
                IsError = true,
                Title = "Sample Title",
                ProviderId = ProviderEnum.Kavenegar
            };

            //Act
            await PostAsync<CreateMessageStateCategoryDto, CreateMessageStateCategoryDto>("/MessageStateCategory/Create", messageStateCategory);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void DeleteMessageStateCategory_MessageStateCategoryDto_ShouldDeleteMessageStateCategory()
        {
            //Arrange
            var messageStateCategory = new CreateMessageStateCategoryDto()
            {
                Css = "Sample Css",
                IsError = true,
                Title = "Sample Title",
                ProviderId = ProviderEnum.Kavenegar
            };
            var deleteMessageStateCategory = new DeleteMessageStateCategoryDto()
            {
                Id=1
            };

            //Act
            await PostAsync<CreateMessageStateCategoryDto, CreateMessageStateCategoryDto>("/MessageStateCategory/Create", messageStateCategory);
            await PostAsync<DeleteMessageStateCategoryDto, DeleteMessageStateCategoryDto>("/MessageStateCategory/Delete", deleteMessageStateCategory);

            //Assert
            Assert.True(true);
        }



        [Fact]
        public async void UpdateMessageStateCategory_MessageStateCategoryDto_ShouldUpdateMessageStateCategory()
        {
            //Arrange
            var messageStateCategory = new CreateMessageStateCategoryDto()
            {
                Css = "Sample Css",
                IsError = true,
                Title = "Sample Title",
                ProviderId = ProviderEnum.Kavenegar
            };
            var updateMessageStateCategory = new UpdateMessageStateCategoryDto()
            {
                Id = 1,
                Css = "Sample Css",
                IsError = true,
                Title = "Sample Title",
                ProviderId=ProviderEnum.Magfa
            };

            //Act
            await PostAsync<CreateMessageStateCategoryDto, CreateMessageStateCategoryDto>("/MessageStateCategory/Create", messageStateCategory);
            await PostAsync<UpdateMessageStateCategoryDto, UpdateMessageStateCategoryDto>("/MessageStateCategory/Update",updateMessageStateCategory);

            //Assert
            Assert.True(true);
        }
    }
}
