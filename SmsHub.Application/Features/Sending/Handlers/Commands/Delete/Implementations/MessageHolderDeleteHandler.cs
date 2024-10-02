using AutoMapper;
using SmsHub.Application.Features.Sending.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Delete.Implementations
{
    public class MessageHolderDeleteHandler : IMessageHolderDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageHolderCommandService _messageHolderCommandService;
        private readonly IMessagesHolderQueryService _messagesHolderQueryService;
        public MessageHolderDeleteHandler(
            IMapper mapper,
            IMessageHolderCommandService messageHolderCommandService,
            IMessagesHolderQueryService messagesHolderQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageHolderCommandService = messageHolderCommandService;
            _messageHolderCommandService.NotNull(nameof(messagesHolderQueryService));

            _messagesHolderQueryService = messagesHolderQueryService;
            _messagesHolderQueryService.NotNull(nameof(messagesHolderQueryService));
        }
        public async Task Handle(DeleteMessageHolderDto deleteMessageHolderDto, CancellationToken cancellationToken)
        {
           var messageHolder=await _messagesHolderQueryService.Get(deleteMessageHolderDto.Id);
            _messageHolderCommandService.Delete(messageHolder);
        }
    }
}
