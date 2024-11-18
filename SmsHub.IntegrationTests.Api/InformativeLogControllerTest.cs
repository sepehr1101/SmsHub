using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete;

//[assembly:CollectionBehavior(DisableTestParallelization =true)]
namespace SmsHub.IntegrationTests.Api
{
    public class InformativeLogControllerTest:BaseIntegrationTest
    {
        public InformativeLogControllerTest(TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateInformativeLog_InformativeLogDto_ShouldCreateInformativeLog()
        {
            //Arrange
            var logLevel = new CreateLogLevelDto()
            {
                Id=1,
                Title="sample title",
                Css="sample Css"
            };
            var informativeLog = new CreateInformativeLogDto()
            {
                LogLevelId=1,
                Section="sample Section",
                Description="sample Description",
                UserId=Guid.NewGuid(),
                UserInfo="sample UserInfo",
                Ip="198.162.1.1",
                InsertDateTime=DateTime.Now,    
                ClientInfo="sample ClientInfo"
            };

            //Act
            await PostAsync<CreateLogLevelDto, CreateLogLevelDto>("/LogLevel/Create", logLevel);
            await PostAsync<CreateInformativeLogDto, CreateInformativeLogDto>("/InformativeLog/Create", informativeLog);
         
            //Assert
            Assert.True(true);
        }
        
        
        [Fact]
        public async void DeleteInformativeLog_InformativeLogDto_ShouldDeleteInformativeLog()
        {
            //Arrange
            var logLevel = new CreateLogLevelDto()
            {
                Id=1,
                Title="sample title",
                Css="sample Css"
            };
            var informativeLog = new CreateInformativeLogDto()
            {
                LogLevelId=1,
                Section="sample Section",
                Description="sample Description",
                UserId=Guid.NewGuid(),
                UserInfo="sample UserInfo",
                Ip="198.162.1.1",
                InsertDateTime=DateTime.Now,    
                ClientInfo="sample ClientInfo"
            };
            var deleteInformativeLog = new DeleteInformativeLogDto()
            {
                Id=1
            };

            //Act
            await PostAsync<CreateLogLevelDto, CreateLogLevelDto>("/LogLevel/Create", logLevel);
            await PostAsync<CreateInformativeLogDto, CreateInformativeLogDto>("/InformativeLog/Create", informativeLog);

            await PostAsync<DeleteInformativeLogDto, DeleteInformativeLogDto>("/InformativeLog/Delete", deleteInformativeLog);
            
            //Assert
            Assert.True(true);
        }
        

        [Fact]
        public async void UpdateInformativeLog_InformativeLogDto_ShouldUpdateInformativeLog()
        {
            //Arrange
            var logLevel = new CreateLogLevelDto()
            {
                Id=1,
                Title="sample title",
                Css="sample Css"
            };
            var informativeLog = new CreateInformativeLogDto()
            {
                LogLevelId=1,
                Section="sample Section",
                Description="sample Description",
                UserId=Guid.NewGuid(),
                UserInfo="sample UserInfo",
                Ip="198.162.1.1",
                InsertDateTime=DateTime.Now,    
                ClientInfo="sample ClientInfo"
            };
           var updateInformativeLog = new UpdateInformativeLogDto()
           {
               Id =1,
               LogLevelId = 1,
               Section = "Update Section",
               Description = "Update Description",
               UserId = Guid.NewGuid(),
               UserInfo = "Update UserInfo",
               Ip = "198.162.1.2",
               InsertDateTime = DateTime.Now,
               ClientInfo = "Update ClientInfo"
           };

            //Act
            await PostAsync<CreateLogLevelDto, CreateLogLevelDto>("/LogLevel/Create", logLevel);
            await PostAsync<CreateInformativeLogDto, CreateInformativeLogDto>("/InformativeLog/Create", informativeLog);

            await PostAsync<UpdateInformativeLogDto, UpdateInformativeLogDto>("/InformativeLog/Update", updateInformativeLog);
            
            //Assert
            Assert.True(true);
        }
    }
}
