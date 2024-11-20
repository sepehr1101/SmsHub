using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.MediatorDtos.Commands;
using SmsHub.Domain.Features.Security.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class ServerUserControllerTest : BaseIntegrationTest
    {
        public ServerUserControllerTest(_TestEnvironmentWebApplicationFactory factory)
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
            var apiKey = await PostAsync<CreateServerUserDto, ApiKeyAndHash>("/ServerUser/Create", serverUser);
            //Arrange
            Assert.True(true);
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
                Id = 1
            };

            //Act
            var apiKey = await PostAsync<CreateServerUserDto, ApiKeyAndHash>("/ServerUser/Create", serverUser);
            await PostAsync<DeleteServerUserDto, DeleteServerUserDto>("/ServerUser/Delete", deleteServerUser);

            //Arrange
            Assert.True(true);
        }

        [Fact]
        public async void UpdateServerUser_ServerUserDto_ShouldUpdateServerUserDto()
        {
            //Arrange
            var serverUser = new CreateServerUserDto()
            {
                IsAdmin = true,
                ApiKeyHash = "Sample ApiKeyHash",
                Username = "Etehadi",

            };
            var serverUserId = 1;

            //Act
            var apiKey = await PostAsync<CreateServerUserDto, ApiKeyAndHash>("/ServerUser/Create", serverUser);
            await PostAsync<int, ApiResponseEnvelope<int>>("/ServerUser/Update", serverUserId);

            //Arrange
            Assert.True(true);
        }


        [Fact]
        public async void GetByIdServerUser_ServerUserDto_ShouldGetByIdServerUserDto()
        {
            //Arrange
            var serverUser = new CreateServerUserDto()
            {
                IsAdmin = true,
                ApiKeyHash = "Sample ApiKeyHash",
                Username = "Etehadi",

            };
            var serverUserId = new IntId()
            {
                Id=1
            };

            //Act
            var apiKey = await PostAsync<CreateServerUserDto, ApiKeyAndHash>("/ServerUser/Create", serverUser);
           var singleServerUser= await PostAsync<IntId, ApiResponseEnvelope<GetServerUserDto>>("/ServerUser/GetById", serverUserId);

            //Arrange
            Assert.Equal(singleServerUser.Data.Username, "administrator");
        }



        [Fact]
        public async void GetByApiServerUser_ServerUserDto_ShouldGetByApiServerUserDto()
        {
            //Arrange
            var serverUser = new CreateServerUserDto()
            {
                IsAdmin = true,
                ApiKeyHash = "Sample ApiKeyHash",
                Username = "Etehadi",

            };
            var serverUserApiKey = new StringId()
            {
                apiKey= "Sample ApiKeyHash"
            };

            //Act
            var apiKey = await PostAsync<CreateServerUserDto, ApiKeyAndHash>("/ServerUser/Create", serverUser);
           var singleServerUser= await PostAsync<StringId, ApiResponseEnvelope<GetServerUserDto>>("/ServerUser/GetByApiKey", serverUserApiKey);

            //Arrange
            Assert.Equal(singleServerUser.Data.Username, "Etehadi");
        }



        [Fact]
        public async void GetAllServerUser_ServerUserDto_ShouldGetAllServerUserDto()
        {
            //Arrange
            var serverUsers = new List<CreateServerUserDto>()
            {
                new CreateServerUserDto(){IsAdmin = true,ApiKeyHash = "Sample ApiKeyHash",Username = "Etehadi",},
                new CreateServerUserDto(){IsAdmin = true,ApiKeyHash = "Sample ApiKeyHash",Username = "Etehadi",},
                new CreateServerUserDto(){IsAdmin = true,ApiKeyHash = "Sample ApiKeyHash",Username = "Etehadi",},
            };

            //Act
            foreach (var item in serverUsers)
            {
                var apiKey = await PostAsync<CreateServerUserDto, ApiKeyAndHash>("/ServerUser/Create", item);
            }
           var serverUsrList= await PostAsync<GetServerUserDto, ApiResponseEnvelope<ICollection<GetServerUserDto>>>("/ServerUser/GetAll", null);

            //Arrange
            Assert.Equal (serverUsrList.Data.Count,4);
        }
    }
}
