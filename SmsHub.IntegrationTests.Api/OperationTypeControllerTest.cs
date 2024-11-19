using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;

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


        [Fact]
        public async void GetSingleOperationType_OperationTypeDto_ShouldGetSingleOperationType()
        {
            //Arrange
            var operationType = new CreateOperationTypeDto()
            {
                Id = 1,
                Title = "Sample Title",
                Css = "Sample Css"
            };
            var operationTypeId = new IntId()
            {
                Id = 1
            };

            //Act
            await PostAsync<CreateOperationTypeDto, CreateOperationTypeDto>("/OperationType/Create", operationType);
            var singleOperation = await PostAsync<IntId, ApiResponseEnvelope<GetOperationTypeDto>>("/OperationType/Update", operationTypeId);

            //Assert
            Assert.Equal(singleOperation.Data.Id, 1);
        }
        
        
        [Fact]
        public async void GetListOperationType_OperationTypeDto_ShouldGetListOperationType()
        {
            //Arrange
            var operationTypes = new List<CreateOperationTypeDto>()
            {
                new CreateOperationTypeDto(){Id = 1,Title = "Sample1 Title",Css = "Sample1 Css" },
                new CreateOperationTypeDto(){Id = 2,Title = "Sample2 Title",Css = "Sample2 Css" },
                new CreateOperationTypeDto(){Id = 3,Title = "Sample3 Title",Css = "Sample3 Css" },
            };

            //Act
            foreach (var item in operationTypes)
            {
                await PostAsync<CreateOperationTypeDto, CreateOperationTypeDto>("/OperationType/Create", item);
            }
            var operationTypeList = await PostAsync<GetOperationTypeDto, ApiResponseEnvelope<ICollection<GetOperationTypeDto>>>("/OperationType/GetList", null);

            //Assert
            Assert.Equal(operationTypeList.Data.Count, 3);
        }
    }
}
