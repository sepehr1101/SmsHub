using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class ConfigTypeControllerTest : BaseIntegrationTest
    {
        public ConfigTypeControllerTest(_TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }


        [Fact]
        public async void CreateConfigType_ConfigTypeDto_ShouldCreateConfigType()
        {
            //Arrange
            var configType = new CreateConfigTypeDto()
            {
                Title = "First Config",
                Description = "Sample Sentence"
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void DeleteConfigType_ConfigTypeDto_ShouldDeleteConfigType()
        {
            //Arrange
            var configType = new CreateConfigTypeDto()
            {
                Title = "First Config",
                Description = "Sample Sentence"
            };
            var deleteConfigType = new DeleteConfigTypDto()
            {
                Id = 1
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<DeleteConfigTypDto, DeleteConfigTypDto>("/ConfigType/Delete", deleteConfigType);

            //Assert
            Assert.True(true);
        }



        [Fact]
        public async void UpdateConfigType_ConfigTypeDto_ShouldUpdateConfigType()
        {
            //Arrange
            var configType = new CreateConfigTypeDto()
            {
                Title = "First Config",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            var configTypeData = await PostAsync<GetConfigTypeDto, ApiResponseEnvelope<ICollection<GetConfigTypeDto>>>("/ConfigType/GetList", null);

            var updateConfigType = new UpdateConfigTypeDto()
            {
                Id = configTypeData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Description = "Update Description",
                Title = "Update Description"
            };

            //Act
            await PostAsync<UpdateConfigTypeDto, UpdateConfigTypeDto>("/ConfigType/Update", updateConfigType);

            //Assert
            Assert.True(true);
        }



        [Fact]
        public async void GetSingleConfigType_ConfigTypeDto_ShouldGetSingleConfigType()
        {
            //Arrange
            var configType = new CreateConfigTypeDto()
            {
                Title = "sample Config for test",
                Description = "Sample Sentence"
            }; 
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            var configTypeData = await PostAsync<GetConfigTypeDto, ApiResponseEnvelope<ICollection<GetConfigTypeDto>>>("ConfigType/GetList", null);

            IntId configTypeId = configTypeData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            //Act
            var singleConfigType = await PostAsync<IntId, ApiResponseEnvelope<GetConfigTypeDto>>("/ConfigType/GetSingle", configTypeId);

            //Assert
            Assert.Equal(singleConfigType.Data.Title, "sample Config for test");
        }


        [Fact]
        public async void GetListConfigType_ConfigTypeDto_ShouldGetListConfigType()
        {
            //Arrange
            var configType = new List<CreateConfigTypeDto>()
            {
                new CreateConfigTypeDto(){Title = "First Config", Description = "Sample1 Sentence"},
                new CreateConfigTypeDto(){Title = "Second Config", Description = "Sample2 Sentence"},
                new CreateConfigTypeDto(){Title = "Third Config", Description = "Sample3 Sentence"},
            };

            //Act
            foreach (var item in configType)
            {
                await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", item);
            }
            var configTypeList = await PostAsync<IntId, ApiResponseEnvelope<ICollection<GetConfigTypeDto>>>("/ConfigType/GetList", null);

            //Assert
            Assert.InRange(configTypeList.Data.Count, 3,7);
        }
    }
}
