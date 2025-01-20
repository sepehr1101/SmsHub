using SmsHub.Application.Features.Sending.Factories;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Services.Implementations
{
    public sealed class GetStatusSingleService
    {
        private readonly IUnitOfWork _uow;
        private readonly ISmsProviderFactory _smsProviderFactory;
        private readonly IMessagesDetailQueryService _messagesDetailQueryService;
        private readonly IMessageDetailStatusCommandService _messageDetailStatusCommandService;
        private readonly IMessagesHolderQueryService _messagesHolderQueryService;
        private readonly IProviderResponseStatusQueryService _providerResponseStatusQueryService;
        public GetStatusSingleService(
            IUnitOfWork uow,
            ISmsProviderFactory smsProviderFactory,
            IMessageDetailStatusQueryService messagesDetailQueryService,
            IMessageDetailStatusCommandService messageDetailStatusCommandService,
            IMessagesHolderQueryService messagesHolderQueryService,
            IProviderResponseStatusQueryService providerResponseStatusQueryService)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

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
        }

        public async Task Trigger(long messageDetailId, ProviderEnum providerId)
        {
            //TODO: get provider responser from new table MessageDetailStatus
            var statusList = await _providerResponseStatusQueryService.Get();
            var messageDetail = await _messagesDetailQueryService.GetInclude(messageDetailId);            
            var smsProvider = _smsProviderFactory.Create(providerId);
            await smsProvider.GetState(messageDetail.MessagesHolder.MessageBatch.Line, messageDetail.Id, statusList);
        }
    }
}
