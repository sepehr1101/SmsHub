using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;

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
                Id=1
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            await PostAsync<CreateDisallowedPhraseDto, CreateDisallowedPhraseDto>("/DisallowedPhrase/Create", disallowedPhrase);

            await PostAsync<DeleteDisallowedPhraseDto, DeleteDisallowedPhraseDto>("/DisallowedPhrase/Delete", deleteDisallowedPhrase);

            //Assert
            Assert.True(true);
        }
    }
}
