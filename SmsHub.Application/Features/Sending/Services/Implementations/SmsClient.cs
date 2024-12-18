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
        public SmsClient(IKavenegarHttpSendSimpleService restClient)
        {
            _restClient = restClient;
            _restClient.NotNull(nameof(restClient));
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
    }
}
