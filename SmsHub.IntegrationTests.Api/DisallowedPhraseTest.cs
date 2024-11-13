using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;

namespace SmsHub.IntegrationTests.Api
{
    public class DisallowedPhraseTest : BaseIntegrationTest
    {
        public DisallowedPhraseTest(TestEnvironmentWebApplicationFactory factory)
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
            var phrase = new CreateDisallowedPhraseDto()
            {
                ConfigTypeGroupId = 1,
                Phrase = "sample Phrase"
            };

            //Act
            await PostAsync<CreateConfigTypeDto, CreateConfigTypeDto>("/ConfigType/Create", configType);
            //Assert
            Assert.True(true);

            //Act
            await PostAsync<CreateConfigTypeGroupDto, CreateConfigTypeGroupDto>("/ConfigTypeGroup/Create", configTypeGroup);
            //Assert
            Assert.True(true);

            //Act
            await PostAsync<CreateDisallowedPhraseDto, CreateDisallowedPhraseDto>("/DisallowedPhrase/Create", phrase);
            //Assert
            Assert.True(true);
        }
    }
}
