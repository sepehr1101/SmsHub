using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using FluentValidation;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Implementations
{
    public class MessageHolderCreateHandler : IMessageHolderCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageHolderCommandService _messageHolderCommandService;
        private readonly IValidator<CreateMessagesHolderDto> _validator;
        public MessageHolderCreateHandler(IMapper mapper, IMessageHolderCommandService messageHolderCommandService, IValidator<CreateMessagesHolderDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _messageHolderCommandService = messageHolderCommandService;
            _messageHolderCommandService.NotNull(nameof(_messageHolderCommandService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateMessagesHolderDto createMessagesHolderDto, CancellationToken cancellationToken)
        {
            await CheckValidator(createMessagesHolderDto, cancellationToken);

            var messageHolder = _mapper.Map<Entities.MessagesHolder>(createMessagesHolderDto);
            await _messageHolderCommandService.Add(messageHolder);
        }

        private async Task CheckValidator(CreateMessagesHolderDto createMessagesHolderDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(createMessagesHolderDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }
        }


    }
}
