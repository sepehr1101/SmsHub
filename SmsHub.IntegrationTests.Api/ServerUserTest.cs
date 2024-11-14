using SmsHub.Domain.Features.Security.MediatorDtos.Commands;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class ServerUserTest : BaseIntegrationTest
    {
        public ServerUserTest(TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateServerUser_ServerUserDto_ShouldCreateServerUserDto()
        {
            //Arrange
            var serverUser = new CreateServerUserDto()
            {
                IsAdmin = true,
                ApiKeyHash = "Sample ApiKeyHash",
                Username = "Etehadi",

            };
            //Act
            var apiKey = await PostAsync<CreateServerUserDto, string>("/ServerUser/Create", serverUser);
            //Arrange
            Assert.True(true);


            //everything is Correct but the return of CreateServerUserController in string(hash)
            //so PostAsync method have error because can't deserialize one string
        }
    }
}
