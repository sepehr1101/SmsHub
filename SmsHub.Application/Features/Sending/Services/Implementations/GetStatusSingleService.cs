using AutoMapper;
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
    public sealed class GetStatusSingleService:IGetStatusSingleService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ISmsProviderFactory _smsProviderFactory;
        private readonly IMessagesDetailQueryService _messagesDetailQueryService;
        private readonly IMessageDetailStatusCommandService _messageDetailStatusCommandService;
        private readonly IMessagesHolderQueryService _messagesHolderQueryService;
        private readonly IProviderResponseStatusQueryService _providerResponseStatusQueryService;
        private readonly IProviderDeliveryStatusQueryService _providerDeliveryStatusQueryService;
        private readonly IMessageDetailStatusQueryService _messageDetailStatusQueryService;
        public GetStatusSingleService(
            IUnitOfWork uow,
            IMapper mapper,
            ISmsProviderFactory smsProviderFactory,
            IMessagesDetailQueryService messagesDetailQueryService,
            IMessageDetailStatusCommandService messageDetailStatusCommandService,
            IMessagesHolderQueryService messagesHolderQueryService,
            IProviderResponseStatusQueryService providerResponseStatusQueryService,
            IProviderDeliveryStatusQueryService providerDeliveryStatusQueryService,
            IMessageDetailStatusQueryService messageDetailStatusQueryService)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _smsProviderFactory = smsProviderFactory;
            _smsProviderFactory.NotNull(nameof(smsProviderFactory));

            _messagesDetailQueryService = messagesDetailQueryService;
            _messagesDetailQueryService.NotNull(nameof(_messagesDetailQueryService));

            _messageDetailStatusCommandService = messageDetailStatusCommandService;
            _messageDetailStatusCommandService.NotNull(nameof(messageDetailStatusCommandService));

            _messageDetailStatusCommandService = messageDetailStatusCommandService;
            _messageDetailStatusCommandService.NotNull(nameof(_messageDetailStatusCommandService));

            _messagesHolderQueryService = messagesHolderQueryService;
            _messagesHolderQueryService.NotNull(nameof(_messagesHolderQueryService));

            _providerResponseStatusQueryService = providerResponseStatusQueryService;
            _providerResponseStatusQueryService.NotNull(nameof(providerResponseStatusQueryService));

            _providerDeliveryStatusQueryService = providerDeliveryStatusQueryService;
            _providerDeliveryStatusQueryService.NotNull(nameof(_providerDeliveryStatusQueryService));

            _messageDetailStatusQueryService = messageDetailStatusQueryService;
            _messageDetailStatusQueryService.NotNull(nameof(messageDetailStatusQueryService));
        }

        public async Task Trigger(long messageDetailStatusId, ProviderEnum providerId)
        {
            //TODO: get provider responser from new table MessageDetailStatus
            ICollection<ProviderResponseStatus> responseStatusList = await _providerResponseStatusQueryService.Get();
            ICollection<ProviderDeliveryStatus> deliveryStatusList=await _providerDeliveryStatusQueryService.Get();
            MessageDetailStatus messageDetailStatus = await _messageDetailStatusQueryService.GetByIdIncludeDetails(messageDetailStatusId);
            MessageDetail messageDetail = await _messagesDetailQueryService.GetInclude(messageDetailStatus.MessagesDetail.Id);
           
            ISmsProvider smsProvider = _smsProviderFactory.Create(providerId);
            var statusInfo = new MessageAndProviderIdDto()
            {
                MessageDetailId = messageDetailStatusId,
                ProviderServerId=messageDetailStatus.ProviderServerId,
            };
            CreateMessageDetailStatusDto createMessageDetailStatusDto =  await smsProvider.GetState(messageDetail.MessagesHolder.MessageBatch.Line,statusInfo,messageDetail.MessagesHolderId, responseStatusList,deliveryStatusList);

            // delivery status
            var newMessageDetailStatus = _mapper.Map<MessageDetailStatus>(createMessageDetailStatusDto);
            await _messageDetailStatusCommandService.Add(newMessageDetailStatus);

            await _uow.SaveChangesAsync(CancellationToken.None);
        }
    }
}
