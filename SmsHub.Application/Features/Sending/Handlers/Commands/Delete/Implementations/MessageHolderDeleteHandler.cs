using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Sending.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Delete.Implementations
{
    public class MessageHolderDeleteHandler : IMessageHolderDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageHolderCommandService _messageHolderCommandService;
        private readonly IMessagesHolderQueryService _messagesHolderQueryService;
        private readonly IValidator<DeleteMessageHolderDto> _validator;
        public MessageHolderDeleteHandler(
            IMapper mapper,
            IMessageHolderCommandService messageHolderCommandService,
            IMessagesHolderQueryService messagesHolderQueryService,
            IValidator<DeleteMessageHolderDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageHolderCommandService = messageHolderCommandService;
            _messageHolderCommandService.NotNull(nameof(messagesHolderQueryService));

            _messagesHolderQueryService = messagesHolderQueryService;
            _messagesHolderQueryService.NotNull(nameof(messagesHolderQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(DeleteMessageHolderDto deleteMessageHolderDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(deleteMessageHolderDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var messageHolder = await _messagesHolderQueryService.Get(deleteMessageHolderDto.Id);
            _messageHolderCommandService.Delete(messageHolder);
        }
    }
}
