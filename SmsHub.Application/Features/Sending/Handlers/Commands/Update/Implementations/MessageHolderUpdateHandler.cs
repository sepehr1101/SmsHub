using AutoMapper;
using SmsHub.Application.Features.Sending.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Update.Implementations
{
    public class MessageHolderUpdateHandler: IMessageHolderUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessagesHolderQueryService _messagesHolderQueryService;
        public MessageHolderUpdateHandler(IMapper mapper, IMessagesHolderQueryService messagesHolderQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messagesHolderQueryService = messagesHolderQueryService;
            _messagesHolderQueryService.NotNull(nameof(messagesHolderQueryService));
        }
        public async Task Handle(UpdateMessageHolderDto updateMessageHolderDto, CancellationToken cancellationToken)
        {
            var messageHolder = await _messagesHolderQueryService.Get(updateMessageHolderDto.Id);
            _mapper.Map(updateMessageHolderDto, messageHolder);
        }
    }
}
