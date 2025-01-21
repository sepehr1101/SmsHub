using AutoMapper;
using SmsHub.Application.Features.Sending.Factories;
using SmsHub.Application.Features.Sending.Services.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Services.Implementations
{
    public sealed class SendInBackgroundService : ISendInBackgroundService
    {
        private readonly ISmsProviderFactory _smsProviderFactory;
        private readonly IMessagesHolderQueryService _messagesHolderQueryService;
        private readonly IMessagesDetailQueryService _messagesDetailQueryService;
        private readonly IProviderResponseStatusQueryService _providerResponseStatusQueryService;
        private readonly IProviderDeliveryStatusQueryService _providerDeliveryStatusQueryService;
        private readonly IMessageDetailStatusCommandService _messageDetailStatusCommandService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public SendInBackgroundService(
            ISmsProviderFactory smsProviderFactory,
            IMessagesHolderQueryService messagesHolderQueryService,
            IMessagesDetailQueryService messagesDetailQueryService,
            IProviderResponseStatusQueryService providerResponseStatusQueryService,
            IProviderDeliveryStatusQueryService providerDeliveryStatusQueryService,
            IMessageDetailStatusCommandService messageDetailStatusCommandService,
            IMapper mapper,
            IUnitOfWork uow)
        {
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

            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _uow = uow;
            _uow.NotNull(nameof(uow));
        }
        public async Task Trigger(Guid messageHolderId, ProviderEnum providerId)
        {
            var messageHolder = await _messagesHolderQueryService.GetIncludeLine(messageHolderId);
            var mobileTextList = await _messagesDetailQueryService.GetMobileTextList(messageHolderId);
            var smsProvider = _smsProviderFactory.Create(providerId);

            var responseStatusList = await _providerResponseStatusQueryService.Get();
            var deliveryStatusList=await _providerDeliveryStatusQueryService.Get();
            var result = await smsProvider.Send(messageHolder.MessageBatch.Line, mobileTextList,messageHolderId, responseStatusList, deliveryStatusList);

            // delivery status
            var messageDetailStatus = _mapper.Map<ICollection<MessageDetailStatus>>(result);
            await _messageDetailStatusCommandService.Add(messageDetailStatus);

            await _uow.SaveChangesAsync(CancellationToken.None);
        }
    }
}