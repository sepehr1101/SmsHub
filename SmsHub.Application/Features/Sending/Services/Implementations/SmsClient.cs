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
    public class SmsClient : ISmsClient
    {
        private static string _kaveApi= "s";
        private readonly IKavenegarHttpSendSimpleService _restClient;
        private readonly IKavenegarHttpAccountService _accountService;
        private readonly IKavenegarHttpStatusService _statusService;
        private readonly IKavenegarHttpStatusByMessageIdService _statusByMessageIdService;
        private readonly IKavenegarHttpSendArrayService _sendArrayService;
        private readonly IKavenegarHttpReceiveService _receiveService;
        public SmsClient(IKavenegarHttpSendSimpleService restClient
            , IKavenegarHttpAccountService accountService,
            IKavenegarHttpStatusService statusService,
            IKavenegarHttpStatusByMessageIdService statusByMessageIdService,
            IKavenegarHttpSendArrayService sendArrayService,
            IKavenegarHttpReceiveService receiveService)
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
        }
        public async Task Send(MessageBatch messageBatch, Provider provider, Domain.Features.Entities.Line line)
        {
            var apiKey = _kaveApi;
            var sendSimpleDto = new SimpleSendDto("09135742556", "سلام این پیام جهت تست است");
            await _restClient.Trigger(sendSimpleDto, apiKey);
        }
        public async Task SendKaveTest()
        {
            var apiKey = _kaveApi;
            var sendSimpleDto = new SimpleSendDto("09135742556", "سلام این پیام جهت تست است", "2000550055505");
            var response= await _restClient.Trigger(sendSimpleDto, apiKey);
        }

        public async Task AcountKave()
        {
            var apiKey=_kaveApi;
            var response=await _accountService.Trigger(apiKey);
        }

        public async Task StatusKave()
        {
            var apiKey= _kaveApi;

            var sendSimpleDto = new SimpleSendDto("09135742556", "سلام این پیام جهت تست است", "2000550055505");
            var response = await _restClient.Trigger(sendSimpleDto, apiKey);

            StatusDto status = 1;
            var result = await _statusService.Trigger(status, apiKey);
        }

        public async Task StatusByMessageKave()
        {
            var apiKey=_kaveApi;

            var sendSimpleDto = new SimpleSendDto("09135742556", "سلام این پیام جهت تست است", "2000550055505");
            var response = await _restClient.Trigger(sendSimpleDto, apiKey);

            StatusByMessageIdDto statusByMessageId = 1;
            var result = await _statusByMessageIdService.Trigger(statusByMessageId, apiKey);
        }

        public async Task SendArrayKeve()
        {
            var apiKey = _kaveApi;

            var SendArrayDto = new ArraySendDto()
            {
                Message =  [ "سلام این پیام اول-1 جهت تست است", "سلام این پیام دوم-2 جهت تست است",
                             "سلام این پیام سوم-3 جهت تست است", "سلام این پیام چهارم-4 جهت تست است" ],

                Receptor = ["09135742556", "09925306265", "09135742556", "09925306265"],
                Sender = ["2000550055505", "2000550055505", "2000550055505", "2000550055505" ],
                Date= 734509359,
                Hide=1,
                LocalMessageIds = [1,2,3,4],
               // Type = [1,1,1,1]
            };
            var result=await _sendArrayService.Trigger(SendArrayDto, apiKey);
            int x = 2;
        }

        public async Task ReceiveKave()
        {
            var apiKey= _kaveApi;

            var SendArrayDto = new ArraySendDto()
            {
                Message = [ "سلام این پیام اول جهت تست است", "سلام این پیام دوم جهت تست است",
                             "سلام این پیام سوم جهت تست است", "سلام این پیام چهارم جهت تست است" ],

                Receptor = ["09135742556", "09925306265", "09135742556", "09925306265"],
                Sender = ["30002", "30002", "30001", "30003"],
            };
            var resultSendArray =await _sendArrayService.Trigger(SendArrayDto, apiKey);

            var receiveDto = new ReceiveDto("30002",false);
            var resultReceive=await _receiveService.Trigger(receiveDto, apiKey);
        }

    }
}
