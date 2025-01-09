using SmsHub.Application.Common.Services.Implementations;
using SmsHub.Application.Features.Sending.Services.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Domain.Providers.Kavenegar.Entities.Requests;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Sending.Services.Implementations
{
    public class KavenegarProvider : ISmsProvider
    {
        private readonly IKavenegarHttpAccountService _accountService;
        private readonly IKavenegarHttpStatusService _statusService;
        private readonly IKavenegarHttpReceiveService _receiveService;
        private readonly IKavenegarHttpSendSimpleService _sendSimpleService;
        private readonly IKavenegarHttpSendArrayService _sendArrayService;
        private readonly IKavenegarHttpStatusByMessageIdService _statusByMessageIdService;
        private readonly IKavenegarHttpSelectService _selectService;
        private readonly IKavenegarHttpSelectOutboxService _selectOutboxService;
        private readonly IKavenegarHttpLatestOutboxService _latestOutboxService;
        private readonly IKavenegarHttpCountInboxService _countInboxService;

        public KavenegarProvider(
            IKavenegarHttpAccountService accountService,
            IKavenegarHttpStatusService statusService,
            IKavenegarHttpReceiveService receiveService,
            IKavenegarHttpSendArrayService sendArrayService,
            IKavenegarHttpSendSimpleService sendSimpleService,
            IKavenegarHttpStatusByMessageIdService statusByMessageIdService,
            IKavenegarHttpSelectService selectService,
            IKavenegarHttpSelectOutboxService selectOutboxService,
            IKavenegarHttpLatestOutboxService latestOutboxService,
            IKavenegarHttpCountInboxService countInboxService)
        {
            _accountService = accountService;
            _accountService.NotNull(nameof(accountService));

            _statusService = statusService;
            _statusService.NotNull(nameof(statusService));

            _receiveService = receiveService;
            _receiveService.NotNull(nameof(receiveService));

            _sendArrayService = sendArrayService;
            _sendArrayService.NotNull(nameof(sendArrayService));

            _sendSimpleService = sendSimpleService;
            _sendSimpleService.NotNull(nameof(sendSimpleService));

            _statusByMessageIdService = statusByMessageIdService;
            _statusByMessageIdService.NotNull(nameof(statusByMessageIdService));

            _selectService = selectService;
            _selectService.NotNull(nameof(selectService));

            _selectOutboxService = selectOutboxService;
            _selectOutboxService.NotNull(nameof(selectOutboxService));

            _latestOutboxService = latestOutboxService;
            _latestOutboxService.NotNull(nameof(latestOutboxService));

            _countInboxService = countInboxService;
            _countInboxService.NotNull(nameof(countInboxService));
        }

        public void Test()
        {
            Console.WriteLine("test from kavenegar");
        }
        public async Task<long> GetCredit(Entities.Line line)
        {
            var kavenegarCredential = ProviderCredentialService.CheckKavenegarValidCredential(line.Credential);
            var apiKey = kavenegarCredential.apiKey;

            var response = await _accountService.Trigger(apiKey);

            return response.Entries.ExpireDate;
        }

        public async Task GetState(Entities.Line line, long id)
        {
            var kavenegarCredential = ProviderCredentialService.CheckKavenegarValidCredential(line.Credential);
            var apiKey = kavenegarCredential.apiKey;

            StatusDto status = id;//1828205579
            var result = await _statusService.Trigger(status, apiKey);
        }

        public async Task Send(Entities.Line line, MobileText mobileText)
        {
            var kavenegarCredential = ProviderCredentialService.CheckKavenegarValidCredential(line.Credential);
            var apiKey = kavenegarCredential.apiKey;

            var sendSimpleDto = new SimpleSendDto()
            {
                Sender = line.Number,
                Message = mobileText.Text,
                Receptor = mobileText.Mobile,
                LocalId = mobileText.LocalId,
                Date = TimeExtension.DateTimeToUnixTime(DateTime.Now),
                //todo : what is Hide and Type
            };

            var response = await _sendSimpleService.Trigger(sendSimpleDto, apiKey);
        }

        public async Task Send(Entities.Line line, ICollection<MobileText> mobileTexts)
        {
            var kavenegarCredential = ProviderCredentialService.CheckKavenegarValidCredential(line.Credential);
            var apiKey = kavenegarCredential.apiKey;

            ArraySendDto sendArrayDto = new ArraySendDto
            {
                Sender = new List<string>(),
                Receptor = new List<string>(),
                Message = new List<string>(),
                Type = new List<int>(),
                LocalMessageIds = new List<long>()
            };

            foreach (var item in mobileTexts)
            {
                sendArrayDto.Sender.Add(line.Number);
                sendArrayDto.Receptor.Add(item.Mobile);
                sendArrayDto.Message.Add(item.Text);
                sendArrayDto.LocalMessageIds.Add(item.LocalId);
                sendArrayDto.Date = TimeExtension.DateTimeToUnixTime(DateTime.Now);
                //todo: other prop
            }

            var result = await _sendArrayService.Trigger(sendArrayDto, apiKey);
        }






        private async Task Receive(Entities.Line line,int? count)
        {

            var kavenegarCredential = ProviderCredentialService.CheckKavenegarValidCredential(line.Credential);
            var apiKey = kavenegarCredential.apiKey;

            var receiveDto = new ReceiveDto(line.Number, true);
            var resultReceive = await _receiveService.Trigger(receiveDto, apiKey);
        }


        private async Task StatusByLocalMessageId(Entities.Line line,long localMessageId)
        {
            var kavenegarCredential = ProviderCredentialService.CheckKavenegarValidCredential(line.Credential);
            var apiKey = kavenegarCredential.apiKey;

            StatusByMessageIdDto statusByMessageId = localMessageId;
            var result = await _statusByMessageIdService.Trigger(statusByMessageId, apiKey);
        }


        private async Task SelectMessage(Entities.Line line, long messageId)//todo: debug error 407 -> change local Ip
        {
            var kavenegarCredential = ProviderCredentialService.CheckKavenegarValidCredential(line.Credential);
            var apiKey = kavenegarCredential.apiKey;

            SelectDto selectDto = messageId;

            var result = await _selectService.Trigger(selectDto, apiKey);
        }

        private async Task SelectOutbox(long startDate, long endDate, Entities.Line line)//todo: debug error 407 -> change local Ip
        {
            var kavenegarCredential = ProviderCredentialService.CheckKavenegarValidCredential(line.Credential);
            var apiKey = kavenegarCredential.apiKey;
            
            var selectOutboxDto = new SelectOutboxDto()
            {
                StartDate = startDate,
                EndDate = endDate,
                Sender = line.Number
            };
            var result = await _selectOutboxService.Trigger(selectOutboxDto, apiKey);

        }


        private async Task LatestOutbox(long Count, Entities.Line line)//todo: debug error 407 -> change local Ip
        {
            var kavenegarCredential = ProviderCredentialService.CheckKavenegarValidCredential(line.Credential);
            var apiKey = kavenegarCredential.apiKey;
            
            var latestOutboxDto = new LatestOutboxDto()
            {
                PageSize = Count,
                Sender = line.Number
            };

            var result = await _latestOutboxService.Trigger(latestOutboxDto, apiKey);

        }

        private async Task CountInbox(long startDate, long endDate, Entities.Line line, bool IsRead)
        {
            var kavenegarCredential = ProviderCredentialService.CheckKavenegarValidCredential(line.Credential);
            var apiKey = kavenegarCredential.apiKey;
            
            var response = await _accountService.Trigger(apiKey);
        }

    }
}
