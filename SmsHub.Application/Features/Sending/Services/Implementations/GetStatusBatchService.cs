using AutoMapper;
using Hangfire;
using SmsHub.Application.Features.Sending.Factories;
using SmsHub.Application.Features.Sending.Services.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Services.Implementations
{
    public sealed class GetStatusBatchService : IStatusInBackgroundService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ISmsProviderFactory _smsProviderFactory;
        private readonly IMessageDetailStatusQueryService _messageDetailStatusQueryService;
        private readonly IMessageDetailStatusCommandService _messageDetailStatusCommandService;
        private readonly IMessagesHolderQueryService _messagesHolderQueryService;
        private readonly IProviderResponseStatusQueryService _providerResponseStatusQueryService;
        private readonly IProviderDeliveryStatusQueryService _providerDeliveryStatusQueryService;
        private readonly IGetStatusSingleService _getStatusSingleService;
        public GetStatusBatchService(
            IUnitOfWork uow,
            IMapper mapper,
            ISmsProviderFactory smsProviderFactory,
            IMessageDetailStatusQueryService messageDetailStatusQueryService,
            IMessageDetailStatusCommandService messageDetailStatusCommandService,
            IMessagesHolderQueryService messagesHolderQueryService,
            IProviderResponseStatusQueryService providerResponseStatusQueryService,
            IProviderDeliveryStatusQueryService providerDeliveryStatusQueryService,
            IGetStatusSingleService getStatusSingleService)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _smsProviderFactory = smsProviderFactory;
            _smsProviderFactory.NotNull(nameof(smsProviderFactory));

            _messageDetailStatusQueryService = messageDetailStatusQueryService;
            _messageDetailStatusQueryService.NotNull(nameof(messageDetailStatusQueryService));

            _messageDetailStatusCommandService = messageDetailStatusCommandService;
            _messageDetailStatusCommandService.NotNull(nameof(messageDetailStatusCommandService));

            _messagesHolderQueryService = messagesHolderQueryService;
            _messagesHolderQueryService.NotNull(nameof(_messagesHolderQueryService));

            _providerResponseStatusQueryService = providerResponseStatusQueryService;
            _providerResponseStatusQueryService.NotNull(nameof(providerResponseStatusQueryService));

            _providerDeliveryStatusQueryService = providerDeliveryStatusQueryService;
            _providerDeliveryStatusQueryService.NotNull(nameof(providerDeliveryStatusQueryService));

            _getStatusSingleService = getStatusSingleService;
            _getStatusSingleService.NotNull(nameof(getStatusSingleService));
        }

        public async Task Trigger(Guid messageHolderId, ProviderEnum providerId)
        {
            ICollection<ProviderResponseStatus> responseStatusList = await _providerResponseStatusQueryService.Get();
            ICollection<ProviderDeliveryStatus> deliveryStatusList = await _providerDeliveryStatusQueryService.Get();
            MessagesHolder messageHolder = await _messagesHolderQueryService.GetIncludeLine(messageHolderId);
            List<MessageAndProviderIdDto> statusInfoList = (await _messageDetailStatusQueryService.GetAll())
                .Where(x => x.MessagesHolderId == messageHolderId)
                .Select(x => new MessageAndProviderIdDto()
                {
                    MessageDetailId = x.MessagesDetailId,
                    ProviderServerId = x.ProviderServerId,
                }).ToList();

            ISmsProvider smsProvider = _smsProviderFactory.Create(providerId);
            ICollection<CreateMessageDetailStatusDto> result = await smsProvider.GetState(messageHolder.MessageBatch.Line, statusInfoList, messageHolderId, responseStatusList, deliveryStatusList);

            // delivery status
            ICollection<MessageDetailStatus> messageDetailStatus = _mapper.Map<ICollection<MessageDetailStatus>>(result);
            await _messageDetailStatusCommandService.Add(messageDetailStatus);
            await _uow.SaveChangesAsync(CancellationToken.None);

            //recursive
            List<long> failedMessageDetailIdList = GetFailedMessageDetailIds(messageDetailStatus);
            foreach (var item in failedMessageDetailIdList)
            {                
                BackgroundJob.Enqueue(() => _getStatusSingleService.Trigger(item, providerId));
            }
        }
        private List<long> GetFailedMessageDetailIds(ICollection<MessageDetailStatus> messageDetailStatuses)
        {
            var messageDetailStatueIds = 
                messageDetailStatuses
                .Where(x => !x.ProviderDeliveryStatus.IsFinal)
                .Select(x => x.MessagesDetailId)
                .ToList();
            return messageDetailStatueIds;
        }
    }
}
