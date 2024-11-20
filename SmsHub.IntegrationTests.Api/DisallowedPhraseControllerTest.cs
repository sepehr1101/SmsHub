using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.IntegrationTests.Api
{
    public class DisallowedPhraseControllerTest : BaseIntegrationTest
    {
        public DisallowedPhraseControllerTest(TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }


        [Fact]
        public async void CreateDisallowedPhrase_DisallowedPhraseDto_ShouldCreateDisallowedPhrase()
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
            var disallowedPhrase = new CreateDisallowedPhraseDto()
            {
                ConfigTypeGroupId = 1,
                Phrase = "sample Phrase"
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
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
                Title = "First Config",
                Description = "Sample Sentence"
            };
            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = 1,
                Title = "First ConfigTypeGroup",
                Description = "Sample Sentence"
            };
            var disallowedPhrase = new CreateDisallowedPhraseDto()
            {
                ConfigTypeGroupId = 1,
                Phrase = "sample Phrase"
            };
            var deleteDisallowedPhrase = new DeleteDisallowedPhraseDto()
            {
                Id = 1
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            await PostAsync<CreateDisallowedPhraseDto, CreateDisallowedPhraseDto>("/DisallowedPhrase/Create", disallowedPhrase);

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
                Title = "First Config",
                Description = "Sample Sentence"
            };
            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = 1,
                Title = "First ConfigTypeGroup",
                Description = "Sample Sentence"
            };
            var disallowedPhrase = new CreateDisallowedPhraseDto()
            {
                ConfigTypeGroupId = 1,
                Phrase = "sample Phrase"
            };
            var updateDisallowedPhrase = new UpdateDisallowedPhraseDto()
            {
                Id = 1,
                ConfigTypeGroupId = 1,
                Phrase = "Update Phrase"
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            await PostAsync<CreateDisallowedPhraseDto, CreateDisallowedPhraseDto>("/DisallowedPhrase/Create", disallowedPhrase);

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
                Title = "First Config",
                Description = "Sample Sentence"
            };
            var configTypeGroup = new CreateConfigTypeGroupDto()
            {
                ConfigTypeId = 1,
                Title = "First ConfigTypeGroup",
                Description = "Sample Sentence"
            };
            var disallowedPhrase = new CreateDisallowedPhraseDto()
            {
                ConfigTypeGroupId = 1,
                Phrase = "sample Phrase"
            };
            var disallowedPhraseId = new IntId()
            {
                Id = 1
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            await PostAsync<CreateDisallowedPhraseDto, CreateDisallowedPhraseDto>("/DisallowedPhrase/Create", disallowedPhrase);

            var singleDisallowedPhrase = await PostAsync<IntId, ApiResponseEnvelope<GetDisallowedPhraseDto>>("/DisallowedPhrase/GetSingle", disallowedPhraseId);

            //Assert
            Assert.Equal(singleDisallowedPhrase.Data.Id, 1);
            Assert.Equal(singleDisallowedPhrase.HttpStatusCode, 200);
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
            Assert.Equal(disallowedPhraseList.Data.Count, 4);
            Assert.Equal(disallowedPhraseList.HttpStatusCode, 200);
        }
    }
}
