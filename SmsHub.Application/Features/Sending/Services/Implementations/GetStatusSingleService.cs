using AutoMapper;
using SmsHub.Application.Features.Sending.Factories;
using SmsHub.Application.Features.Sending.Services.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Sending.Entities;
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
            IMessageDetailStatusQueryService messagesDetailQueryService,
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

        public async Task Trigger(long messageDetailId, ProviderEnum providerId)
        {
            var responseStatusList = await _providerResponseStatusQueryService.Get();
            var deliveryStatusList=await _providerDeliveryStatusQueryService.Get();
            var messageDetail = await _messagesDetailQueryService.GetInclude(messageDetailId);
            var providerServer = await _messageDetailStatusQueryService.GetById(messageDetailId);
            var smsProvider = _smsProviderFactory.Create(providerId);
            var statusInfo = new MessageAndProviderIdDto()
            {
                MessageDetailId = messageDetailId,
                ProviderServerId=providerServer.ProviderServerId
            };

          var result=  await smsProvider.GetState(messageDetail.MessagesHolder.MessageBatch.Line,statusInfo,messageDetail.MessagesHolderId, responseStatusList,deliveryStatusList);

            // delivery status
            var messageDetailStatus = _mapper.Map<MessageDetailStatus>(result);
            await _messageDetailStatusCommandService.Add(messageDetailStatus);

            await _uow.SaveChangesAsync(CancellationToken.None);
        }

     
    }
}
