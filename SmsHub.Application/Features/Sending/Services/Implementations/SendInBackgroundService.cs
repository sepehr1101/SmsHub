using SmsHub.Application.Features.Sending.Factories;
using SmsHub.Application.Features.Sending.Services.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Services.Implementations
{
    public sealed class SendInBackgroundService : ISendInBackgroundService
    {
        private readonly ISmsProviderFactory _smsProviderFactory;
        private readonly IMessagesHolderQueryService _messagesHolderQueryService;
        private readonly IMessagesDetailQueryService _messagesDetailQueryService;

        public SendInBackgroundService(
            ISmsProviderFactory smsProviderFactory,
            IMessagesHolderQueryService messagesHolderQueryService,
            IMessagesDetailQueryService messagesDetailQueryService)
        {
            _smsProviderFactory = smsProviderFactory;
            _smsProviderFactory.NotNull(nameof(_smsProviderFactory));

            _messagesHolderQueryService = messagesHolderQueryService;
            _messagesHolderQueryService.NotNull(nameof(_messagesHolderQueryService));

            _messagesDetailQueryService = messagesDetailQueryService;
            _messagesDetailQueryService.NotNull(nameof(_messagesDetailQueryService));
        }
        public async Task Trigger(Guid messageHolderId, ProviderEnum providerId)
        {
            var messageHolder = await _messagesHolderQueryService.GetIncludeLine(messageHolderId);
            var mobileTextList = await _messagesDetailQueryService.GetMobileTextList(messageHolderId);
            var smsProvider = _smsProviderFactory.Create(providerId);
            await smsProvider.Send(messageHolder.MessageBatch.Line, mobileTextList);
        }
    }
}
