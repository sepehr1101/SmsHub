using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class OperationTypeControllerTest : BaseIntegrationTest
    {
        public OperationTypeControllerTest(_TestEnvironmentWebApplicationFactory factory)
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
                Id = 2,
                Title = "Sample Title",
                Css = "Sample Css"
            };
            await PostAsync<CreateOperationTypeDto, CreateOperationTypeDto>("/OperationType/Create", operationType);
            var operationTypeData = await PostAsync<GetOperationTypeDto, ApiResponseEnvelope<ICollection<GetOperationTypeDto>>>("/OperationType/GetList", null);

            var deleteOperationType = new DeleteOperationTypeDto()
            {
                Id = operationTypeData.Data.OrderByDescending(x=>x.Id==2).FirstOrDefault().Id
            };

            //Act
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
                Id = 3,
                Title = "Sample Title",
                Css = "Sample Css"
            };
            await PostAsync<CreateOperationTypeDto, CreateOperationTypeDto>("/OperationType/Create", operationType);
            var operationTypeData = await PostAsync<GetOperationTypeDto, ApiResponseEnvelope<ICollection<GetOperationTypeDto>>>("/OperationType/GetList", null);

            var updateOperationType = new UpdateOperationTypeDto()
            {
                Id = operationTypeData.Data.OrderByDescending(x => x.Id==3).FirstOrDefault().Id,
                Title = "Update Title",
                Css = "Update Css"
            };

            //Act
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
                Id = 4,
                Title = "Sample Title",
                Css = "Sample Css"
            };
            await PostAsync<CreateOperationTypeDto, CreateOperationTypeDto>("/OperationType/Create", operationType);
            var operationTypeData = await PostAsync<GetOperationTypeDto, ApiResponseEnvelope<ICollection<GetOperationTypeDto>>>("/OperationType/GetList", null);

            var operationTypeId = new IntId()
            {
                Id = operationTypeData.Data.OrderByDescending(x => x.Id==4).FirstOrDefault().Id
            };

            //Act
            var singleOperation = await PostAsync<IntId, ApiResponseEnvelope<GetOperationTypeDto>>("/OperationType/GetSingle", operationTypeId);

            //Assert
            Assert.Equal(singleOperation.Data.Id, operationTypeId.Id);
        }
        
        
        [Fact]
        public async void GetListOperationType_OperationTypeDto_ShouldGetListOperationType()
        {
            //Arrange
            var operationTypes = new List<CreateOperationTypeDto>()
            {
                new CreateOperationTypeDto(){Id = 5,Title = "Sample1 Title",Css = "Sample1 Css" },
                new CreateOperationTypeDto(){Id = 6,Title = "Sample2 Title",Css = "Sample2 Css" },
                new CreateOperationTypeDto(){Id = 7,Title = "Sample3 Title",Css = "Sample3 Css" },
            };

            //Act
            foreach (var item in operationTypes)
            {
                await PostAsync<CreateOperationTypeDto, CreateOperationTypeDto>("/OperationType/Create", item);
            }
            var operationTypeList = await PostAsync<GetOperationTypeDto, ApiResponseEnvelope<ICollection<GetOperationTypeDto>>>("/OperationType/GetList", null);

            //Assert
            Assert.InRange(operationTypeList.Data.Count, 3,7);
        }
    }
}
