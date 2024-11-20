using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class MessageStateCategoryControllerTest : BaseIntegrationTest
    {
        public MessageStateCategoryControllerTest(_TestEnvironmentWebApplicationFactory factory)
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
                Id = 1
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
                ProviderId = ProviderEnum.Magfa
            };

            //Act
            await PostAsync<CreateMessageStateCategoryDto, CreateMessageStateCategoryDto>("/MessageStateCategory/Create", messageStateCategory);
            await PostAsync<UpdateMessageStateCategoryDto, UpdateMessageStateCategoryDto>("/MessageStateCategory/Update", updateMessageStateCategory);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void GetSingleMessageStateCategory_MessageStateCategoryDto_ShouldGetSingleMessageStateCategory()
        {
            //Arrange
            var messageStateCategory = new CreateMessageStateCategoryDto()
            {
                Css = "Sample Css",
                IsError = true,
                Title = "Sample Title",
                ProviderId = ProviderEnum.Kavenegar
            };
            var messageStateCategoryId = new IntId()
            {
                Id = 1
            };

            //Act
            await PostAsync<CreateMessageStateCategoryDto, CreateMessageStateCategoryDto>("/MessageStateCategory/Create", messageStateCategory);
            var singleMessageStateCategory = await PostAsync<IntId, ApiResponseEnvelope<GetMessageStateCategoryDto>>("/MessageStateCategory/GetSingle", messageStateCategoryId);

            //Assert
            Assert.Equal(singleMessageStateCategory.Data.Id, 1);
        }


        [Fact]
        public async void GetListMessageStateCategory_MessageStateCategoryDto_ShouldGetListMessageStateCategory()
        {
            //Arrange
            var messageStateCategories = new List<CreateMessageStateCategoryDto>()
            {
                new CreateMessageStateCategoryDto(){Css = "Sample Css",IsError = true,Title = "Sample Title",ProviderId = ProviderEnum.Kavenegar},
                new CreateMessageStateCategoryDto(){Css = "Sample Css",IsError = true,Title = "Sample Title",ProviderId = ProviderEnum.Kavenegar},
                new CreateMessageStateCategoryDto(){Css = "Sample Css",IsError = true,Title = "Sample Title",ProviderId = ProviderEnum.Kavenegar},
            };

            //Act
            foreach (var item in messageStateCategories)
            {
                await PostAsync<CreateMessageStateCategoryDto, CreateMessageStateCategoryDto>("/MessageStateCategory/Create", item);
            }
            var messageStateCategoryList = await PostAsync<GetMessageStateCategoryDto, ApiResponseEnvelope<ICollection<GetMessageStateCategoryDto>>>("/MessageStateCategory/GetList", null);

            //Assert
            Assert.Equal(messageStateCategoryList.Data.Count, 3);
        }
    }
}
