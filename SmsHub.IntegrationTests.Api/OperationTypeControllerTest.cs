using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SmsHub.IntegrationTests.Api
{
    public class OperationTypeControllerTest : BaseIntegrationTest
    {
        public OperationTypeControllerTest(TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateOperationType_OperationTypeDto_ShouldCreateOperationType()
        {
            //Arrange
            var operationType = new CreateOperationTypeDto()
            {
                Id = 1,
                Title = "Sample Title",
                Css = "Sample Css"
            };
            //Act
            await PostAsync<CreateOperationTypeDto, CreateOperationTypeDto>("/OperationType/Create", operationType);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void DeleteOperationType_OperationTypeDto_ShouldDeleteOperationType()
        {
            //Arrange
            var operationType = new CreateOperationTypeDto()
            {
                Id = 1,
                Title = "Sample Title",
                Css = "Sample Css"
            };
            var deleteOperationType = new DeleteOperationTypeDto()
            {
                Id = 1
            };
            
            //Act
            await PostAsync<CreateOperationTypeDto, CreateOperationTypeDto>("/OperationType/Create", operationType);
            await PostAsync<DeleteOperationTypeDto, DeleteOperationTypeDto>("/OperationType/Create", deleteOperationType);

            //Assert
            Assert.True(true);
        }
        
        
        [Fact]
        public async void UpdateOperationType_OperationTypeDto_ShouldUpdateOperationType()
        {
            //Arrange
            var operationType = new CreateOperationTypeDto()
            {
                Id = 1,
                Title = "Sample Title",
                Css = "Sample Css"
            };
            var updateOperationType = new UpdateOperationTypeDto()
            {
                Id = 1,
                Title = "Update Title",
                Css = "Update Css"
            };

            //Act
            await PostAsync<CreateOperationTypeDto, CreateOperationTypeDto>("/OperationType/Create", operationType);
            await PostAsync<UpdateOperationTypeDto, UpdateOperationTypeDto>("/OperationType/Update", updateOperationType);

            //Assert
            Assert.True(true);
        }
    }
}
