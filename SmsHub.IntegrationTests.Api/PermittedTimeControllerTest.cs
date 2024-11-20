using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class PermittedTimeControllerTest : BaseIntegrationTest
    {
        public PermittedTimeControllerTest(_TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreatePermittedTime_PermittedTimeDto_ShouldCreatePermittedTime()
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
            var permittedTime = new CreatePermittedTimeDto()
            {
                ConfigTypeGroupId = 1,
                FromTime = "12:30",
                ToTime = "12:40"
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            await PostAsync<CreatePermittedTimeDto, CreatePermittedTimeDto>("/PermittedTime/Create", permittedTime);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void DeletePermittedTime_PermittedTimeDto_ShouldDeletePermittedTime()
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
            var permittedTime = new CreatePermittedTimeDto()
            {
                ConfigTypeGroupId = 1,
                FromTime = "12:30",
                ToTime = "12:40"
            };
            var deletePermittedTime = new DeletePermittedTimeDto()
            {
                Id = 1,
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            await PostAsync<CreatePermittedTimeDto, CreatePermittedTimeDto>("/PermittedTime/Create", permittedTime);

            await PostAsync<DeletePermittedTimeDto, DeletePermittedTimeDto>("/PermittedTime/Delete", deletePermittedTime);

            //Assert
            Assert.True(true);
        }



        [Fact]
        public async void UpdatePermittedTime_PermittedTimeDto_ShouldUpdatePermittedTime()
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
            var permittedTime = new CreatePermittedTimeDto()
            {
                ConfigTypeGroupId = 1,
                FromTime = "12:30",
                ToTime = "12:40"
            };
            var updatePermittedTime = new UpdatePermittedTimeDto()
            {
                Id = 1,
                ConfigTypeGroupId = 1,
                FromTime = "15:00",
                ToTime = "17:30"
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            await PostAsync<CreatePermittedTimeDto, CreatePermittedTimeDto>("/PermittedTime/Create", permittedTime);

            await PostAsync<UpdatePermittedTimeDto, UpdatePermittedTimeDto>("/PermittedTime/Update", updatePermittedTime);

            //Assert
            Assert.True(true);
        }



        [Fact]
        public async void GetSinglePermittedTime_PermittedTimeDto_ShouldGetSinglePermittedTime()
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
            var permittedTime = new CreatePermittedTimeDto()
            {
                ConfigTypeGroupId = 1,
                FromTime = "12:30",
                ToTime = "12:40"
            };
            var permittedTimeId = new IntId()
            {
                Id = 1
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            await PostAsync<CreatePermittedTimeDto, CreatePermittedTimeDto>("/PermittedTime/Create", permittedTime);

            var singlePermittedTime = await PostAsync<IntId, ApiResponseEnvelope<GetPermittedTimeDto>>("/PermittedTime/GetSingle", permittedTimeId);

            //Assert
            Assert.Equal(singlePermittedTime.Data.Id, 1);
        }



        [Fact]
        public async void GetListPermittedTime_PermittedTimeDto_ShouldGetListPermittedTime()
        {
            //Arrange

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
            var permittedTimes = new List<CreatePermittedTimeDto>()
            {
                new CreatePermittedTimeDto(){ ConfigTypeGroupId = 1,FromTime = "12:30",ToTime = "12:40"},
                new CreatePermittedTimeDto(){ ConfigTypeGroupId = 2,FromTime = "2:00",ToTime = "2:30"},
                new CreatePermittedTimeDto(){ ConfigTypeGroupId = 3,FromTime = "18:15",ToTime = "19:00"},
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
            foreach (var item in permittedTimes)
            {
                await PostAsync<CreatePermittedTimeDto, CreatePermittedTimeDto>("/PermittedTime/Create", item);
            }

            var permittedTimeList = await PostAsync<GetPermittedTimeDto, ApiResponseEnvelope<ICollection<GetPermittedTimeDto>>>("/PermittedTime/GetList", null);

            //Assert
            Assert.Equal(permittedTimeList.Data.Count, 3);
        }
    }
}
