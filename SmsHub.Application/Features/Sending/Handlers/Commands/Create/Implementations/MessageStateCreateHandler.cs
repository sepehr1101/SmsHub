using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using FluentValidation;
using SmsHub.Application.Exceptions;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Implementations
{
    public class MessageStateCreateHandler : IMessageStateCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageStateCommandService _messageStateCommandService;
        private readonly IValidator<CreateMessageStateDto> _validator;
        public MessageStateCreateHandler(
            IMapper mapper,
            IMessageStateCommandService messageStateCommandService,
            IValidator<CreateMessageStateDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _messageStateCommandService = messageStateCommandService;
            _messageStateCommandService.NotNull(nameof(_messageStateCommandService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateMessageStateDto createMessageStateDto, CancellationToken cancellationToken)
        {
            await CheckValidator(createMessageStateDto, cancellationToken);

            var messageState = _mapper.Map<Entities.MessageState>(createMessageStateDto);
            await _messageStateCommandService.Add(messageState);
        }
        private async Task CheckValidator(CreateMessageStateDto createMessageStateDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(createMessageStateDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }


    }
}
