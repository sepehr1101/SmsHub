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
    public sealed class SendInBackgroundService : ISendInBackgroundService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly ISmsProviderFactory _smsProviderFactory;
        private readonly IMessagesHolderQueryService _messagesHolderQueryService;
        private readonly IMessagesDetailQueryService _messagesDetailQueryService;
        private readonly IProviderResponseStatusQueryService _providerResponseStatusQueryService;
        private readonly IProviderDeliveryStatusQueryService _providerDeliveryStatusQueryService;
        private readonly IMessageDetailStatusCommandService _messageDetailStatusCommandService;
        private readonly IStatusInBackgroundService _statusInBackgroundService;


        public SendInBackgroundService(
            IMapper mapper,
            IUnitOfWork uow,
            ISmsProviderFactory smsProviderFactory,
            IMessagesHolderQueryService messagesHolderQueryService,
            IMessagesDetailQueryService messagesDetailQueryService,
            IProviderResponseStatusQueryService providerResponseStatusQueryService,
            IProviderDeliveryStatusQueryService providerDeliveryStatusQueryService,
            IMessageDetailStatusCommandService messageDetailStatusCommandService,
            IStatusInBackgroundService statusInBackgroundService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _uow = uow;
            _uow.NotNull(nameof(uow));

            _smsProviderFactory = smsProviderFactory;
            _smsProviderFactory.NotNull(nameof(_smsProviderFactory));

            _messagesHolderQueryService = messagesHolderQueryService;
            _messagesHolderQueryService.NotNull(nameof(_messagesHolderQueryService));

            _messagesDetailQueryService = messagesDetailQueryService;
            _messagesDetailQueryService.NotNull(nameof(_messagesDetailQueryService));

            _providerResponseStatusQueryService = providerResponseStatusQueryService;
            _providerResponseStatusQueryService.NotNull(nameof(_providerResponseStatusQueryService));

            _providerDeliveryStatusQueryService = providerDeliveryStatusQueryService;
            _providerDeliveryStatusQueryService.NotNull(nameof(providerDeliveryStatusQueryService));

            _messageDetailStatusCommandService = messageDetailStatusCommandService;
            _messageDetailStatusCommandService.NotNull(nameof(messageDetailStatusCommandService));

            _statusInBackgroundService=statusInBackgroundService; 
            _statusInBackgroundService.NotNull(nameof(statusInBackgroundService));
        }
        public async Task Trigger(Guid messageHolderId, ProviderEnum providerId)
        {
            MessagesHolder messageHolder = await _messagesHolderQueryService.GetIncludeLine(messageHolderId);
            ICollection<MobileText> mobileTextList = await _messagesDetailQueryService.GetMobileTextList(messageHolderId);
            ISmsProvider smsProvider = _smsProviderFactory.Create(providerId);

            ICollection<ProviderResponseStatus> responseStatusList = await _providerResponseStatusQueryService.Get();
            ICollection<ProviderDeliveryStatus> deliveryStatusList = await _providerDeliveryStatusQueryService.Get();
            ICollection<CreateMessageDetailStatusDto> result = await smsProvider.Send(messageHolder.MessageBatch.Line, mobileTextList, messageHolderId, responseStatusList, deliveryStatusList);

            //add to delivery status
            var messageDetailStatus = _mapper.Map<ICollection<MessageDetailStatus>>(result);
            await _messageDetailStatusCommandService.Add(messageDetailStatus);

            await _uow.SaveChangesAsync(CancellationToken.None);

            //Get Status
            BackgroundJob.Enqueue(() => _statusInBackgroundService.Trigger(messageHolderId, providerId));
        }
    }
}