using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class ConfigTypeGroupControllerTest : BaseIntegrationTest
    {
        public ConfigTypeGroupControllerTest(TestEnvironmentWebApplicationFactory factory)
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
            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = 1,
                Title = "First ConfigTypeGroup",
                Description = "Sample Sentence"
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
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
            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = 1,
                Title = "First ConfigTypeGroup",
                Description = "Sample Sentence"
            };
            var deleteConfigTypeGroup = new DeleteConfigTypeGroupDto()
            {
                Id = 1
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);

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
            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = 1,
                Title = "First ConfigTypeGroup",
                Description = "Sample Sentence"
            };
            var updateConfigTypeGroup = new UpdateConfigTypeGroupDto()
            {
                Id = 1,
                ConfigTypeId = 1,
                Title = "Update Title",
                Description = "Update Description"
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);

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
            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = 1,
                Title = "First ConfigTypeGroup",
                Description = "Sample Sentence"
            };
            var configTypeGroupId = new IntId()
            {
                Id=1
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);

          var singleConfigTypeGroup=  await PostAsync<IntId, ApiResponseEnvelope<GetConfigTypeGroupDto>>("/ConfigTypeGroup/GetSingle", configTypeGroupId);

            //Assert
            Assert.Equal(singleConfigTypeGroup.Data.Id, 1);
            Assert.Equal(singleConfigTypeGroup.HttpStatusCode,200);

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

            var configTypeGroupList =  await PostAsync<GetConfigTypeGroupDto, ApiResponseEnvelope<ICollection<GetConfigTypeGroupDto>>>("/ConfigTypeGroup/GetList",null );

            //Assert
            Assert.Equal(configTypeGroupList.Data.Count, 4);
            Assert.Equal(configTypeGroupList.HttpStatusCode,200);
        }
    }
}
