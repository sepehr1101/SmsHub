using SmsHub.Application.Features.Sending.ServiceSample2.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts;
using MagfaRequest = SmsHub.Domain.Providers.Magfa3000.Entities.Requests;

namespace SmsHub.Application.Features.Sending.ServiceSample2.Implementations
{
    public class MagfaProvider : ISmsProvider
    {
        private static string _domain = "sampleDomain";
        private static string _userName = "sampleUserName";
        private static string _password = "samplePassword";
        private readonly IMagfa300HttpSendService _magfaSendService;
        private readonly IMagfa300HttpStatusesService _magfaStatusCodesService;
        private readonly IMagfa300HttpBalanceService _magfaBalanceService;
        private readonly IMagfa300HttpMidService _magfaMidService;


        public MagfaProvider(IMagfa300HttpSendService magfaSendService,
            IMagfa300HttpStatusesService magfaStatusCodesService,
            IMagfa300HttpBalanceService magfaBalanceService,
            IMagfa300HttpMidService magfaMidService)
        {
            _magfaSendService = magfaSendService;
            _magfaSendService.NotNull(nameof(MagfaProvider));

            _magfaStatusCodesService = magfaStatusCodesService;
            _magfaStatusCodesService.NotNull(nameof(MagfaProvider));

            _magfaBalanceService = magfaBalanceService;
            _magfaBalanceService.NotNull(nameof(magfaBalanceService));

            _magfaMidService= magfaMidService;
            _magfaMidService.NotNull(nameof(magfaMidService));
        }

        public async Task<long> GetCredit()
        {
            var domain = _domain;
            var userName = _userName;
            var password = _password;
            var result = await _magfaBalanceService.GetBalances(domain, userName, password);

            return result.Balance;
        }



        public async Task GetState(ICollection<long> id)
        {
            var domain = _domain;
            var userName = _userName;
            var password = _password;
            var result = await _magfaStatusCodesService.GetStatuses(domain, userName, password, id);
        }

        public async Task GetState(long id)
        {
            var domain = _domain;
            var userName = _userName;
            var password = _password;
            var result = await _magfaStatusCodesService.GetStatuses(domain, userName, password, id);
        }



        public async Task Send(string lineNumber, MobileText mobileText)
        {
            var domain = _domain;
            var userName = _userName;
            var password = _password;

            var sendDto = new MagfaRequest.SendDto()
            {
                messages = new List<string> { mobileText.Text },
                recipients = new List<string> { mobileText.Mobile },
                uids = new List<long> { mobileText.LocalId },
                senders = new List<string> { lineNumber },

            };
            var result = await _magfaSendService.SendMessage(domain, userName, password, sendDto);

        }

        public async Task Send(string lineNumber, ICollection<MobileText> mobileText)
        {
            var domain = _domain;
            var userName = _userName;
            var password = _password;

            MagfaRequest.SendDto sendDto = new MagfaRequest.SendDto()
            {
                messages = new List<string>(),
                recipients = new List<string>(),
                uids = new List<long>(),
                senders = new List<string>(),
            };

            foreach (var item in mobileText)
            {
                sendDto.senders.Add(lineNumber);
                sendDto.messages.Add(item.Text);
                sendDto.uids.Add((long)item.LocalId);
                sendDto.recipients.Add(item.Mobile);
            }

            var result = await _magfaSendService.SendMessage(domain, userName, password, sendDto);

        }


        private async Task Mid(long userId)
        {
            var domain = _domain;
            var userName = _userName;
            var password = _password;
            var result = await _magfaMidService.GetMid(domain, userName, password);
        })
    }
}
