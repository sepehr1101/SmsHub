using SmsHub.Application.Features.Sending.Services.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Providers.Kavenegar.Entities.Requests;
using SmsHub.Infrastructure.BaseHttp.Client.Contracts;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts;
using SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Application.Features.Sending.Services.Implementations
{
    public class SmsClientKevenegar : ISmsClientKevenegar
    {
        private static string _kaveApi = "5575426A68495063786333776662677171397533775377746A5A696475386159574332463078442F7750553D";
        private readonly IKavenegarHttpSendSimpleService _restClient;
        private readonly IKavenegarHttpAccountService _accountService;
        private readonly IKavenegarHttpStatusService _statusService;
        private readonly IKavenegarHttpStatusByMessageIdService _statusByMessageIdService;
        private readonly IKavenegarHttpSendArrayService _sendArrayService;
        private readonly IKavenegarHttpReceiveService _receiveService;
        private readonly IKavenegarHttpCancelService _cancelService;
        private readonly IKavenegarHttpCountInboxService _countInboxService;
        private readonly IKavenegarHttpDateService _dateService;
        private readonly IKavenegarHttpLatestOutboxService _latestOutboxService;
        private readonly IKavenegarHttpLookupService _lookupService;
        private readonly IKavenegarHttpMakettsService _makettsService;
        private readonly IKavenegarHttpSelectOutboxService _selectOutboxService;
        private readonly IKavenegarHttpSelectService _selectService;
        public SmsClientKevenegar(IKavenegarHttpSendSimpleService restClient
            , IKavenegarHttpAccountService accountService,
            IKavenegarHttpStatusService statusService,
            IKavenegarHttpStatusByMessageIdService statusByMessageIdService,
            IKavenegarHttpSendArrayService sendArrayService,
            IKavenegarHttpReceiveService receiveService,
            IKavenegarHttpCancelService cancelService,
            IKavenegarHttpCountInboxService countInboxService,
            IKavenegarHttpDateService dateService,
            IKavenegarHttpLatestOutboxService latestOutboxService,
            IKavenegarHttpLookupService lookupService,
            IKavenegarHttpMakettsService makettsService,
            IKavenegarHttpSelectOutboxService selectOutboxService,
            IKavenegarHttpSelectService selectService)
        {
            _restClient = restClient;
            _restClient.NotNull(nameof(restClient));

            _accountService = accountService;
            _accountService.NotNull(nameof(accountService));

            _statusService = statusService;
            _statusService.NotNull(nameof(statusService));

            _statusByMessageIdService = statusByMessageIdService;
            _statusByMessageIdService.NotNull(nameof(statusByMessageIdService));

            _sendArrayService = sendArrayService;
            _sendArrayService.NotNull(nameof(sendArrayService));

            _receiveService = receiveService;
            _receiveService.NotNull(nameof(receiveService));

            _cancelService = cancelService;
            _cancelService.NotNull(nameof(cancelService));

            _countInboxService = countInboxService;
            _countInboxService.NotNull(nameof(countInboxService));

            _dateService = dateService;
            _dateService.NotNull(nameof(dateService));

            _latestOutboxService = latestOutboxService;
            _latestOutboxService.NotNull(nameof(latestOutboxService));

            _lookupService = lookupService;
            _lookupService.NotNull(nameof(lookupService));

            _makettsService = makettsService;
            _makettsService.NotNull(nameof(makettsService));

            _selectOutboxService = selectOutboxService;
            _selectOutboxService.NotNull(nameof(selectOutboxService));

            _selectService = selectService;
            _selectService.NotNull(nameof(selectService));
        }
        public async Task Send(MessageBatch messageBatch, Provider provider, Domain.Features.Entities.Line line)
        {
            var apiKey = _kaveApi;
            var sendSimpleDto = new SimpleSendDto("09135742556", "سلام این پیام جهت تست است");
            await _restClient.Trigger(sendSimpleDto, apiKey);
        }


        public async Task AcountKaveTest()
        {
            var apiKey = _kaveApi;
            var response = await _accountService.Trigger(apiKey);
        }

        public async Task CancelKaveTest()
        {
            var apiKey = _kaveApi;
            CancelDto cancelDto = 1;
            var result = await _cancelService.Trigger(cancelDto, apiKey);
        }

        public async Task CountInBoxKaveTest()//Error: The JSON value could not be converted to System.Collections.Generic.List`1[SmsHub.Domain.Providers.Kavenegar.Entities.Responses.CountInboxDto].
        {
            var apiKey = _kaveApi;
            var countInBoxDto = new CountInboxDto()
            {
                StartDate = 1734436857,
                EndDate = 1734523257,
                IsRead = 1,
                LineNumber = "2000550055505"
            };
            var result = await _countInboxService.Trigger(countInBoxDto, apiKey);
        }

        public async Task DateKaveTest()
        {
            var apiKey = _kaveApi;
            var result = await _dateService.Trigger();
        }

        public async Task LatestOutboxKaveTest()
        {
            var apiKey = _kaveApi;
            var latestOutboxDto = new LatestOutboxDto()
            {
                PageSize = 10,
                Sender = "2000550055505"
            };
            var result = await _latestOutboxService.Trigger(latestOutboxDto, apiKey);
        }//statusCode=407 ->Change ip

        public async Task LookupKaveTest()//statusCode=424 , where is sender?
        {
            var apiKey = _kaveApi;
            var lookupDto = new LookupDto()
            {
                Receptor = "09925306265",
                Template = "سلام token% رمز عبور:token2% ، نام کاربری:token3% ",
                Token = "Z_E",
                Token2 = "100200",
                Token3 = "Etehadi",
                Type = "sms"
            };
            var result = await _lookupService.Trigger(lookupDto, apiKey);

        }

        public async Task MakettsKaveTest()//
        {
            var apiKey = _kaveApi;
            var makettsDto = new MakettsDto()
            {
                Receptor = "09925306265",
                Date = 1734521400,
                Message = "سلام.این یک پیام جهت تست تابع Maketts است.",
                Repeat = 2,
                LocalId = ""//???
            };
            var result = await _makettsService.Trigger(makettsDto, apiKey);
        }

        public async Task ReceiveKaveTest()//
        {
            var apiKey = _kaveApi;
            var receiveDto = new ReceiveDto("2000550055505", true);//true and false return (200 but without any message) 
            var resultReceive = await _receiveService.Trigger(receiveDto, apiKey);
        }

        public async Task SelectOutboxKaveTest()//statusCode=407 ->change local ip 
        {
            var apiKey = _kaveApi;
            var selectOutboxDto = new SelectOutboxDto()
            {
                StartDate = 1734436857,
                EndDate = 1734523257,
                Sender = "2000550055505"
            };
            var result = await _selectOutboxService.Trigger(selectOutboxDto, apiKey);
        }

        public async Task SelectKaveTest()//statusCode=407 ->change local ip
        {
            var apiKey = _kaveApi;
            SelectDto selectDto = 1828205579;//can send Several with "," but it's long
            var result = await _selectService.Trigger(selectDto, apiKey);
        }

        public async Task SendArrayKeveTest()
        {
            var apiKey = _kaveApi;

            var SendArrayDto = new ArraySendDto()
            {
                Message = [ "سلام این پیام اول-1 جهت تست است", "سلام این پیام دوم-2 جهت تست است",
                             "سلام این پیام سوم-3 جهت تست است", "سلام این پیام چهارم-4 جهت تست است" ],

                Receptor = ["09135742556", "09925306265", "09135742556", "09925306265"],
                Sender = ["2000550055505", "2000550055505", "2000550055505", "2000550055505"],
                Date = 734509359,
                Hide = 1,
                LocalMessageIds = [1, 2, 3, 4],
                // Type = [1,1,1,1]
            };
            var result = await _sendArrayService.Trigger(SendArrayDto, apiKey);
        }//ok

        public async Task SendSimpleKaveTest()//ok
        {
            var apiKey = _kaveApi;

            //var sendSimpleDto = new SimpleSendDto()
            //{
            //    Sender= "2000550055505",
            //    Receptor="09925306265",
            //    Message="این یک پیام جهت تست Status است",
            //    LocalId= 1200//->messageId=1828205579
            //};

            var sendSimpleDto = new SimpleSendDto("09135742556", "سلام این پیام جهت تست است", "2000550055505");
            var response = await _restClient.Trigger(sendSimpleDto, apiKey);
        }

        public async Task StatusByMessageKaveTest()//ok -> return messageId and Status
        {
            var apiKey = _kaveApi;

            //var sendSimpleDto = new SimpleSendDto("09135742556", "سلام این پیام جهت تست است", "2000550055505");
            //var response = await _restClient.Trigger(sendSimpleDto, apiKey);

            StatusByMessageIdDto statusByMessageId = 1200;
            var result = await _statusByMessageIdService.Trigger(statusByMessageId, apiKey);
        }

        public async Task StatusKaveTest()//ok -> return messageId and Status
        {
            var apiKey = _kaveApi;
            
            StatusDto status = 1828205579;
            var result = await _statusService.Trigger(status, apiKey);
        }


        /////////////////////////////Magfa

    }
}
