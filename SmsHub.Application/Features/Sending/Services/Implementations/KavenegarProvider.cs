using SmsHub.Application.Common.Services.Implementations;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Sending.Services.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
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
        private readonly IKavenegarHttpStatusArrayService _statusArrayService;
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
            IKavenegarHttpStatusArrayService statusArrayService,
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

            _statusArrayService = statusArrayService;
            _statusArrayService.NotNull(nameof(statusArrayService));

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
        public async Task<long> GetCredit(Entities.Line line, ICollection<ProviderResponseStatus> statusList)
        {
            var kavenegarCredential = ProviderCredentialService.CheckKavenegarValidCredential(line.Credential);
            var apiKey = kavenegarCredential.apiKey;

            var response = await _accountService.Trigger(apiKey);

            var successstatusCode = statusList
                .Where(x => x.ProviderId == ProviderEnum.Kavenegar && x.IsSuccess == true)
                .Single().StatusCode;

            if (response.Return.Status == successstatusCode)
            {
                return response.Entries.ExpireDate;
            }
            else
            {
                throw new ProviderResponseException(response.Return.Message, response.Return.Status);
            }
        }

        public async Task<CreateMessageDetailStatusDto> GetState(Entities.Line line, MessageAndProviderIdDto statusData, Guid holderId, ICollection<ProviderResponseStatus> responseStatusList, ICollection<ProviderDeliveryStatus> deliveryStatusList)
        {
            var kavenegarCredential = ProviderCredentialService.CheckKavenegarValidCredential(line.Credential);
            var apiKey = kavenegarCredential.apiKey;

            StatusDto status = statusData.ProviderServerId;//1828205579
            var response = await _statusService.Trigger(status, apiKey);

            var successstatusCode = responseStatusList
                .Where(x => x.ProviderId == ProviderEnum.Kavenegar && x.IsSuccess == true)
                .Single().StatusCode;

            var deliveryStatusId = deliveryStatusList.Where(x => x.ProviderId == ProviderEnum.Kavenegar && x.StatusCode == response.Return.Status).Single().Id;

            if (response.Return.Status == successstatusCode)
            {
                var messageDetailStatus = new CreateMessageDetailStatusDto()
                {
                    InsertDateTime = DateTime.Now,
                    ProviderServerId = response.Entries.MessageId,
                    MessagesDetailId = statusData.MessageDetailId,
                    MessagesHolderId = holderId,
                    ProviderDeliveryStatusId = deliveryStatusId
                };
                return messageDetailStatus;
            }
            else
            {
                throw new ProviderResponseException(response.Return.Message, response.Return.Status);
            }
        }
        public async Task<ICollection<CreateMessageDetailStatusDto>> GetState(Entities.Line line, ICollection<MessageAndProviderIdDto> statusListData, Guid holderId, ICollection<ProviderResponseStatus> responseStatusList, ICollection<ProviderDeliveryStatus> deliveryStatusList)
        {
            var kavenegarCredential = ProviderCredentialService.CheckKavenegarValidCredential(line.Credential);
            var apiKey = kavenegarCredential.apiKey;

            ICollection<StatusDto> statusList = statusListData
                .Select(x => new StatusDto(x.ProviderServerId))
                .ToList();
            var response = await _statusArrayService.Trigger(statusList, apiKey);

            var successstatusCode = responseStatusList
               .Where(x => x.ProviderId == ProviderEnum.Kavenegar && x.IsSuccess == true)
               .Single().StatusCode;


            if (response.Return.Status == successstatusCode)
            {
                ICollection<CreateMessageDetailStatusDto> messageDetailStatuses = new List<CreateMessageDetailStatusDto>();
                var i = 0;

                foreach (var item in response.Entries)
                {
                    var deliveryStatusId = deliveryStatusList.Where(x => x.ProviderId == ProviderEnum.Kavenegar && x.StatusCode == item.Status).Single().Id;

                    var singleMessageDetailStatus = new CreateMessageDetailStatusDto()
                    {
                        InsertDateTime = DateTime.Now,
                        ProviderServerId = item.MessageId,
                        MessagesDetailId = statusListData.ElementAt(i).MessageDetailId,//todo : check
                        MessagesHolderId = holderId,
                        ProviderDeliveryStatusId = deliveryStatusId,
                    };
                    i += 1;
                    messageDetailStatuses.Add(singleMessageDetailStatus);
                }
                return messageDetailStatuses;
            }
            else
            {
                throw new ProviderResponseException(response.Return.Message, response.Return.Status);
            }
        }


        public async Task<CreateMessageDetailStatusDto> Send(Entities.Line line, MobileText mobileText, Guid holderId, ICollection<ProviderResponseStatus> responseStatusList, ICollection<ProviderDeliveryStatus> deliveryStatusList)
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
            };

            var response = await _sendSimpleService.Trigger(sendSimpleDto, apiKey);

            var successstatusCode = responseStatusList
                .Where(x => x.ProviderId == ProviderEnum.Kavenegar && x.IsSuccess == true)
                .Single().StatusCode;

            var deliveryStatusId = deliveryStatusList.Where(x => x.ProviderId == ProviderEnum.Kavenegar && x.StatusCode == response.Entries.Status).Single().Id;

            if (response.Return.Status == successstatusCode)
            {
                var messageDetailStatus = new CreateMessageDetailStatusDto()
                {
                    InsertDateTime = DateTime.Now,
                    ProviderServerId = response.Entries.MessageId,
                    MessagesDetailId = mobileText.LocalId,
                    MessagesHolderId = holderId,
                    ProviderDeliveryStatusId = deliveryStatusId
                };
                return messageDetailStatus;
            }
            else
            {
                throw new ProviderResponseException(response.Return.Message, response.Return.Status);
            }
        }

        public async Task<ICollection<CreateMessageDetailStatusDto>> Send(Entities.Line line, ICollection<MobileText> mobileTexts, Guid holderId, ICollection<ProviderResponseStatus> responseStatusList, ICollection<ProviderDeliveryStatus> deliveryStatusList)
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

            var successstatusCode = responseStatusList
                 .Where(x => x.ProviderId == ProviderEnum.Kavenegar && x.IsSuccess == true)
                 .Single().StatusCode;

            if (response.Return.Status == successstatusCode)
            {
                //MessageDetailStatus
                ICollection<CreateMessageDetailStatusDto> messageDetailStatuses = new List<CreateMessageDetailStatusDto>();
                var i = 0;

                foreach (var item in response.Entries)
                {
                    var deliveryStatusId = deliveryStatusList.Where(x => x.ProviderId == ProviderEnum.Kavenegar && x.StatusCode == item.Status).Single().Id;

                    var singleMessageDetailStatus = new CreateMessageDetailStatusDto()
                    {
                        InsertDateTime = DateTime.Now,
                        ProviderServerId = item.MessageId,
                        MessagesDetailId = mobileTexts.ElementAt(i).LocalId,//todo : check
                        MessagesHolderId = holderId,
                        ProviderDeliveryStatusId = deliveryStatusId,
                    };
                    i += 1;
                    messageDetailStatuses.Add(singleMessageDetailStatus);
                }
                return messageDetailStatuses;
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
            var receiveDto = new ReceiveDto(line.Number, false);
            var resultReceive = await _receiveService.Trigger(receiveDto, apiKey);

            var successstatusCode = statusList
                 .Where(x => x.ProviderId == ProviderEnum.Kavenegar && x.IsSuccess == true)
                 .Single().StatusCode;

            if (resultReceive.Return.Status == successstatusCode)
            {
                //mapping to CreateReceiveDto
                ICollection<CreateReceiveDto> createReceiveMessageDto = new List<CreateReceiveDto>();
                foreach (var item in resultReceive.Entries)
                {

                    var receiveSingleMessage = new CreateReceiveDto(item, line.Id);
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

            var successstatusCode = statusList
                .Where(x => x.ProviderId == ProviderEnum.Kavenegar && x.IsSuccess == true)
                .Single().StatusCode;

            if (response.Return.Status == successstatusCode)
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

            var successstatusCode = statusList
                .Where(x => x.ProviderId == ProviderEnum.Kavenegar && x.IsSuccess == true)
                .Single().StatusCode;

            if (response.Return.Status == successstatusCode)
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

            var successstatusCode = statusList
                .Where(x => x.ProviderId == ProviderEnum.Kavenegar && x.IsSuccess == true)
                .Single().StatusCode;

            if (response.Return.Status == successstatusCode)
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

            var successstatusCode = statusList
                .Where(x => x.ProviderId == ProviderEnum.Kavenegar && x.IsSuccess == true)
                .Single().StatusCode;

            if (response.Return.Status == successstatusCode)
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

            var successstatusCode = statusList
                .Where(x => x.ProviderId == ProviderEnum.Kavenegar && x.IsSuccess == true)
                .Single().StatusCode;

            if (response.Return.Status == successstatusCode)
            {
                //todo : return
            }
            else
            {
                throw new ProviderResponseException(response.Return.Message, response.Return.Status);
            }
        }




    }
}
