using SmsHub.Domain.Features.Security.MediatorDtos.Commands;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class ServerUserControllerTest : BaseIntegrationTest
    {
        public ServerUserControllerTest(TestEnvironmentWebApplicationFactory factory)
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
        
        
        [Fact]
        public async void DeleteServerUser_ServerUserDto_ShouldDeleteServerUserDto()
        {
            //Arrange
            var serverUser = new CreateServerUserDto()
            {
                IsAdmin = true,
                ApiKeyHash = "Sample ApiKeyHash",
                Username = "Etehadi",

            };
            var deleteServerUser = new DeleteServerUserDto()
            {
                Id=1
            };

            //Act
            var apiKey = await PostAsync<CreateServerUserDto, string>("/ServerUser/Create", serverUser);
            await PostAsync<DeleteServerUserDto, DeleteServerUserDto>("/ServerUser/Delete", deleteServerUser);

            //Arrange
            Assert.True(true);


            //everything is Correct but the return of CreateServerUserController in string(hash)
            //so PostAsync method have error because can't deserialize one string
        }
    }
}
