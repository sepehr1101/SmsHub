using SmsHub.Application.Features.Sending.Services.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Infrastructure.Providers.Magfa3000.Http.Contracts;
using MagfaRequest = SmsHub.Domain.Providers.Magfa3000.Entities.Requests;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Application.Common.Services.Implementations;
using System.Runtime.InteropServices;
using SmsHub.Domain.Features.Receiving.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Domain.Constants;
using SmsHub.Application.Exceptions;

namespace SmsHub.Application.Features.Sending.Services.Implementations
{
    public class MagfaProvider : ISmsProvider
    {
        private readonly IMagfa300HttpSendService _magfaSendService;
        private readonly IMagfa300HttpStatusesService _magfaStatusCodesService;
        private readonly IMagfa300HttpBalanceService _magfaBalanceService;
        private readonly IMagfa300HttpMidService _magfaMidService;
        private readonly IMagfa300HttpMessagesService _magfaMessagesService;


        public MagfaProvider(
            IMagfa300HttpSendService magfaSendService,
            IMagfa300HttpStatusesService magfaStatusCodesService,
            IMagfa300HttpBalanceService magfaBalanceService,
            IMagfa300HttpMidService magfaMidService,
            IMagfa300HttpMessagesService magfaMessagesService)
        {
            _magfaSendService = magfaSendService;
            _magfaSendService.NotNull(nameof(MagfaProvider));

            _magfaStatusCodesService = magfaStatusCodesService;
            _magfaStatusCodesService.NotNull(nameof(MagfaProvider));

            _magfaBalanceService = magfaBalanceService;
            _magfaBalanceService.NotNull(nameof(magfaBalanceService));

            _magfaMidService = magfaMidService;
            _magfaMidService.NotNull(nameof(magfaMidService));

            _magfaMessagesService = magfaMessagesService;
            _magfaMessagesService.NotNull(nameof(magfaMessagesService));
        }

        public async Task<long> GetCredit(Entities.Line line, ICollection<ProviderResponseStatus> statusList)
        {
            var magfaCredential = ProviderCredentialService.CheckMagfaValidCredential(line.Credential);
            var domain = magfaCredential.Domain;
            var userName = magfaCredential.UserName;
            var password = magfaCredential.ClientSecret;

            var response = await _magfaBalanceService.GetBalances(domain, userName, password);

            var successstatusCode = statusList
                .Where(x => x.ProviderId == ProviderEnum.Kavenegar && x.IsSuccess == true)
                .Single().StatusCode;

            if (response.Status == successstatusCode)
            {
                return response.Balance;
            }
            else
            {
                var statusDetail = await GetProviderStatusByStatusCode(statusList, response.Status);
                throw new ProviderResponseException(statusDetail.Message, statusDetail.StatusCode);
            }

        }



        public async Task<ICollection<CreateMessageDetailStatusDto>> GetState(Entities.Line line, ICollection<MessageAndProviderIdDto> statusListData, Guid holderId, ICollection<ProviderResponseStatus> responseStatusList, ICollection<ProviderDeliveryStatus> deliveryStatusList)
        {
            var magfaCredential = ProviderCredentialService.CheckMagfaValidCredential(line.Credential);
            var domain = magfaCredential.Domain;
            var userName = magfaCredential.UserName;
            var password = magfaCredential.ClientSecret;

            var response = await _magfaStatusCodesService.GetStatuses(domain, userName, password, statusListData.Select(x=>x.ProviderServerId).ToList());

            var successstatusCode = responseStatusList
                .Where(x => x.ProviderId == ProviderEnum.Kavenegar && x.IsSuccess == true)
                .Single().StatusCode;

            if (response.Status == successstatusCode)
            {
                ICollection<CreateMessageDetailStatusDto> messageDetailStatuses = new List<CreateMessageDetailStatusDto>();
                var i = 0;
                foreach (var item in response.Dlrs)
                {
                    var deliveryStatusId = deliveryStatusList.Where(x => x.ProviderId == ProviderEnum.Magfa && x.StatusCode == 0).Single().Id;
                    var responseStatusId = responseStatusList.Where(x => x.ProviderId == ProviderEnum.Magfa && x.StatusCode == item.Status).Single().Id;

                    var singleMessageDetailStatus = new CreateMessageDetailStatusDto()
                    {
                        InsertDateTime = DateTime.Now,
                        ProviderServerId = Convert.ToInt64(item.Mid),
                        MessagesDetailId = statusListData.ElementAt(i).MessageDetailId,
                        MessagesHolderId = holderId,
                        ProviderDeliveryStatusId = deliveryStatusId,
                        ProviderResponseStatusId = responseStatusId
                    };
                    i++;
                    messageDetailStatuses.Add(singleMessageDetailStatus);
                }
                return messageDetailStatuses;
            }
            else
            {
                var statusDetail = await GetProviderStatusByStatusCode(responseStatusList, response.Status);
                throw new ProviderResponseException(statusDetail.Message, statusDetail.StatusCode);
            }
        }

