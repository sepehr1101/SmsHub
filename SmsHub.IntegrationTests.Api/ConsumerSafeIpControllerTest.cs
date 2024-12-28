using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class ConsumerSafeIpControllerTest : BaseIntegrationTest
    {
        public ConsumerSafeIpControllerTest(_TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateConsumerSafeIp_ConsumerSafeIpDto_ShouldCreateConsumerSafeIp()
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

            var consumerSafeIp = new CreateConsumerSafeIpDto()
            {
                ConsumerId = consumerData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                FromIp = "198.162.1.1",
                IsV6 = false,
                ToIp = "198.162.1.2"
            };

            //Act
            await PostAsync<CreateConsumerSafeIpDto, CreateConsumerSafeIpDto>("/ConsumerSafeIp/Create", consumerSafeIp);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void DeleteConsumerSafeIp_ConsumerSafeIpDto_ShouldDeleteConsumerSafeIp()
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

            var consumerSafeIp = new CreateConsumerSafeIpDto()
            {
                ConsumerId = consumerData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                FromIp = "198.162.1.1",
                IsV6 = false,
                ToIp = "198.162.1.2"
            };
            await PostAsync<CreateConsumerSafeIpDto, CreateConsumerSafeIpDto>("/ConsumerSafeIp/Create", consumerSafeIp);
            var consumerSafeIpData = await PostAsync<GetConsumerSafaIpDto, ApiResponseEnvelope<ICollection<GetConsumerSafaIpDto>>>("/ConsumerSafeIp/GetList", null);

            var deleteConsumerSafeIp = new DeleteConsumerSafeIpDto()
            {
                Id = consumerSafeIpData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
            };

            //Act
            await PostAsync<DeleteConsumerSafeIpDto, DeleteConsumerSafeIpDto>("/ConsumerSafeIp/Delete", deleteConsumerSafeIp);
          
            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void UpdateConsumerSafeIp_ConsumerSafeIpDto_ShouldUpdateConsumerSafeIp()
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

            var consumerSafeIp = new CreateConsumerSafeIpDto()
            {
                ConsumerId = consumerData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                FromIp = "198.162.1.1",
                IsV6 = false,
                ToIp = "198.162.1.2"
            };
            await PostAsync<CreateConsumerSafeIpDto, CreateConsumerSafeIpDto>("/ConsumerSafeIp/Create", consumerSafeIp);
            var consumerSafeIpData = await PostAsync<GetConsumerSafaIpDto, ApiResponseEnvelope<ICollection<GetConsumerSafaIpDto>>>("/ConsumerSafeIp/GetList", null);

            var updateConsumerSafeIp = new UpdateConsumerSafeIpDto()
            {
                Id = consumerSafeIpData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                ConsumerId = 1,
                FromIp = "198.162.1.3",
                IsV6 = false,
                ToIp = "192.168.1.21"
            };

            //Act
            await PostAsync<UpdateConsumerSafeIpDto, UpdateConsumerSafeIpDto>("/ConsumerSafeIp/Update", updateConsumerSafeIp);
           
            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void GetSingleConsumerSafeIp_ConsumerSafeIpDto_ShouldGetSingleConsumerSafeIp()
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

            var consumerSafeIp = new CreateConsumerSafeIpDto()
            {
                ConsumerId = consumerData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                FromIp = "198.162.2.40",
                IsV6 = false,
                ToIp = "198.162.1.2"
            };
            await PostAsync<CreateConsumerSafeIpDto, CreateConsumerSafeIpDto>("/ConsumerSafeIp/Create", consumerSafeIp);
            var consumerSafeIpData = await PostAsync<GetConsumerSafaIpDto, ApiResponseEnvelope<ICollection<GetConsumerSafaIpDto>>>("/ConsumerSafeIp/GetList", null);

            IntId consumerSafeIpId = consumerSafeIpData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;
           
            //Act
            var singleConsumerSafeIp = await PostAsync<IntId, ApiResponseEnvelope<GetConsumerSafaIpDto>>("/ConsumerSafeIp/GetSingle", consumerSafeIpId);

            //Assert
            Assert.Equal(singleConsumerSafeIp.Data.FromIp, "198.162.2.40");
        }
        
        
        [Fact]
        public async void GetListConsumerSafeIp_ConsumerSafeIpDto_ShouldGetListConsumerSafeIp()
        {
            //Arrange
            var consumers = new List<CreateConsumerDto>()
            {
                new CreateConsumerDto(){Title = "Sample1 Title", ApiKey = "Sample1 ApiKey",Description = "Sample1 Description"},
                new CreateConsumerDto(){Title = "Sample2 Title", ApiKey = "Sample2 ApiKey",Description = "Sample2 Description"},
                new CreateConsumerDto(){Title = "Sample3 Title", ApiKey = "Sample3 ApiKey",Description = "Sample3 Description"},
            };
            var consumerSafeIps = new List<CreateConsumerSafeIpDto>()
            {
                new CreateConsumerSafeIpDto(){ConsumerId = 1,FromIp = "198.162.1.1",IsV6 = false, ToIp = "198.162.2.1"},
                new CreateConsumerSafeIpDto(){ConsumerId = 2,FromIp = "198.162.1.2",IsV6 = false, ToIp = "198.162.2.2"},
                new CreateConsumerSafeIpDto(){ConsumerId = 3,FromIp = "198.162.1.3",IsV6 = false, ToIp = "198.162.2.3"},
                new CreateConsumerSafeIpDto(){ConsumerId = 1,FromIp = "198.162.1.4",IsV6 = false, ToIp = "198.162.2.4"},
            };

            //Act
            foreach (var item in consumers)
            {
                await PostAsync<CreateConsumerDto, CreateConsumerDto>("/Consumer/Create", item);
            }
            foreach (var item in consumerSafeIps)
            {
                await PostAsync<CreateConsumerSafeIpDto, CreateConsumerSafeIpDto>("/ConsumerSafeIp/Create", item);
            }

            var consumerSafeIpList = await PostAsync<GetConsumerSafaIpDto, ApiResponseEnvelope<ICollection<GetConsumerSafaIpDto>>>("/ConsumerSafeIp/GetList", null);

            //Assert
            Assert.InRange(consumerSafeIpList.Data.Count, 4,6);
        }
    }
}
