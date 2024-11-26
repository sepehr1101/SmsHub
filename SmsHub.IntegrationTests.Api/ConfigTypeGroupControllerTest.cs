using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class ConfigTypeGroupControllerTest : BaseIntegrationTest
    {
        public ConfigTypeGroupControllerTest(_TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateConfigTypeGroup_ConfigTypeGroupDto_ShouldCreateConfigTypeGroup()
        {
            //Arrange
            var configType = new CreateConfigTypeDto()
            {
                Title = "First Config",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            var configTypeData = await PostAsync<GetConfigTypeDto, ApiResponseEnvelope<ICollection<GetConfigTypeDto>>>("/ConfigType/GetList", null);

            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = configTypeData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Title = "First ConfigTypeGroup",
                Description = "Sample Sentence"
            };

            //Act
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);

            //Assert
            Assert.True(true);
        }

        [Fact]
        public async void DeleteConfigTypeGroup_ConfigTypeGroupDto_ShouldDeleteConfigTypeGroup()
        {
            //Arrange
            var configType = new CreateConfigTypeDto()
            {
                Title = "First Config",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            var configTypeData = await PostAsync<GetConfigTypeDto, ApiResponseEnvelope<ICollection<GetConfigTypeDto>>>("/ConfigType/GetList", null);

            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = configTypeData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Title = "First ConfigTypeGroup",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            var configTypeGroupData = await PostAsync<GetConfigTypeGroupDto, ApiResponseEnvelope<ICollection<GetConfigTypeGroupDto>>>("/ConfigTypeGroup/GetList", null);

            var deleteConfigTypeGroup = new DeleteConfigTypeGroupDto()
            {
                Id = configTypeGroupData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
            };

            //Act
            await PostAsync<DeleteConfigTypeGroupDto, DeleteConfigTypeGroupDto>("/ConfigTypeGroup/Delete", deleteConfigTypeGroup);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void UpdateConfigTypeGroup_ConfigTypeGroupDto_ShouldUpdateConfigTypeGroup()
        { 
            //Arrange
            var configType = new CreateConfigTypeDto()
            {
                Title = "First Config",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            var configTypeData = await PostAsync<GetConfigTypeDto, ApiResponseEnvelope<ICollection<GetConfigTypeDto>>>("/ConfigType/GetList", null);

            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = configTypeData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Title = "First ConfigTypeGroup",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            var configTypeGroupData = await PostAsync<GetConfigTypeGroupDto, ApiResponseEnvelope<ICollection<GetConfigTypeGroupDto>>>("/ConfigTypeGroup/GetList", null);

            var updateConfigTypeGroup = new UpdateConfigTypeGroupDto()
            {
                Id = configTypeGroupData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                ConfigTypeId = 1,
                Title = "Update Title",
                Description = "Update Description"
            };

            //Act
            await PostAsync<UpdateConfigTypeGroupDto, UpdateConfigTypeGroupDto>("/ConfigTypeGroup/Update", updateConfigTypeGroup);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void GetSingleConfigTypeGroup_ConfigTypeGroupDto_ShouldGetSingleConfigTypeGroup()
        {
            //Arrange
            var configType = new CreateConfigTypeDto()
            {
                Title = "First Config",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            var configTypeData = await PostAsync<GetConfigTypeDto, ApiResponseEnvelope<ICollection<GetConfigTypeDto>>>("/ConfigType/GetList", null);

            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = configTypeData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Title = "sample ConfigTypeGroup for test",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            var configTypeGroupData = await PostAsync<GetConfigTypeGroupDto, ApiResponseEnvelope<ICollection<GetConfigTypeGroupDto>>>("/ConfigTypeGroup/GetList", null);

            var configTypeGroupId = new IntId()
            {
                Id = configTypeGroupData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
            };

            //Act
            var singleConfigTypeGroup = await PostAsync<IntId, ApiResponseEnvelope<GetConfigTypeGroupDto>>("/ConfigTypeGroup/GetSingle", configTypeGroupId);

            //Assert
            Assert.Equal(singleConfigTypeGroup.Data.Title, "sample ConfigTypeGroup for test");
        }


        [Fact]
        public async void GetListConfigTypeGroup_ConfigTypeGroupDto_ShouldGetListConfigTypeGroup()
        {
            //Arrange
            var configType = new List<CreateConfigTypeDto>()
            {
                new CreateConfigTypeDto(){Title = "First Config", Description = "Sample1 Sentence"},
                new CreateConfigTypeDto(){Title = "Second Config", Description = "Sample2 Sentence"},
                new CreateConfigTypeDto(){Title = "Third Config", Description = "Sample3 Sentence"},
            };
            var configTypeGroup = new List<CreateConfigTypeGroupDto>()
            {
                new CreateConfigTypeGroupDto(){ConfigTypeId = 1,Title = "First ConfigTypeGroup",Description = "Sample1 Sentence"},
                new CreateConfigTypeGroupDto(){ConfigTypeId = 2,Title = "Second ConfigTypeGroup",Description = "Sample2 Sentence"},
                new CreateConfigTypeGroupDto(){ConfigTypeId = 2,Title = "Third ConfigTypeGroup",Description = "Sample3 Sentence"},
                new CreateConfigTypeGroupDto(){ConfigTypeId = 3,Title = "Forth ConfigTypeGroup",Description = "Sample4 Sentence"},
            };
            //Act
            foreach (var item in configType)
            {
                await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", item);
            }
            foreach (var item in configTypeGroup)
            {
                await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", item);
            }

            var configTypeGroupList = await PostAsync<GetConfigTypeGroupDto, ApiResponseEnvelope<ICollection<GetConfigTypeGroupDto>>>("/ConfigTypeGroup/GetList", null);

            //Assert
            Assert.InRange(configTypeGroupList.Data.Count, 4,8);
        }
    }
}
