using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Sending.ServicesSample.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts;
using MagfaRequest = SmsHub.Domain.Providers.Magfa3000.Entities.Requests;

namespace SmsHub.Application.Features.Sending.ServicesSample.Implementations
{
    public class Magfa : IProviderFactory
    {

        private static string _domain = "sampleDomain";
        private static string _userName = "sampleUserName";
        private static string _password = "samplePassword";
        private readonly IMagfa300HttpBalanceService _magfaBalanceService;
        private readonly IMagfa300HttpStatusesService _magfaStatusCodesService;
        private readonly IMagfa300HttpMessagesService _magfaMessagesService;
        private readonly IMagfa300HttpSendService _magfaSendService;
        private readonly IMagfa300HttpMidService _magfaMidService;

        public Magfa(IMagfa300HttpBalanceService magfaBalanceService,
            IMagfa300HttpStatusesService magfaStatusCodesService,
            IMagfa300HttpMessagesService magfaMessagesService,
            IMagfa300HttpSendService magfaSendService,
            IMagfa300HttpMidService magfaMidService)
        {
            _magfaBalanceService = magfaBalanceService;
            _magfaBalanceService.NotNull(nameof(magfaBalanceService));

            _magfaStatusCodesService = magfaStatusCodesService;
            _magfaStatusCodesService.NotNull(nameof(magfaStatusCodesService));

            _magfaMessagesService = magfaMessagesService;
            _magfaStatusCodesService.NotNull(nameof(magfaMessagesService));

            _magfaSendService = magfaSendService;
            _magfaSendService.NotNull(nameof(magfaSendService));

            _magfaMidService = magfaMidService;
            _magfaMidService.NotNull(nameof(magfaMidService));
        }
        public async Task Account_Balance()//Error
        {
            var domain = _domain;
            var userName = _userName;
            var password = _password;
            var result = await _magfaBalanceService.GetBalances(domain, userName, password);
        }

        public async Task Status_Statuses(int messageId)
        {
            var domain = _domain;
            var userName = _userName;
            var password = _password;
            var result = await _magfaStatusCodesService.GetStatuses(domain, userName, password,messageId);
        }

        public async Task Receive_Messages(int? count, string? lineNumber)
        {
            var domain = _domain;
            var userName = _userName;
            var password = _password;
            var result = await _magfaMessagesService.GetMessages(domain, userName, password);

        }

        public async Task Send_Send(List<SendMessageDto> message)
        {
            var domain = _domain;
            var userName = _userName;
            var password = _password;

            MagfaRequest.SendDto sendDto = new MagfaRequest.SendDto()
            {
                messages = new List<string>(),
                recipients = new List<string>(),
                senders = new List<string>(),
                uids = new List<long>(),
            };

            foreach (var item in message)
            {
                sendDto.senders.Add(item.Sender);
                sendDto.messages.Add(item.Message);
                sendDto.recipients.Add(item.Receptor);
                sendDto.uids.Add((long)item.UserId);
            }

            var result = await _magfaSendService.SendMessage(domain, userName, password, sendDto);

        }


        public async Task StatusByLocalMessageId_(long localMessageId)
        {
            throw new InvalidProviderHandleException();
        }

        public async Task _Mid(long userId)
        {
            var domain = _domain;
            var userName = _userName;
            var password = _password;
            var result = await _magfaMidService.GetMid(domain, userName, password,userId);
        }

        public async Task SelectMessage_(long messageId)
        {
            throw new InvalidProviderHandleException();
        }

        public async Task SelectOutbox_(long startDate, long endDate, string lineNumber)
        {
            throw new InvalidProviderHandleException();
        }

        public async Task LatestOutbox_(long Count, string lineNumber)
        {
            throw new InvalidProviderHandleException();
        }

        public async Task CountInbox_(long startDate, long endDate, string lineNumber, bool IsRead)
        {
            throw new InvalidProviderHandleException();
        }

    }
}
