using SmsHub.Application.Features.Sending.Services.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts;
using MagfaRequest = SmsHub.Domain.Providers.Magfa3000.Entities.Requests;

namespace SmsHub.Application.Features.Sending.Services.Implementations
{
    public class SmsClientMagfa: ISmsClientMagfa
    {
        private static string _domain = "sampleDomain";
        private static string _userName = "sampleUserName";
        private static string _password="samplePassword";
        private readonly IMagfa300HttpBalanceService _magfaBalanceService;
        private readonly IMagfa300HttpMessagesService _magfaMessagesService;
        private readonly IMagfa300HttpMidService _magfaMidService;
        private readonly IMagfa300HttpSendService _magfaSendService;
        private readonly IMagfa300HttpStatusesService _magfaStatusCodesService;

        public SmsClientMagfa(IMagfa300HttpBalanceService magfaBalanceService
            , IMagfa300HttpMessagesService magfaMessagesService
            ,IMagfa300HttpMidService magfa300HttpMidService
            , IMagfa300HttpSendService magfa300HttpSendService
            ,IMagfa300HttpStatusesService magfaStatusCodesService)
        {
            _magfaBalanceService = magfaBalanceService;
            _magfaBalanceService.NotNull(nameof(magfaBalanceService));

            _magfaMessagesService = magfaMessagesService;
            _magfaMessagesService.NotNull(nameof(magfaMessagesService));

            _magfaMidService = magfa300HttpMidService;
            _magfaMidService.NotNull(nameof(magfa300HttpMidService));

            _magfaSendService = magfa300HttpSendService;
            _magfaSendService.NotNull(nameof(magfa300HttpSendService));

            _magfaStatusCodesService = magfaStatusCodesService;
            _magfaStatusCodesService.NotNull(nameof(magfaStatusCodesService));
        }

        public async Task BalanceMagfaTest()//todo: debug Error
        {
            var domain = _domain;
            var userName = _userName;
            var password = _password;
            var result = await _magfaBalanceService.GetBalances(domain, userName, password);
        }

        public async Task MessageMagfaTest()     
        {
            var domain = _domain;
            var userName = _userName;
            var password = _password;
            var result=await _magfaMessagesService.GetMessages(domain, userName, password);
        }

        public async Task MidMagfaTest()
        {
            var domain = _domain;
            var userName = _userName;
            var password = _password;
            var uid = (long)1200000;
            var result=await _magfaMidService.GetMid(domain, userName, password,uid);
        }

        public async Task SendMagfaTest()
        {
            var domain = _domain;
            var userName = _userName;
            var password = _password;
            var request = new HttpRequestMessage();
            var value=new MagfaRequest.SendDto()
            {
                senders = new[] { "30001", "30001", "30001" },
                recipients = new[] { "09925306265", "09925306265", "09925306265" },
                messages = new[] {"سلام این یک پیام جهت تست متد ارسال از مگفا است",
                                "سلام این یک پیام جهت تست متد ارسال از مگفا است",
                                "سلام این یک پیام جهت تست متد ارسال از مگفا است" },
                uids = new[] { Convert.ToInt64(1201), 1202, 1203 },
            };


            var result =await _magfaSendService.SendMessage(domain, userName, password,value);
        }

        public async Task StatusesMagfaTest()
        { 

            var domain = _domain;
            var userName = _userName;
            var password = _password;
            long uid = (long)150000;

            var result=await _magfaStatusCodesService.GetStatuses(domain, userName, password, uid);
        }
    }
}
