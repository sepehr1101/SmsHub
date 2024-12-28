using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class DisallowedPhraseControllerTest : BaseIntegrationTest
    {
        public DisallowedPhraseControllerTest(_TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }


        [Fact]
        public async void CreateDisallowedPhrase_DisallowedPhraseDto_ShouldCreateDisallowedPhrase()
        {
            //Arrange
            var configType = new CreateConfigTypeDto()
            {
                Title = "Create Test Config",
                Description = "Sample Sentence"
            }; 
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            var configTypeData = await PostAsync<GetConfigTypeDto, ApiResponseEnvelope<ICollection<GetConfigTypeDto>>>("/ConfigType/GetList", null);

            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = configTypeData.Data.OrderByDescending(x=>x.Id).FirstOrDefault().Id,
                Title = "Create Test ConfigTypeGroup",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            var configTypeGroupData = await PostAsync<GetConfigTypeGroupDto, ApiResponseEnvelope<ICollection<GetConfigTypeGroupDto>>>("/ConfigTypeGroup/GetList", null);

            var disallowedPhrase = new CreateDisallowedPhraseDto()
            {
                ConfigTypeGroupId = configTypeGroupData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Phrase = "Create Test Phrase"
            };

            //Act
            await PostAsync<CreateDisallowedPhraseDto, CreateDisallowedPhraseDto>("/DisallowedPhrase/Create", disallowedPhrase);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void DeleteDisallowedPhrase_DisallowedPhraseDto_ShouldDeleteDisallowedPhrase()
        {
            //Arrange
            var configType = new CreateConfigTypeDto()
            {
                Title = "Delete Test Config",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            var configTypeData = await PostAsync<GetConfigTypeDto, ApiResponseEnvelope<ICollection<GetConfigTypeDto>>>("/ConfigType/GetList", null);

            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = configTypeData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Title = "Delete Test ConfigTypeGroup",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            var configTypeGroupData = await PostAsync<GetConfigTypeGroupDto, ApiResponseEnvelope<ICollection<GetConfigTypeGroupDto>>>("/ConfigTypeGroup/GetList", null);

            var disallowedPhrase = new CreateDisallowedPhraseDto()
            {
                ConfigTypeGroupId = configTypeGroupData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Phrase = "Delete Test Phrase"
            };
            await PostAsync<CreateDisallowedPhraseDto, CreateDisallowedPhraseDto>("/DisallowedPhrase/Create", disallowedPhrase);
            var disallowedPhraseData = await PostAsync<GetDisallowedPhraseDto, ApiResponseEnvelope<ICollection<GetDisallowedPhraseDto>>>("/DisallowedPhrase/GetList", null);
            
            var deleteDisallowedPhrase = new DeleteDisallowedPhraseDto()
            {
                Id  = disallowedPhraseData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
            };

            //Act
            await PostAsync<DeleteDisallowedPhraseDto, DeleteDisallowedPhraseDto>("/DisallowedPhrase/Delete", deleteDisallowedPhrase);

            //Assert
            Assert.True(true);
        }



        [Fact]
        public async void UpdateDisallowedPhrase_DisallowedPhraseDto_ShouldUpdateDisallowedPhrase()
        {
            //Arrange
            var configType = new CreateConfigTypeDto()
            {
                Title = "Update Test Config",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            var configTypeData = await PostAsync<GetConfigTypeDto, ApiResponseEnvelope<ICollection<GetConfigTypeDto>>>("/ConfigType/GetList", null);

            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = configTypeData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Title = "Update Test ConfigTypeGroup",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            var configTypeGroupData = await PostAsync<GetConfigTypeGroupDto, ApiResponseEnvelope<ICollection<GetConfigTypeGroupDto>>>("/ConfigTypeGroup/GetList", null);

            var disallowedPhrase = new CreateDisallowedPhraseDto()
            {
                ConfigTypeGroupId = configTypeGroupData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Phrase = "Update Test Phrase"
            };
            await PostAsync<CreateDisallowedPhraseDto, CreateDisallowedPhraseDto>("/DisallowedPhrase/Create", disallowedPhrase);
            var disallowedPhraseData = await PostAsync<GetDisallowedPhraseDto, ApiResponseEnvelope<ICollection<GetDisallowedPhraseDto>>>("/DisallowedPhrase/GetList", null);

            var updateDisallowedPhrase = new UpdateDisallowedPhraseDto()
            {
                Id = disallowedPhraseData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                ConfigTypeGroupId = configTypeGroupData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Phrase = "Update Test Phrase"
            };

            //Act
            await PostAsync<UpdateDisallowedPhraseDto, UpdateDisallowedPhraseDto>("/DisallowedPhrase/Update", updateDisallowedPhrase);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void GetSingleDisallowedPhrase_DisallowedPhraseDto_ShouldGetSingleDisallowedPhrase()
        {
            //Arrange
            var configType = new CreateConfigTypeDto()
            {
                Title = "GetSingle Test Config",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            var configTypeData = await PostAsync<GetConfigTypeDto, ApiResponseEnvelope<ICollection<GetConfigTypeDto>>>("/ConfigType/GetList", null);

            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = configTypeData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Title = "GetSingle Test ConfigTypeGroup",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            var configTypeGroupData = await PostAsync<GetConfigTypeGroupDto, ApiResponseEnvelope<ICollection<GetConfigTypeGroupDto>>>("/ConfigTypeGroup/GetList", null);

            var disallowedPhrase = new CreateDisallowedPhraseDto()
            {
                ConfigTypeGroupId = configTypeGroupData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                Phrase = "GetSingle Test Phrase"
            };
            await PostAsync<CreateDisallowedPhraseDto, CreateDisallowedPhraseDto>("/DisallowedPhrase/Create", disallowedPhrase);
            var disallowedPhraseData = await PostAsync<GetDisallowedPhraseDto, ApiResponseEnvelope<ICollection<GetDisallowedPhraseDto>>>("/DisallowedPhrase/GetList", null);

            IntId disallowedPhraseId = disallowedPhraseData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            //Act
            var singleDisallowedPhrase = await PostAsync<IntId, ApiResponseEnvelope<GetDisallowedPhraseDto>>("/DisallowedPhrase/GetSingle", disallowedPhraseId);

            //Assert
            Assert.Equal(singleDisallowedPhrase.Data.Phrase, "GetSingle Test Phrase");
        }




        [Fact]
        public async void GetListDisallowedPhrase_DisallowedPhraseDto_ShouldGetListDisallowedPhrase()
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
            var disallowedPhrases = new List<CreateDisallowedPhraseDto>()
            {
                new CreateDisallowedPhraseDto(){ ConfigTypeGroupId = 1,Phrase = "sample1 Phrase"},
                new CreateDisallowedPhraseDto(){ ConfigTypeGroupId = 2,Phrase = "sample2 Phrase"},
                new CreateDisallowedPhraseDto(){ ConfigTypeGroupId = 3,Phrase = "sample3 Phrase"},
                new CreateDisallowedPhraseDto(){ ConfigTypeGroupId = 3,Phrase = "sample4 Phrase"},
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
            foreach (var item in disallowedPhrases)
            {
                await PostAsync<CreateDisallowedPhraseDto, CreateDisallowedPhraseDto>("/DisallowedPhrase/Create", item);
            }

            var disallowedPhraseList = await PostAsync<GetDisallowedPhraseDto, ApiResponseEnvelope<ICollection<GetDisallowedPhraseDto>>>("/DisallowedPhrase/GetList", null);

            //Assert
            Assert.InRange(disallowedPhraseList.Data.Count, 4,8);
        }
    }
}
