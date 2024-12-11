using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class ConsumerLineControllerTest : BaseIntegrationTest
    {
        public ConsumerLineControllerTest(_TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateConsumerLine_ConsumerLineDto_ShouldCreateConsumerLine()
        {
            //Arrange
            var consumer = new CreateConsumerDto()
            {
                Title = "Sample Title",
                ApiKey = "Sample ApiKey",
                Description = "Sample Description"
            };
            await PostAsync<CreateConsumerDto, CreateConsumerDto>("/Consumer/Create", consumer);
            var consumerData = await PostAsync<GetConsumerDto, ApiResponseEnvelope<ICollection<GetConsumerDto>>>("/Consumer/GetList", null);

            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Kavenegar,
                Number = "12001",
                Credential = "{'apiKey': '---'}"
            };
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);

            var consumerLine = new CreateConsumerLineDto()
            {
                ConsumerId = consumerData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                LineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };

            //Act
            await PostAsync<CreateConsumerLineDto, CreateConsumerLineDto>("/ConsumerLine/Create", consumerLine);

            //Assert
            Assert.True(true);

        }


        [Fact]
        public async void DeleteConsumerLine_ConsumerLineDto_ShouldDeleteConsumerLine()
        {
            //Arrange
            var consumer = new CreateConsumerDto()
            {
                Title = "Sample Title",
                ApiKey = "Sample ApiKey",
                Description = "Sample Description"
            };
            await PostAsync<CreateConsumerDto, CreateConsumerDto>("/Consumer/Create", consumer);
            var consumerData = await PostAsync<GetConsumerDto, ApiResponseEnvelope<ICollection<GetConsumerDto>>>("/Consumer/GetList", null);

            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Kavenegar,
                Number = "12002",
                Credential = "{'apiKey': '---'}"
            };
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);

            var consumerLine = new CreateConsumerLineDto()
            {
                ConsumerId = consumerData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                LineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateConsumerLineDto, CreateConsumerLineDto>("/ConsumerLine/Create", consumerLine);
            var consumerLineData = await PostAsync<GetConsumerLineDto, ApiResponseEnvelope<ICollection<GetConsumerLineDto>>>("/ConsumerLine/GetList", null);

            var deleteConsumerLine = new DeleteConsumerLineDto()
            {
                Id = consumerLineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
            };

            //Act
            await PostAsync<DeleteConsumerLineDto, DeleteConsumerLineDto>("/ConsumerLine/Delete", deleteConsumerLine);
            //Assert
            Assert.True(true);

        }


        [Fact]
        public async void UpdateConsumerLine_ConsumerLineDto_ShouldUpdateConsumerLine()
        {
            //Arrange
            var consumer = new CreateConsumerDto()
            {
                Title = "Sample Title",
                ApiKey = "Sample ApiKey",
                Description = "Sample Description"
            };
            await PostAsync<CreateConsumerDto, CreateConsumerDto>("/Consumer/Create", consumer);
            var consumerData = await PostAsync<GetConsumerDto, ApiResponseEnvelope<ICollection<GetConsumerDto>>>("/Consumer/GetList", null);

            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Kavenegar,
                Number = "12003",
                Credential = "{'apiKey': '---'}"
            };
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);

            var consumerLine = new CreateConsumerLineDto()
            {
                ConsumerId = consumerData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                LineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateConsumerLineDto, CreateConsumerLineDto>("/ConsumerLine/Create", consumerLine);
            var consumerLineData = await PostAsync<GetConsumerLineDto, ApiResponseEnvelope<ICollection<GetConsumerLineDto>>>("/ConsumerLine/GetList", null);

            var updateConsumerLine = new UpdateConsumerLineDto()
            {
                Id = consumerLineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                ConsumerId = 1,
                LineId = 1,
            };

            //Act
            await PostAsync<UpdateConsumerLineDto, UpdateConsumerLineDto>("/ConsumerLine/Update", updateConsumerLine);

            //Assert
            Assert.True(true);

        }


        [Fact]
        public async void GetSingleConsumerLine_ConsumerLineDto_ShouldGetSingleConsumerLine()
        {
            //Arrange
            var consumer = new CreateConsumerDto()
            {
                Title = "Sample Title",
                ApiKey = "Sample ApiKey",
                Description = "Sample Description"
            };
            await PostAsync<CreateConsumerDto, CreateConsumerDto>("/Consumer/Create", consumer);
            var consumerData = await PostAsync<GetConsumerDto, ApiResponseEnvelope<ICollection<GetConsumerDto>>>("/Consumer/GetList", null);

            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Kavenegar,
                Number = "12004",
                Credential = "{'apiKey': '---'}"
            };
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);

            var consumerLine = new CreateConsumerLineDto()
            {
                ConsumerId = consumerData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                LineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateConsumerLineDto, CreateConsumerLineDto>("/ConsumerLine/Create", consumerLine);
            var consumerLineData = await PostAsync<GetConsumerLineDto, ApiResponseEnvelope<ICollection<GetConsumerLineDto>>>("/ConsumerLine/GetList", null);

            IntId consumerLineId = consumerLineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;
            //Act
            var singleConsumerLine = await PostAsync<IntId, ApiResponseEnvelope<GetConsumerLineDto>>("/ConsumerLine/GetSingle", consumerLineId);

            //Assert
            Assert.Equal(singleConsumerLine.Data.Id, consumerLineId.Id);
        }



        [Fact]
        public async void GetListConsumerLine_ConsumerLineDto_ShouldGetListConsumerLine()
        {
            //Arrange
            var consumers = new List<CreateConsumerDto>()
            {
                new CreateConsumerDto(){Title = "Sample1 Title", ApiKey = "Sample1 ApiKey",Description = "Sample1 Description"},
                new CreateConsumerDto(){Title = "Sample2 Title", ApiKey = "Sample2 ApiKey",Description = "Sample2 Description"},
                new CreateConsumerDto(){Title = "Sample3 Title", ApiKey = "Sample3 ApiKey",Description = "Sample3 Description"},
                new CreateConsumerDto(){Title = "Sample4 Title", ApiKey = "Sample4 ApiKey",Description = "Sample4 Description"},
            };

            var lines = new List<CreateLineDto>()
            {
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Kavenegar,Credential = "{'apiKey': '---'}",Number = "11215"},
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Magfa,Credential= "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }",Number = "150200"},
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Magfa,Credential= "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }",Number = "1200105"},
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Kavenegar,Credential = "{'apiKey': '---'}",Number = "1501332"},

             };
            var consumerLines = new List<CreateConsumerLineDto>()
            {
                new CreateConsumerLineDto(){ ConsumerId = 1,LineId = 3},
                new CreateConsumerLineDto(){ ConsumerId = 3,LineId = 4},
                new CreateConsumerLineDto(){ ConsumerId = 4,LineId = 2},
                new CreateConsumerLineDto(){ ConsumerId = 3,LineId = 2},
            };

            //Act
            foreach (var item in consumers)
            {
                await PostAsync<CreateConsumerDto, CreateConsumerDto>("/Consumer/Create", item);
            }
            foreach (var item in lines)
            {
                await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", item);
            }
            foreach (var item in consumerLines)
            {
                await PostAsync<CreateConsumerLineDto, CreateConsumerLineDto>("/ConsumerLine/Create", item);
            }

            var consumerLineList = await PostAsync<GetConsumerLineDto, ApiResponseEnvelope<ICollection<GetConsumerLineDto>>>("/ConsumerLine/GetList", null);

            //Assert
            Assert.InRange(consumerLineList.Data.Count, 4, 8);
        }
    }
}