        public async Task<CreateMessageDetailStatusDto> GetState(Entities.Line line, MessageAndProviderIdDto statusData, Guid holderId, ICollection<ProviderResponseStatus> responseStatusList, ICollection<ProviderDeliveryStatus> deliveryStatusList)
        {
            var magfaCredential = ProviderCredentialService.CheckMagfaValidCredential(line.Credential);
            var domain = magfaCredential.Domain;
            var userName = magfaCredential.UserName;
            var password = magfaCredential.ClientSecret;

            var response = await _magfaStatusCodesService.GetStatuses(domain, userName, password, statusData.ProviderServerId);

            var successstatusCode = responseStatusList
                .Where(x => x.ProviderId == ProviderEnum.Kavenegar && x.IsSuccess == true)
                .Single().StatusCode;


            var deliveryStatusId = deliveryStatusList.Where(x => x.ProviderId == ProviderEnum.Magfa && x.StatusCode == 0).Single().Id;
            var responseStatusId = responseStatusList.Where(x => x.ProviderId == ProviderEnum.Magfa && x.StatusCode == response.Dlrs.First().Status).Single().Id;

            if (response.Status == successstatusCode)
            {
                var messageDetailStatus = new CreateMessageDetailStatusDto()
                {
                    InsertDateTime = DateTime.Now,
                    ProviderServerId = Convert.ToInt64(response.Dlrs.First().Mid),
                    MessagesDetailId = statusData.MessageDetailId,
                    MessagesHolderId = holderId,
                    ProviderDeliveryStatusId = deliveryStatusId,
                    ProviderResponseStatusId = responseStatusId
                };
                return messageDetailStatus;
            }
            else
            {
                var statusDetail = await GetProviderStatusByStatusCode(responseStatusList, response.Status);
                throw new ProviderResponseException(statusDetail.Message, statusDetail.StatusCode);
            }
        }




        public async Task<CreateMessageDetailStatusDto> Send(Entities.Line line, MobileText mobileText, Guid holderId, ICollection<ProviderResponseStatus> responseStatusList, ICollection<ProviderDeliveryStatus> deliveryStatusList)
        {
            var magfaCredential = ProviderCredentialService.CheckMagfaValidCredential(line.Credential);
            var domain = magfaCredential.Domain;
            var userName = magfaCredential.UserName;
            var password = magfaCredential.ClientSecret;

            var sendDto = new MagfaRequest.SendDto()
            {
                messages = new List<string> { mobileText.Text },
                recipients = new List<string> { mobileText.Mobile },
                uids = new List<long> { mobileText.LocalId },
                senders = new List<string> { line.Number },

            };

            var response = await _magfaSendService.SendMessage(domain, userName, password, sendDto);

            var successstatusCode = responseStatusList
               .Where(x => x.ProviderId == ProviderEnum.Kavenegar && x.IsSuccess == true)
            .Single().StatusCode;

            var deliveryStatusId = deliveryStatusList.Where(x => x.ProviderId == ProviderEnum.Magfa && x.StatusCode == 0).Single().Id;
            var responseStatusId = responseStatusList.Where(x => x.ProviderId == ProviderEnum.Magfa && x.StatusCode == response.Message.First().Status).Single().Id;

            if (response.Status == successstatusCode)
            {
                var messageDetailStatus = new CreateMessageDetailStatusDto()
                {
                    InsertDateTime = DateTime.Now,
                    ProviderServerId = Convert.ToInt64(response.Message.First().Id),
                    MessagesDetailId = mobileText.LocalId,
                    MessagesHolderId = holderId,
                    ProviderDeliveryStatusId = deliveryStatusId,
                    ProviderResponseStatusId = responseStatusId
                };
                return messageDetailStatus;
            }
            else
            {
                var statusDetail = await GetProviderStatusByStatusCode(responseStatusList, response.Status);
                throw new ProviderResponseException(statusDetail.Message, statusDetail.StatusCode);
            }

        }

