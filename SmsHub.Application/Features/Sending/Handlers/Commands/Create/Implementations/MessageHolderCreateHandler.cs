using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Implementations
{
    public class MessageHolderCreateHandler : IMessageHolderCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageHolderCommandService _messageHolderCommandService;
        public MessageHolderCreateHandler(IMapper mapper, IMessageHolderCommandService messageHolderCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _messageHolderCommandService = messageHolderCommandService;
            _messageHolderCommandService.NotNull(nameof(_messageHolderCommandService));
        }

        public async Task Handle(CreateMessagesHolderDto request, CancellationToken cancellationToken)
        {
            var messageHolder = _mapper.Map<Entities.MessagesHolder>(request);
            await _messageHolderCommandService.Add(messageHolder);
        }
    }
}
