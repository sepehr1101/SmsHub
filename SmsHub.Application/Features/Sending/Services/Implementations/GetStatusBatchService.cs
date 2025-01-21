using SmsHub.Application.Features.Sending.Factories;
using SmsHub.Application.Features.Sending.Services.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Persistence.Contexts.UnitOfWork;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Services.Implementations
{
    public sealed class GetStatusBatchService : IGetStatusInBackgroundService
    {
        private readonly IUnitOfWork _uow;
        private readonly ISmsProviderFactory _smsProviderFactory;
        private readonly IMessagesDetailQueryService _messagesDetailQueryService;
        private readonly IMessageDetailStatusCommandService _messageDetailStatusCommandService;
        private readonly IMessagesHolderQueryService _messagesHolderQueryService;
        private readonly IProviderResponseStatusQueryService _providerResponseStatusQueryService;
        public GetStatusBatchService(
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

        public async Task Trigger(Guid messageHolderId, ProviderEnum providerId)
        {
            var statusList = await _providerResponseStatusQueryService.Get();
            var messageHolder = await _messagesHolderQueryService.GetIncludeLine(messageHolderId);
            var providerServerIds = messageHolder.MessagesDetails.Select(m => m.Id).ToList();//
            var smsProvider = _smsProviderFactory.Create(providerId);
            await smsProvider.GetState(messageHolder.MessageBatch.Line, providerServerIds, statusList);
        }
    }
}