        public async Task<ICollection<CreateMessageDetailStatusDto>> Send(Entities.Line line, ICollection<MobileText> mobileText, Guid holderId, ICollection<ProviderResponseStatus> responseStatusList, ICollection<ProviderDeliveryStatus> deliveryStatusList)
        {
            var magfaCredential = ProviderCredentialService.CheckMagfaValidCredential(line.Credential);
            var domain = magfaCredential.Domain;
            var userName = magfaCredential.UserName;
            var password = magfaCredential.ClientSecret;

            MagfaRequest.SendDto sendDto = new MagfaRequest.SendDto()
            {
                messages = new List<string>(),
                recipients = new List<string>(),
                uids = new List<long>(),
                senders = new List<string>(),
            };

            foreach (var item in mobileText)
            {
                sendDto.senders.Add(line.Number);
                sendDto.messages.Add(item.Text);
                sendDto.uids.Add(item.LocalId);
                sendDto.recipients.Add(item.Mobile);
            }

            var response = await _magfaSendService.SendMessage(domain, userName, password, sendDto);

            var successstatusCode = responseStatusList
               .Where(x => x.ProviderId == ProviderEnum.Kavenegar && x.IsSuccess == true)
               .Single().StatusCode;

            if (response.Status == successstatusCode)
            {
                //MessageDetailStatus
                ICollection<CreateMessageDetailStatusDto> messageDetailStatuses = new List<CreateMessageDetailStatusDto>();
                foreach (var item in response.Message)
                {
                    var deliveryStatusId = deliveryStatusList.Where(x => x.ProviderId == ProviderEnum.Magfa && x.StatusCode == 0).Single().Id;
                    var responseStatusId = responseStatusList.Where(x => x.ProviderId == ProviderEnum.Magfa && x.StatusCode == item.Status).Single().Id;

                    var singleMessageDetailStatus = new CreateMessageDetailStatusDto()
                    {
                        InsertDateTime = DateTime.Now,
                        ProviderServerId = Convert.ToInt64(item.Id),
                        MessagesDetailId = Convert.ToInt64(item.UserId),//todo : check
                        MessagesHolderId = holderId,
                        ProviderDeliveryStatusId = deliveryStatusId,
                        ProviderResponseStatusId = responseStatusId
                    };
                    messageDetailStatuses.Add(singleMessageDetailStatus);
                }
                return messageDetailStatuses;
            }
            else
            {
                var statusDetail = await GetProviderStatusByStatusCode(responseStatusList, response.Status);
                throw new ProviderResponseException(statusDetail.Message, statusDetail.StatusCode);
            }
        }




        private async Task Mid(Entities.Line line, long userId, ICollection<ProviderResponseStatus> statusList)
        {
            var magfaCredential = ProviderCredentialService.CheckMagfaValidCredential(line.Credential);
            var domain = magfaCredential.Domain;
            var userName = magfaCredential.UserName;
            var password = magfaCredential.ClientSecret;

            var response = await _magfaMidService.GetMid(domain, userName, password, userId);

            var successstatusCode = statusList
               .Where(x => x.ProviderId == ProviderEnum.Kavenegar && x.IsSuccess == true)
               .Single().StatusCode;

            if (response.Status == successstatusCode)
            {
                //return
            }
            else
            {
                var statusDetail = await GetProviderStatusByStatusCode(statusList, response.Status);
                throw new ProviderResponseException(statusDetail.Message, statusDetail.StatusCode);
            }
        }


        public async Task<ICollection<CreateReceiveDto>> Receive([Optional] Entities.Line line, ICollection<ProviderResponseStatus> statusList)
        {
            var magfaCredential = ProviderCredentialService.CheckMagfaValidCredential(line.Credential);
            var domain = magfaCredential.Domain;
            var userName = magfaCredential.UserName;
            var password = magfaCredential.ClientSecret;
            var result = await _magfaMessagesService.GetMessages(domain, userName, password);

            var successstatusCode = statusList
               .Where(x => x.ProviderId == ProviderEnum.Kavenegar && x.IsSuccess == true)
               .Single().StatusCode;

            if (result.Status == successstatusCode)
            {
                //mapping to CreateReceiveDto
                ICollection<CreateReceiveDto> createReceiveMessage = new List<CreateReceiveDto>();
                foreach (var item in result.Messages)
                {
                    var receiveSingleMessage = new CreateReceiveDto(item, line.Id);
                    createReceiveMessage.Add(receiveSingleMessage);
                }
                return createReceiveMessage;
            }
            else
            {
                var statusDetail = await GetProviderStatusByStatusCode(statusList, result.Status);
                throw new ProviderResponseException(statusDetail.Message, statusDetail.StatusCode);
            }
        }


        //

        private async Task<ProviderResponseStatus> GetProviderStatusByStatusCode(ICollection<ProviderResponseStatus> statusList, int statusCode)
        {
            var trueStatus = statusList
               .Where(s => s.ProviderId == ProviderEnum.Magfa & s.StatusCode == statusCode)
               .Single();

            return trueStatus;
        }

    }
}