using Microsoft.EntityFrameworkCore.Metadata;
using SmsHub.Application.Features.Sending.ServicesSample.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Providers.Kavenegar.Entities.Requests;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts;

namespace SmsHub.Application.Features.Sending.ServicesSample.Implementations
{
    public class Kavenegar : IProviderFactory
    {
        private static string _kaveApi = "s";
        private readonly IKavenegarHttpAccountService _accountService;
        private readonly IKavenegarHttpStatusService _statusService;
        private readonly IKavenegarHttpReceiveService _receiveService;
        private readonly IKavenegarHttpSendSimpleService _sendSimpleService;
        private readonly IKavenegarHttpSendArrayService _sendArrayService;
        private readonly IKavenegarHttpStatusByMessageIdService _statusByMessageIdService;
        private readonly IKavenegarHttpSelectService _selectService;
        private readonly IKavenegarHttpSelectOutboxService _selectOutboxService;
        private readonly IKavenegarHttpLatestOutboxService _latestOutboxService;


        public Kavenegar(IKavenegarHttpAccountService accountService
            , IKavenegarHttpStatusService statusService
            , IKavenegarHttpReceiveService receiveService
            , IKavenegarHttpSendArrayService sendArrayService
            , IKavenegarHttpSendSimpleService sendSimpleService
            , IKavenegarHttpStatusByMessageIdService statusByMessageIdService
            , IKavenegarHttpSelectService selectService
            , IKavenegarHttpSelectOutboxService selectOutboxService
            , IKavenegarHttpLatestOutboxService latestOutboxService)
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
        }

        public async Task Account_Balance()
        {
            var apiKey = _kaveApi;
            var response = await _accountService.Trigger(apiKey);
        }

        public async Task Status_Statuses(int messageId)
        {
            var apiKey = _kaveApi;
            StatusDto status = messageId;//1828205579
            var result = await _statusService.Trigger(status, apiKey);
        }

        public async Task Receive_Messages(int? count, string? lineNumber)
        {
            var apiKey = _kaveApi;
            var receiveDto = new ReceiveDto(lineNumber, true);//2000550055505
            var resultReceive = await _receiveService.Trigger(receiveDto, apiKey);
        }

        public async Task Send_Send(List<SendMessageDto> message)
        {
            var messageCount = message.Count;
            if (messageCount == 1)
                await SendSimple(message.FirstOrDefault());
            else
                await SendArray(message);

        }

        public async Task SendSimple(SendMessageDto message)
        {
            var apiKey = _kaveApi;

            var sendSimpleDto = new SimpleSendDto()
            {
                Sender = message.Sender,
                Receptor = message.Receptor,
                Message = message.Message,
                LocalId = message.localMessageId,
                Date = message.Date
            };

            var response = await _sendSimpleService.Trigger(sendSimpleDto, apiKey);

        }

        public async Task SendArray(List<SendMessageDto> messages)
        {
            var apiKey = _kaveApi;

            ArraySendDto sendArrayDto = new ArraySendDto
            {
                Sender = new List<string>(),
                Receptor = new List<string>(),
                Message = new List<string>(),
                Type = new List<int>(),
                LocalMessageIds = new List<long>()
            };

            foreach (var item in messages)
            {
                sendArrayDto.Sender.Add(item.Sender);
                sendArrayDto.Receptor.Add(item.Receptor);
                sendArrayDto.Message.Add(item.Message);
                sendArrayDto.LocalMessageIds.Add((long)item.localMessageId);
                sendArrayDto.Date = item.Date;
            }

            var result = await _sendArrayService.Trigger(sendArrayDto, apiKey);
        }


        public async Task StatusByLocalMessageId_(long localMessageId)
        {
            var apiKey = _kaveApi;

            StatusByMessageIdDto statusByMessageId = localMessageId;
            var result = await _statusByMessageIdService.Trigger(statusByMessageId, apiKey);
        }


        public async Task _Mid(long userId)
        {
            throw new NotImplementedException();
        }


        public async Task SelectMessage_(long messageId)//error 407 -> change local Ip
        {
            var apiKey = _kaveApi;
            SelectDto selectDto = messageId;//can send Several with "," but it's long
            var result = await _selectService.Trigger(selectDto, apiKey);


            DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(190220112).DateTime;
        }


        public async Task SelectOutbox_(long startDate, long endDate, string lineNumber)//error 407 -> change local Ip
        {
            var apiKey = _kaveApi;
            var selectOutboxDto = new SelectOutboxDto()
            {
                StartDate = startDate,
                EndDate = endDate,
                Sender = lineNumber
            };
            var result = await _selectOutboxService.Trigger(selectOutboxDto, apiKey);

        }

        public async Task LatestOutbox_(long Count, string lineNumber)//error 407 -> change local Ip
        {
            var apiKey = _kaveApi;
            var latestOutboxDto = new LatestOutboxDto()
            {
                PageSize = Count,
                Sender = lineNumber
            };
            var result = await _latestOutboxService.Trigger(latestOutboxDto, apiKey);

        }


        public async Task CountOutbox_(long startDate, long endDate, int? status)
        {

        }
    }
}
