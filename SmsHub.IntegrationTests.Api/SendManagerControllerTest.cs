using Docker.DotNet.Models;
using Microsoft.AspNetCore.Http;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.MediatorDtos.Commands;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Template.MediatorDtos.Queries;
using System.Reflection;
using System.Text;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]

    public class SendManagerControllerTest : BaseIntegrationTest
    {
        private readonly HttpClient _client;
        public SendManagerControllerTest(_TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
            _client = factory.CreateClient();
        }
        [Fact]
        public async void SendManager_CreateSendManager_ShouldPass()
        {
            var requestBody = new { UserName = "Etehadi", Mobile = "09133022332" };

            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }",
                Number = "1200150"
            };
            
            var templateCategory = new CreateTemplateCategoryDto()
            {
                Title = "sample TemplateCategory",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);
            var templateCategoryData = await PostAsync<GetTemplateCategoryDto, ApiResponseEnvelope<ICollection<GetTemplateCategoryDto>>>("/TemplateCategory/GetList", null);

            var template = new CreateTemplateDto()
            {
                Expression = "this is a sample template by {UserName} and {Mobile} prop",
                Title = "Sample Title",
                IsActive = true,
                MinCredit = 2,
                TemplateCategoryId = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);

            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);

            var result = await PostAsync<object, ApiResponseEnvelope<int>>("/Send/SendManager/1/1", requestBody);




            Assert.True(true);
        }
        
        
        [Fact]
        public async void SendManager_CreateSendManager_ShouldFailed()
        {
            var requestBody = new { UserNameOne = "Etehadi", Mobile = "09133022332" };

            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }",
                Number = "120010"
            };
            
            var templateCategory = new CreateTemplateCategoryDto()
            {
                Title = "sample TemplateCategory",
                Description = "Sample Sentence"
            };
            await PostAsync<CreateTemplateCategoryDto, CreateTemplateCategoryDto>("/TemplateCategory/Create", templateCategory);
            var templateCategoryData = await PostAsync<GetTemplateCategoryDto, ApiResponseEnvelope<ICollection<GetTemplateCategoryDto>>>("/TemplateCategory/GetList", null);

            var template = new CreateTemplateDto()
            {
                Expression = "this is a sample template by {UserName} and {Mobile} prop",
                Title = "Sample Title",
                IsActive = true,
                MinCredit = 2,
                TemplateCategoryId = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);

            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);

            var result = await PostAsyncWithoutDeserialize<object>("/Send/SendManager/1/1", requestBody);

            string exception = "مقادیر وارد شده با قالب ناسازگار است";
            var x = exception.Any(s => result.Contains(s));


            Assert.True(x);
        }

    }
}
