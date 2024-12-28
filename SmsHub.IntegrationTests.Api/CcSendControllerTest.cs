using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class CcSendControllerTest : BaseIntegrationTest
    {
        public CcSendControllerTest(_TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateCcSend_CcSendDto_ShouldCreateCcSend()
        {
            //Arrange
            var configType = new CreateConfigTypeDto()
            {
                Title = "sample Config",
                Description = "Sample Sentence"
            };
            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = 1,
                Title = "sample ConfigTypeGroup",
                Description = "Sample Sentence"
            };
            var ccSend = new CreateCcSendDto()
            {
                ConfigTypeGroupId = 1,
                Mobile = "09131234567"
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            await PostAsync<CreateCcSendDto, CreateCcSendDto>("/CcSend/Create", ccSend);

            //Assert
            Assert.True(true);
        }

        [Fact]
        public async void DeleteCcSend_CcSendDto_ShouldDeleteCcSendDto()
        {
            //Arrange
            var configType = new CreateConfigTypeDto()
            {
                Title = "sample Config",
                Description = "Sample Sentence"
            };
            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = 1,
                Title = "sample ConfigTypeGroup",
                Description = "Sample Sentence"
            };
            var ccSend = new CreateCcSendDto()
            {
                ConfigTypeGroupId = 1,
                Mobile = "09131234567"
            };
            var deleteCcSend = new DeleteCcSendDto()
            {
                Id = 1
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            await PostAsync<CreateCcSendDto, CreateCcSendDto>("/CcSend/Create", ccSend);

            await PostAsync<DeleteCcSendDto, DeleteCcSendDto>("/CcSend/Delete", deleteCcSend);

            //Assert
            Assert.True(true);
        }

        [Fact]
        public async void UpdateCcSend_CcSendDto_ShouldUpdateCcSend()
        {
            //Arrange
            var configType = new CreateConfigTypeDto()
            {
                Title = "sample Config",
                Description = "Sample Sentence"
            };
            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = 1,
                Title = "sample ConfigTypeGroup",
                Description = "Sample Sentence"
            };
            var ccSend = new CreateCcSendDto()
            {
                ConfigTypeGroupId = 1,
                Mobile = "09131234567"
            };
            var updateCcSend = new UpdateCcSendDto()
            {
                Id = 1,
                ConfigTypeGroupId = 1,
                Mobile = "09000000000"
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            await PostAsync<CreateCcSendDto, CreateCcSendDto>("/CcSend/Create", ccSend);

            await PostAsync<UpdateCcSendDto, UpdateCcSendDto>("/CcSend/Update", updateCcSend);
            //Assert
            Assert.True(true);
        }

        [Fact]
        public async void GetSingleCcSend_CcSendDto_ShouldGetSingleCcSend()
        {
            //Arrange
            var configType = new CreateConfigTypeDto()
            {
                Title = "sample Config",
                Description = "Sample Sentence"
            };
            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = 1,
                Title = "sample ConfigTypeGroup",
                Description = "Sample Sentence"
            };
            var ccSend = new CreateCcSendDto()
            {
                ConfigTypeGroupId = 1,
                Mobile = "09131234567"
            };
            IntId ccSendId = 1;

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            await PostAsync<CreateCcSendDto, CreateCcSendDto>("/CcSend/Create", ccSend);

            var singleCcSend = await PostAsync<IntId, ApiResponseEnvelope<GetCcSendDto>>("/CcSend/GetSingle", ccSendId);

            //Assert
            Assert.Equal(singleCcSend.Data.Id, 1);
        }

        [Fact]
        public async void GetListCcSend_CcSendDto_ShouldGetListCcSend()
        {
            //Arrange
            var configTypes = new List<CreateConfigTypeDto>()
            {
                new CreateConfigTypeDto(){ Title = "First Config", Description = "Sample1 Sentence" }  ,
                new CreateConfigTypeDto(){ Title = "Second Config", Description = "Sample2 Sentence" },
                new CreateConfigTypeDto(){ Title = "Third Config", Description = "Sample3 Sentence" }
            };
            var configTypeGroups = new List<CreateConfigTypeGroupDto>()
            {
                new CreateConfigTypeGroupDto(){ ConfigTypeId = 1,Title = "First ConfigTypeGroup",Description = "Sample1 Sentence"},
                new CreateConfigTypeGroupDto(){ ConfigTypeId = 1,Title = "Second ConfigTypeGroup",Description = "Sample2 Sentence"},
                new CreateConfigTypeGroupDto(){ ConfigTypeId = 2,Title = "Third ConfigTypeGroup",Description = "Sample3 Sentence"},
                new CreateConfigTypeGroupDto(){ ConfigTypeId = 3,Title = "Fourth ConfigTypeGroup",Description = "Sample4 Sentence"},
            };
            var ccSends = new List<CreateCcSendDto>()
            {
                new CreateCcSendDto(){ConfigTypeGroupId = 1, Mobile = "09131234567"},
                new CreateCcSendDto(){ConfigTypeGroupId = 2, Mobile = "09133012101"},
                new CreateCcSendDto(){ConfigTypeGroupId = 3, Mobile = "09125143232"},
            };

            //Act
            foreach (var item in configTypes)
            {
                await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", item);
            }
            foreach (var item in configTypeGroups)
            {
                await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", item);
            }
            foreach (var item in ccSends)
            {
                await PostAsync<CreateCcSendDto, CreateCcSendDto>("/CcSend/Create", item);
            }

            var ccSendList = await PostAsync < GetCcSendDto,ApiResponseEnvelope<ICollection<GetCcSendDto>>> ("/CcSend/GetList", null);

            Assert.InRange(ccSendList.Data.Count, 3,6);
        }
    }
}
