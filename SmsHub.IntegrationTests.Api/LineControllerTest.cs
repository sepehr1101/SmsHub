using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Update;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class LineControllerTest : BaseIntegrationTest
    {
        public LineControllerTest(_TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateLine_LineDto_ShouldCreateLine()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Credential = "Create Line",
                Number = "Create Line"
            };

            //Act
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void DeleteLine_LineDto_ShouldDeleteLine()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Credential = "Delete Line",
                Number = "Delete Line"
            };
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);

            var deleteLine = new DeleteLineDto()
            {
                Id = lineData.Data.OrderByDescending(x=>x.Id).FirstOrDefault().Id
            };

            //Act
            await PostAsync<DeleteLineDto, DeleteLineDto>("/Line/Delete", deleteLine);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void UpdateLine_LineDto_ShouldUpdateLine()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Credential = "sample Line",
                Number = "sample Line"
            };
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);

            var updateLine = new UpdateLineDto()
            {
                Id = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                ProviderId = ProviderEnum.Magfa,
                Credential = "Update Credential",
                Number = "Update Number"
            };

            //Act
            await PostAsync<UpdateLineDto, UpdateLineDto>("/Line/Update", updateLine);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void GetSingleLine_LineDto_ShouldGetSingleLine()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Credential = "GetSigle Line",
                Number = "GetSigle Line"
            };
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);

            var lineId = new IntId()
            {
                Id = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };

            //Act
            var singleLine = await PostAsync<IntId, ApiResponseEnvelope<GetLineDto>>("/Line/GetSingle", lineId);

            //Assert
            Assert.Equal(singleLine.Data.Id, lineId.Id);
        }


        [Fact]
        public async void GetListLine_LineDto_ShouldGetListLine()
        {
            //Arrange
            var lines = new List<CreateLineDto>()
            {
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Kavenegar,Credential = "sample1 Credential",Number = "111"},
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Magfa,Credential = "sample2 Credential",Number = "150"},
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Magfa,Credential = "sample3 Credential",Number = "125"},
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Kavenegar,Credential = "sample4 Credential",Number = "152"},
            };

            //Act
            foreach (var item in lines)
            {
                await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", item);
            }
            var lineList = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);

            //Assert
            Assert.InRange(lineList.Data.Count, 4,8);
        }
    }
}
