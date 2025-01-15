using Azure;
using SmsHub.Application.Common.Services.Implementations;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Sending.Services.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Receiving.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Domain.Providers.Kavenegar.Entities.Requests;
using SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts;
using System.Runtime.InteropServices;
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
        public async Task<long> GetCredit(Entities.Line line, ICollection<ProviderResponseStatus> statusList)
        {
            var kavenegarCredential = ProviderCredentialService.CheckKavenegarValidCredential(line.Credential);
            var apiKey = kavenegarCredential.apiKey;

            var response = await _accountService.Trigger(apiKey);

            var successStatus = await GetSuccessStatus(statusList);
            if (response.Return.Status == successStatus.StatusCode)
            {
                return response.Entries.ExpireDate;

            }
            else
            {
                throw new ProviderResponseException(response.Return.Message, response.Return.Status);
            }

        }

        public async Task GetState(Entities.Line line, long id, ICollection<ProviderResponseStatus> statusList)
        {
            var kavenegarCredential = ProviderCredentialService.CheckKavenegarValidCredential(line.Credential);
            var apiKey = kavenegarCredential.apiKey;

            StatusDto status = id;//1828205579
            var response = await _statusService.Trigger(status, apiKey);

            var successStatus = await GetSuccessStatus(statusList);
            if (response.Return.Status == successStatus.StatusCode)
            {
                //todo : return
            }
            else
            {
                throw new ProviderResponseException(response.Return.Message, response.Return.Status);
            }
        }

        public async Task Send(Entities.Line line, MobileText mobileText, ICollection<ProviderResponseStatus> statusList)
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

            var successStatus = await GetSuccessStatus(statusList);
            if (response.Return.Status == successStatus.StatusCode)
            {
                //todo : return
            }
            else
            {
                throw new ProviderResponseException(response.Return.Message, response.Return.Status);
            }
        }

        public async Task Send(Entities.Line line, ICollection<MobileText> mobileTexts, ICollection<ProviderResponseStatus> statusList)
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

            var response = await _sendArrayService.Trigger(sendArrayDto, apiKey);

            var successStatus = await GetSuccessStatus(statusList);
            if (response.Return.Status == successStatus.StatusCode)
            {
                //todo : return
            }
            else
            {
                throw new ProviderResponseException(response.Return.Message, response.Return.Status);
            }
        }

        public async Task<ICollection<CreateReceiveDto>> Receive([Optional] Entities.Line line, ICollection<ProviderResponseStatus> statusList)
        {
            var kavenegarCredential = ProviderCredentialService.CheckKavenegarValidCredential(line.Credential);
            var apiKey = kavenegarCredential.apiKey;
            //var receiveDto = new ReceiveDto(line.Number, true);
            var receiveDto = new ReceiveDto("100200", true);
            var resultReceive = await _receiveService.Trigger(receiveDto, apiKey);

            var successStatus = await GetSuccessStatus(statusList);
            if (resultReceive.Return.Status == successStatus.StatusCode)
            {
                //mapping to CreateReceiveDto
                ICollection<CreateReceiveDto> createReceiveMessageDto = new List<CreateReceiveDto>();
                foreach (var item in resultReceive.Entries)
                {

                    var receiveSingleMessage = new CreateReceiveDto(item);
                    createReceiveMessageDto.Add(receiveSingleMessage);
                }
                return createReceiveMessageDto;
            }
            else
            {
                throw new ProviderResponseException(resultReceive.Return.Message, resultReceive.Return.Status);
            }

        }

        private async Task StatusByLocalMessageId(Entities.Line line, long localMessageId, ICollection<ProviderResponseStatus> statusList)
        {
            var kavenegarCredential = ProviderCredentialService.CheckKavenegarValidCredential(line.Credential);
            var apiKey = kavenegarCredential.apiKey;

            StatusByMessageIdDto statusByMessageId = localMessageId;
            var response = await _statusByMessageIdService.Trigger(statusByMessageId, apiKey);

            var successStatus = await GetSuccessStatus(statusList);
            if (response.Return.Status == successStatus.StatusCode)
            {
                //todo : return
            }
            else
            {
                throw new ProviderResponseException(response.Return.Message, response.Return.Status);
            }
        }


        private async Task SelectMessage(Entities.Line line, long messageId, ICollection<ProviderResponseStatus> statusList)//todo: debug error 407 -> change local Ip
        {
            var kavenegarCredential = ProviderCredentialService.CheckKavenegarValidCredential(line.Credential);
            var apiKey = kavenegarCredential.apiKey;

            SelectDto selectDto = messageId;

            var response = await _selectService.Trigger(selectDto, apiKey);

            var successStatus = await GetSuccessStatus(statusList);
            if (response.Return.Status == successStatus.StatusCode)
            {
                //todo : return
            }
            else
            {
                throw new ProviderResponseException(response.Return.Message, response.Return.Status);
            }
        }

        private async Task SelectOutbox(long startDate, long endDate, Entities.Line line, ICollection<ProviderResponseStatus> statusList)//todo: debug error 407 -> change local Ip
        {
            var kavenegarCredential = ProviderCredentialService.CheckKavenegarValidCredential(line.Credential);
            var apiKey = kavenegarCredential.apiKey;

            var selectOutboxDto = new SelectOutboxDto()
            {
                StartDate = startDate,
                EndDate = endDate,
                Sender = line.Number
            };
            var response = await _selectOutboxService.Trigger(selectOutboxDto, apiKey);

            var successStatus = await GetSuccessStatus(statusList);
            if (response.Return.Status == successStatus.StatusCode)
            {
                //todo : return
            }
            else
            {
                throw new ProviderResponseException(response.Return.Message, response.Return.Status);
            }

        }


        private async Task LatestOutbox(long Count, Entities.Line line, ICollection<ProviderResponseStatus> statusList)//todo: debug error 407 -> change local Ip
        {
            var kavenegarCredential = ProviderCredentialService.CheckKavenegarValidCredential(line.Credential);
            var apiKey = kavenegarCredential.apiKey;

            var latestOutboxDto = new LatestOutboxDto()
            {
                PageSize = Count,
                Sender = line.Number
            };

            var response = await _latestOutboxService.Trigger(latestOutboxDto, apiKey);

            var successStatus = await GetSuccessStatus(statusList);
            if (response.Return.Status == successStatus.StatusCode)
            {
                //todo : return
            }
            else
            {
                throw new ProviderResponseException(response.Return.Message, response.Return.Status);
            }
        }

        private async Task CountInbox(long startDate, long endDate, Entities.Line line, bool IsRea0, ICollection<ProviderResponseStatus> statusList)
        {
            var kavenegarCredential = ProviderCredentialService.CheckKavenegarValidCredential(line.Credential);
            var apiKey = kavenegarCredential.apiKey;

            var response = await _accountService.Trigger(apiKey);

            var successStatus = await GetSuccessStatus(statusList);
            if (response.Return.Status == successStatus.StatusCode)
            {
                //todo : return
            }
            else
            {
                throw new ProviderResponseException(response.Return.Message, response.Return.Status);
            }
        }


        //
        private async Task<ProviderResponseStatus> GetSuccessStatus(ICollection<ProviderResponseStatus> statusList)
        {
            var trueStatus = statusList
                .Where(s => s.ProviderId == ProviderEnum.Kavenegar & s.IsSuccess == true)
                .Single();

            return trueStatus;
        }

    }
}
