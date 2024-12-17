using Docker.DotNet.Models;
using Microsoft.AspNetCore.Http;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;
using SmsHub.Domain.Features.Security.Dtos;
using SmsHub.Domain.Features.Security.MediatorDtos.Commands;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Template.MediatorDtos.Queries;
using System.Reflection;
using System.Security.Cryptography;
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
        public async void SendManager_CreateSendManager_ShouldPass() ////for test pleas change BatchSize=200 To BatchSize=2 in ProviderSeader for Magha
        {
            var requestBody = new[] { new { UserName = "Etehadi", Mobile = "09133022332" } };

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

            var templateData = await PostAsync<GetTemplateDto, ApiResponseEnvelope<ICollection<GetTemplateDto>>>("/Template/GetList", null);
            int templateId = templateData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);
            int lineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            var result = await PostAsync<object, ApiResponseEnvelope<ICollection<MobileText>>>($"/Send/SendManager/{templateId}/{lineId}", requestBody);


            //test count

            var messageBatchList = await PostAsync<GetMessageBatchDto, ApiResponseEnvelope<ICollection<GetMessageBatchDto>>>("/MessageBatch/GetList", null);
            var messageBatch = messageBatchList.Data.OrderByDescending(x => x.Id).FirstOrDefault();

            var messagesHolderList = await PostAsync<GetMessageHolderDto, ApiResponseEnvelope<ICollection<GetMessageHolderDto>>>("/MessagesHolder/GetList", null);
            var messageHolderWithMessageBatchId = messagesHolderList.Data.Where(x => x.MessageBatchId == messageBatch.Id).ToList();

            var messageDetailList = await PostAsync<GetMessageDetailDto, ApiResponseEnvelope<ICollection<GetMessageDetailDto>>>("/MessagesDetail/GetList", null);
            var messageDetailWithMessageBatchId = messageDetailList.Data.Where(detail => messageHolderWithMessageBatchId.Any(holder => holder.Id == detail.MessagesHolderId));


            Assert.Equal(messageHolderWithMessageBatchId.Count(), 1);
            Assert.Equal(messageDetailWithMessageBatchId.Count(), 1);

        }


        [Fact]
        public async void SendManager_CreateSendManager_ShouldFailed()
        {
            var requestBody = new[] { new { UserNameOne = "Etehadi", Mobile = "09133022332" } };

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

            var templateData = await PostAsync<GetTemplateDto, ApiResponseEnvelope<ICollection<GetTemplateDto>>>("/Template/GetList", null);
            int templateId = templateData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);
            int lineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            var result = await PostAsyncWithoutDeserialize<object>($"/Send/SendManager/{templateId}/{lineId}", requestBody);


            string exception = "مقادیر وارد شده با قالب ناسازگار است";
            var x = exception.Any(s => result.Contains(s));


            Assert.True(x);
        }


        [Fact]
        public async void SendManager_SendManyMessage_ShouldPass()
        {
            var requestBody = new[]{
                         new  {Mobile="09132582588",FromDate= 1403-10-20,CostToPay= 1000,UserName= "Reza Karimi"},
                         new  {Mobile="09133022325",FromDate= 1403-10-20,CostToPay= 2000,UserName= "Mohsen Sajjadi"},
                         new  {Mobile="09215266868",FromDate=1403-10-20,CostToPay= 3000,UserName= "Mohammad mousavi"},
                         new  {Mobile="09025232625",FromDate= 1403-10-20,CostToPay= 4000,UserName= "Ali Ebrahimi"},
                         new  {Mobile="09955633623",FromDate= 1403-10-20,CostToPay= 5000,UserName= "Hadi Borhani"} };


            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }",
                Number = "1200151"
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
                Expression = "مشترک گرامی ، جناب آقای/سرکار خانم {UserName} مبلغ این دوره شما {CostToPay} است .آخرین فرصت شما جهت پرداخت تا تاریخ {FromDate} است.",
                Title = "پرداخت قبض",
                IsActive = true,
                MinCredit = 2,
                TemplateCategoryId = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);

            var templateData = await PostAsync<GetTemplateDto, ApiResponseEnvelope<ICollection<GetTemplateDto>>>("/Template/GetList", null);
            int templateId = templateData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);
            int lineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            var result = await PostAsync<object, ApiResponseEnvelope<ICollection<MobileText>>>($"/Send/SendManager/{templateId}/{lineId}", requestBody);



            //test count

            var messageBatchList = await PostAsync<GetMessageBatchDto, ApiResponseEnvelope<ICollection<GetMessageBatchDto>>>("/MessageBatch/GetList", null);
            var messageBatch = messageBatchList.Data.OrderByDescending(x => x.Id).FirstOrDefault();

            var messagesHolderList = await PostAsync<GetMessageHolderDto, ApiResponseEnvelope<ICollection<GetMessageHolderDto>>>("/MessagesHolder/GetList", null);
            var messageHolderWithMessageBatchId = messagesHolderList.Data.Where(x => x.MessageBatchId == messageBatch.Id).ToList();

            var messageDetailList = await PostAsync<GetMessageDetailDto, ApiResponseEnvelope<ICollection<GetMessageDetailDto>>>("/MessagesDetail/GetList", null);
            var messageDetailWithMessageBatchId = messageDetailList.Data.Where(detail => messageHolderWithMessageBatchId.Any(holder => holder.Id == detail.MessagesHolderId));


            Assert.Equal(messageHolderWithMessageBatchId.Count(), 3);
            Assert.Equal(messageDetailWithMessageBatchId.Count(), 5);

        }



        [Fact]
        public async void SendManager_SendManyMessageWithInvalidPropertyUserName_ShouldFailed()
        {
            var requestBody = new[]{
                         new  {Mobile="09132582588",FromDate= 1403-10-20,CostToPay= 1000,UserNam= "Reza Karimi"},
                         new  {Mobile="09133022325",FromDate= 1403-10-20,CostToPay= 2000,UserNam= "Mohsen Sajjadi"},
                         new  {Mobile="09215266868",FromDate=1403-10-20,CostToPay= 3000,UserNam= "Mohammad mousavi"},
                         new  {Mobile="09025232625",FromDate= 1403-10-20,CostToPay= 4000,UserNam= "Ali Ebrahimi"},
                         new  {Mobile="09955633623",FromDate= 1403-10-20,CostToPay= 5000,UserNam= "Hadi Borhani"} };
            //UserName  -> UserNam

            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }",
                Number = "1200152"
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
                Expression = "مشترک گرامی ، جناب آقای/سرکار خانم {UserName} مبلغ این دوره شما {CostToPay} است .آخرین فرصت شما جهت پرداخت تا تاریخ {FromDate} است.",
                Title = "پرداخت قبض",
                IsActive = true,
                MinCredit = 2,
                TemplateCategoryId = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);

            var templateData = await PostAsync<GetTemplateDto, ApiResponseEnvelope<ICollection<GetTemplateDto>>>("/Template/GetList", null);
            int templateId = templateData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);
            int lineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            var result = await PostAsyncWithoutDeserialize<object>($"/Send/SendManager/{templateId}/{lineId}", requestBody);


            var exception = "مقادیر وارد شده با قالب ناسازگار است";
            var x = exception.Any(s => result.Contains(s));


            Assert.True(x);
        }


        [Fact]
        public async void SendManager_SendManyMessageWithInvalidPropertyWasNotCostToPay_ShouldFailed()
        {
            var requestBody = new[]{
                         new  {Mobile="09132582588",FromDate= 1403-10-20,UserName= "Reza Karimi"},
                         new  {Mobile="09133022325",FromDate= 1403-10-20,UserName= "Mohsen Sajjadi"},
                         new  {Mobile="09215266868",FromDate=1403-10-20,UserName= "Mohammad mousavi"},
                         new  {Mobile="09025232625",FromDate= 1403-10-20,UserName= "Ali Ebrahimi"},
                         new  {Mobile="09955633623",FromDate= 1403-10-20,UserName= "Hadi Borhani"} };

            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }",
                Number = "1200153"
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
                Expression = "مشترک گرامی ، جناب آقای/سرکار خانم {UserName} مبلغ این دوره شما {CostToPay} است .آخرین فرصت شما جهت پرداخت تا تاریخ {FromDate} است.",
                Title = "پرداخت قبض",
                IsActive = true,
                MinCredit = 2,
                TemplateCategoryId = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);

            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);

            var templateData = await PostAsync<GetTemplateDto, ApiResponseEnvelope<ICollection<GetTemplateDto>>>("/Template/GetList", null);
            int templateId = templateData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);
            int lineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            var result = await PostAsyncWithoutDeserialize<object>($"/Send/SendManager/{templateId}/{lineId}", requestBody);


            var exception = "مقادیر وارد شده با قالب ناسازگار است";
            var x = exception.Any(s => result.Contains(s));


            Assert.True(x);
        }

        [Fact]
        public async void SendManager_SendManyMessageWithInvalidMobileValue_ShouldFailed()
        {
            var requestBody = new[]{
                         new  {Mobile="9132582588",FromDate= 1403-10-20,CostToPay=1000,UserName= "Reza Karimi"},
                         new  {Mobile="09022325",FromDate= 1403-10-20,CostToPay=2000,UserName= "Mohsen Sajjadi"},
                         new  {Mobile="09215266868",FromDate=1403-10-20,CostToPay=3000,UserName= "Mohammad mousavi"},
                         new  {Mobile="09025232625",FromDate= 1403-10-20,CostToPay=4000,UserName= "Ali Ebrahimi"},
                         new  {Mobile="09955633623",FromDate= 1403-10-20,CostToPay=5000,UserName= "Hadi Borhani"} };

            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }",
                Number = "1200154"
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
                Expression = "مشترک گرامی ، جناب آقای/سرکار خانم {UserName} مبلغ این دوره شما {CostToPay} است .آخرین فرصت شما جهت پرداخت تا تاریخ {FromDate} است.",
                Title = "پرداخت قبض",
                IsActive = true,
                MinCredit = 2,
                TemplateCategoryId = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);

            var templateData = await PostAsync<GetTemplateDto, ApiResponseEnvelope<ICollection<GetTemplateDto>>>("/Template/GetList", null);
            int templateId = templateData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);
            int lineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            var result = await PostAsyncWithoutDeserialize<object>($"/Send/SendManager/{templateId}/{lineId}", requestBody);


            var exception = "ویژگی Mobile را وارد کنید";
            var x = exception.Any(s => result.Contains(s));


            Assert.True(x);
        }

        [Fact]
        public async void SendManager_SendManyMessageWithInvalidMobileProp_ShouldFailed()
        {
            var requestBody = new[]{
                         new  {FromDate= 1403-10-20,CostToPay=1000,UserName= "Reza Karimi"},
                         new  {FromDate= 1403-10-20,CostToPay=2000,UserName= "Mohsen Sajjadi"},
                         new  {FromDate=1403-10-20,CostToPay=3000,UserName= "Mohammad mousavi"},
                         new  {FromDate= 1403-10-20,CostToPay=4000,UserName= "Ali Ebrahimi"},
                         new  {FromDate= 1403-10-20,CostToPay=5000,UserName= "Hadi Borhani"} };

            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }",
                Number = "1200155"
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
                Expression = "مشترک گرامی ، جناب آقای/سرکار خانم {UserName} مبلغ این دوره شما {CostToPay} است .آخرین فرصت شما جهت پرداخت تا تاریخ {FromDate} است.",
                Title = "پرداخت قبض",
                IsActive = true,
                MinCredit = 2,
                TemplateCategoryId = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);

            var templateData = await PostAsync<GetTemplateDto, ApiResponseEnvelope<ICollection<GetTemplateDto>>>("/Template/GetList", null);
            int templateId = templateData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);
            int lineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            var result = await PostAsyncWithoutDeserialize<object>($"/Send/SendManager/{templateId}/{lineId}", requestBody);


            var exception = "ویژگی Mobile را وارد کنید";
            var x = exception.Any(s => result.Contains(s));


            Assert.True(x);
        }

        [Fact]
        public async void SendManager_SendManyMessageWithInvalidTemplateId_ShouldFailed()
        {
            var requestBody = new[]{
                         new  {Mobile="09132582588",FromDate= 1403-10-20,CostToPay=1000,UserName= "Reza Karimi"},
                         new  {Mobile="09133022325",FromDate= 1403-10-20,CostToPay=2000,UserName= "Mohsen Sajjadi"},
                         new  {Mobile="09215266868",FromDate=1403-10-20,CostToPay=3000,UserName= "Mohammad mousavi"},
                         new  {Mobile="09025232625",FromDate= 1403-10-20,CostToPay=4000,UserName= "Ali Ebrahimi"},
                         new  {Mobile="09955633623",FromDate= 1403-10-20,CostToPay=5000,UserName= "Hadi Borhani"} };

            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }",
                Number = "1200156"
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
                Expression = "مشترک گرامی ، جناب آقای/سرکار خانم {UserName} مبلغ این دوره شما {CostToPay} است .آخرین فرصت شما جهت پرداخت تا تاریخ {FromDate} است.",
                Title = "پرداخت قبض",
                IsActive = true,
                MinCredit = 2,
                TemplateCategoryId = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);

            var templateData = await PostAsync<GetTemplateDto, ApiResponseEnvelope<ICollection<GetTemplateDto>>>("/Template/GetList", null);
            int templateId = templateData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);
            int lineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            var result = await PostAsyncWithoutDeserialize<object>($"/Send/SendManager/{templateId + 2000}/{lineId}", requestBody);


            var exception = "کد -قالب پیامک- نامعتبر است";
            var x = exception.Any(s => result.Contains(s));


            Assert.True(x);
        }


        [Fact]
        public async void SendManager_SendManyMessageWithInvalidLindeId_ShouldFailed()
        {
            var requestBody = new[]{
                         new  {Mobile="09132582588",FromDate= 1403-10-20,CostToPay=1000,UserName= "Reza Karimi"},
                         new  {Mobile="09133022325",FromDate= 1403-10-20,CostToPay=2000,UserName= "Mohsen Sajjadi"},
                         new  {Mobile="09215266868",FromDate=1403-10-20,CostToPay=3000,UserName= "Mohammad mousavi"},
                         new  {Mobile="09025232625",FromDate= 1403-10-20,CostToPay=4000,UserName= "Ali Ebrahimi"},
                         new  {Mobile="09955633623",FromDate= 1403-10-20,CostToPay=5000,UserName= "Hadi Borhani"} };

            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }",
                Number = "1200157"
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
                Expression = "مشترک گرامی ، جناب آقای/سرکار خانم {UserName} مبلغ این دوره شما {CostToPay} است .آخرین فرصت شما جهت پرداخت تا تاریخ {FromDate} است.",
                Title = "پرداخت قبض",
                IsActive = true,
                MinCredit = 2,
                TemplateCategoryId = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);

            var templateData = await PostAsync<GetTemplateDto, ApiResponseEnvelope<ICollection<GetTemplateDto>>>("/Template/GetList", null);
            int templateId = templateData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);
            int lineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            var result = await PostAsyncWithoutDeserialize<object>($"/Send/SendManager/{templateId}/{lineId + 1000}", requestBody);


            var exception = "کد -شماره خط- نامعتبر است";
            var x = exception.Any(s => result.Contains(s));


            Assert.True(x);
        }


        [Fact]
        public async void SendManager_SendManyMessageWithAdditionProp_ShouldPass()
        {
            var requestBody = new[]{
                         new  {Mobile="09132582588",FromDate= 1403-10-20,CostToPay=1000,UserName= "Reza Karimi",NotImportantValue=15},
                         new  {Mobile="09133022325",FromDate= 1403-10-20,CostToPay=2000,UserName= "Mohsen Sajjadi",NotImportantValue=20},
                         new  {Mobile="09215266868",FromDate=1403-10-20,CostToPay=3000,UserName= "Mohammad mousavi",NotImportantValue=12},
                         new  {Mobile="09025232625",FromDate= 1403-10-20,CostToPay=4000,UserName= "Ali Ebrahimi",NotImportantValue=17},
                         new  {Mobile="09955633623",FromDate= 1403-10-20,CostToPay=5000,UserName= "Hadi Borhani",NotImportantValue=5},
                         new  {Mobile="09152012523",FromDate= 1403-10-20,CostToPay=6000,UserName= "Vahid Etehadi",NotImportantValue=5},
                         new  {Mobile="09933033636",FromDate= 1403-10-20,CostToPay=7000,UserName= "Ali Reza Akhavan",NotImportantValue=5}};

            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }",
                Number = "1200158"
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
                Expression = "مشترک گرامی ، جناب آقای/سرکار خانم {UserName} مبلغ این دوره شما {CostToPay} است .آخرین فرصت شما جهت پرداخت تا تاریخ {FromDate} است.",
                Title = "پرداخت قبض",
                IsActive = true,
                MinCredit = 2,
                TemplateCategoryId = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);

            var templateData = await PostAsync<GetTemplateDto, ApiResponseEnvelope<ICollection<GetTemplateDto>>>("/Template/GetList", null);
            int templateId = templateData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);
            int lineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            var result = await PostAsync<object, ApiResponseEnvelope<ICollection<MobileText>>>($"/Send/SendManager/{templateId}/{lineId}", requestBody);



            //test count

            var messageBatchList = await PostAsync<GetMessageBatchDto, ApiResponseEnvelope<ICollection<GetMessageBatchDto>>>("/MessageBatch/GetList", null);
            var messageBatch = messageBatchList.Data.OrderByDescending(x => x.Id).FirstOrDefault();

            var messagesHolderList = await PostAsync<GetMessageHolderDto, ApiResponseEnvelope<ICollection<GetMessageHolderDto>>>("/MessagesHolder/GetList", null);
            var messageHolderWithMessageBatchId = messagesHolderList.Data.Where(x => x.MessageBatchId == messageBatch.Id);

            var messageDetailList = await PostAsync<GetMessageDetailDto, ApiResponseEnvelope<ICollection<GetMessageDetailDto>>>("/MessagesDetail/GetList", null);
            var messageDetailWithMessageBatchId = messageDetailList.Data.Where(detail => messageHolderWithMessageBatchId.Any(holder => holder.Id == detail.MessagesHolderId));


            Assert.Equal(messageHolderWithMessageBatchId.Count(), 4);
            Assert.Equal(messageDetailWithMessageBatchId.Count(), 7);

        }




        [Fact]
        public async void SendManager_SendManyMessageWithNumberInDoubleQuotation_ShouldPass()
        {
            var requestBody = new[]{
                         new  {Mobile="09132582588",FromDate= 1403-10-20,CostToPay="1000",UserName= "Reza Karimi"},
                         new  {Mobile="09133022325",FromDate= 1403-10-20,CostToPay="2000",UserName= "Mohsen Sajjadi"},
                         new  {Mobile="09215266868",FromDate= 1403-10-20,CostToPay="3000",UserName= "Mohammad mousavi"},
                         new  {Mobile="09025232625",FromDate= 1403-10-20,CostToPay="4000",UserName= "Ali Ebrahimi"},
                         new  {Mobile="09955633623",FromDate= 1403-10-20,CostToPay="5000",UserName= "Hadi Borhani"} };

            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }",
                Number = "1200159"
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
                Expression = "مشترک گرامی ، جناب آقای/سرکار خانم {UserName} مبلغ این دوره شما {CostToPay} است .آخرین فرصت شما جهت پرداخت تا تاریخ {FromDate} است.",
                Title = "پرداخت قبض",
                IsActive = true,
                MinCredit = 2,
                TemplateCategoryId = templateCategoryData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };
            await PostAsync<CreateTemplateDto, CreateTemplateDto>("/Template/Create", template);
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);

            var templateData = await PostAsync<GetTemplateDto, ApiResponseEnvelope<ICollection<GetTemplateDto>>>("/Template/GetList", null);
            int templateId = templateData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);
            int lineId = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            var result = await PostAsync<object, ApiResponseEnvelope<ICollection<MobileText>>>($"/Send/SendManager/{templateId}/{lineId}", requestBody);



            //test count

            var messageBatchList = await PostAsync<GetMessageBatchDto, ApiResponseEnvelope<ICollection<GetMessageBatchDto>>>("/MessageBatch/GetList", null);
            var messageBatch = messageBatchList.Data.OrderByDescending(x => x.Id).FirstOrDefault();

            var messagesHolderList = await PostAsync<GetMessageHolderDto, ApiResponseEnvelope<ICollection<GetMessageHolderDto>>>("/MessagesHolder/GetList", null);
            var messageHolderWithMessageBatchId = messagesHolderList.Data.Where(x => x.MessageBatchId == messageBatch.Id);

            var messageDetailList = await PostAsync<GetMessageDetailDto, ApiResponseEnvelope<ICollection<GetMessageDetailDto>>>("/MessagesDetail/GetList", null);
            var messageDetailWithMessageBatchId = messageDetailList.Data.Where(detail => messageHolderWithMessageBatchId.Any(holder => holder.Id == detail.MessagesHolderId));


            Assert.Equal(messageHolderWithMessageBatchId.Count(), 3);
            Assert.Equal(messageDetailWithMessageBatchId.Count(), 5);

        }

    }
}
