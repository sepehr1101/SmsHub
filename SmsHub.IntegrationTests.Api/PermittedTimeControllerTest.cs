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

            var permittedTime = new CreatePermittedTimeDto()
            {
                ConfigTypeGroupId = configTypeGroupData.Data.OrderByDescending(x=>x.Id).FirstOrDefault().Id,
                FromTime = "12:30",
                ToTime = "12:40"
            };

            //Act
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

            var permittedTime = new CreatePermittedTimeDto()
            {
                ConfigTypeGroupId = configTypeGroupData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                FromTime = "12:30",
                ToTime = "12:40"
            };
            await PostAsync<CreatePermittedTimeDto, CreatePermittedTimeDto>("/PermittedTime/Create", permittedTime);
            var permittedTimeData = await PostAsync<GetPermittedTimeDto, ApiResponseEnvelope<ICollection<GetPermittedTimeDto>>>("/PermittedTime/GetList", null);

            var deletePermittedTime = new DeletePermittedTimeDto()
            {
                Id = permittedTimeData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
            };

            //Act
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

            var permittedTime = new CreatePermittedTimeDto()
            {
                ConfigTypeGroupId = configTypeGroupData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                FromTime = "12:30",
                ToTime = "12:40"
            };
            await PostAsync<CreatePermittedTimeDto, CreatePermittedTimeDto>("/PermittedTime/Create", permittedTime);
            var permittedTimeData = await PostAsync<GetPermittedTimeDto, ApiResponseEnvelope<ICollection<GetPermittedTimeDto>>>("/PermittedTime/GetList", null);

            var updatePermittedTime = new UpdatePermittedTimeDto()
            {
                Id = permittedTimeData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                ConfigTypeGroupId = configTypeGroupData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                FromTime = "15:00",
                ToTime = "17:30"
            };

            //Act
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

            var permittedTime = new CreatePermittedTimeDto()
            {
                ConfigTypeGroupId = configTypeGroupData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                FromTime = "12:30",
                ToTime = "12:40"
            };
            await PostAsync<CreatePermittedTimeDto, CreatePermittedTimeDto>("/PermittedTime/Create", permittedTime);
            var permittedTimeData = await PostAsync<GetPermittedTimeDto, ApiResponseEnvelope<ICollection<GetPermittedTimeDto>>>("/PermittedTime/GetList", null);

            var permittedTimeId = new IntId()
            {
                Id = permittedTimeData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,

            };

            //Act
            var singlePermittedTime = await PostAsync<IntId, ApiResponseEnvelope<GetPermittedTimeDto>>("/PermittedTime/GetSingle", permittedTimeId);

            //Assert
            Assert.Equal(singlePermittedTime.Data.Id, permittedTimeId.Id);
        }



        [Fact]
        public async void GetListPermittedTime_PermittedTimeDto_ShouldGetListPermittedTime()
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
            var permittedTimes = new List<CreatePermittedTimeDto>()
            {
                new CreatePermittedTimeDto(){ ConfigTypeGroupId = 1,FromTime = "12:30",ToTime = "12:40"},
                new CreatePermittedTimeDto(){ ConfigTypeGroupId = 2,FromTime = "14:00",ToTime = "14:30"},
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
            Assert.InRange(permittedTimeList.Data.Count, 3,7);
        }
    }
}
