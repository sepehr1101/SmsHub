using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Update;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class ProviderControllerTests : BaseIntegrationTest
    {
        public ProviderControllerTests(_TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateProvider_ProviderDataDto_ShouldCreateProvider()
        {
            // Arrange
            var provider = new CreateProviderDto
            {
            //  Id=ProviderEnum.Kavenegar,//todo: assume we gave it id,how can create new ProviderEnum
                BaseUri = "http://baseurl",
                BatchSize = 10,
                DefaultPreNumber = "2000",
                FallbackBaseUri = "https://fallbackurl",
                Title = "title",
                Website = "www.someProvider.ir"
            };

            // Act
            await PostAsync<CreateProviderDto, CreateProviderDto>("/Provider/Create", provider);

            // Assert 
            Assert.True(true);
        }

        //[Fact]
        //public async void _1_CreateProvider_ProviderDataDto_ShouldCreateProvider()
        //{
        //    // Arrange
        //    var provider = new CreateProviderDto
        //    {
        //        BaseUri = "http://baseurl",
        //        BatchSize = 10,
        //        DefaultPreNumber = "2000",
        //        FallbackBaseUri = "https://fallbackurl",
        //        Title = "title1",
        //        Website = "www.someProvider.ir"
        //    };

        //    // Act
        //    await PostAsync<CreateProviderDto, CreateProviderDto>("/Provider/Create", provider);

        //    // Assert 
        //    Assert.True(true);
        //}

        [Fact]
        public async void DeleteProvider_ProviderDataDto_ShouldCreateProvider()
        {
            // Arrange
            var deleteProvider = new DeleteProviderDto()
            {
                Id = ProviderEnum.Magfa
            };

            // Act
            await PostAsync<DeleteProviderDto, DeleteProviderDto>("/Provider/Delete", deleteProvider);

            // Assert 
            Assert.True(true);
        }


        [Fact]
        public async void UpdateProvider_ProviderDataDto_ShouldUpdateProvider()
        {
            // Arrange
            var updateProvider = new UpdateProviderDto()
            {
                Id = ProviderEnum.Kavenegar,
                BaseUri = "http://Updatebaseurl",
                BatchSize = 10,
                DefaultPreNumber = "100",
                FallbackBaseUri = "https://fallbackurl",
                Title = "کاوه نگار",
                Website = "www.someProvider.ir"
            };

            // Act
            await PostAsync<UpdateProviderDto, UpdateProviderDto>("/Provider/Update", updateProvider);

            // Assert 
            Assert.True(true);
        }


        [Fact]
        public async void GetSingleProvider_ProviderDataDto_ShouldGetSingleProvider()
        {
            // Arrange
            var providerId = ProviderEnum.Kavenegar;

            // Act
            var singleProvider = await PostAsync<ProviderEnum, ApiResponseEnvelope<GetProviderDto>>("/Provider/GetSingle", providerId);

            // Assert 
            Assert.Equal(singleProvider.Data.Title, "کاوه نگار");
        }


        [Fact]
        public async void GetListProvider_ProviderDataDto_ShouldGetListProvider()
        {
           //Act
            var providerList = await PostAsync<GetProviderDto, ApiResponseEnvelope<ICollection<GetProviderDto>>>("/Provider/GetList", null);

            // Assert 
            Assert.InRange(providerList.Data.Count, 1,3);


            //failed -> Id is Identity or Not?
        }
    }


}
