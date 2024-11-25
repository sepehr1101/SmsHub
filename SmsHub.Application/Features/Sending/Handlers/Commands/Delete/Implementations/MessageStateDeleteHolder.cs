using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Sending.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Delete.Implementations
{
    public class MessageStateDeleteHolder : IMessageStateDeleteHolder
    {
        private readonly IMapper _mapper;
        private readonly IMessageStateCommandService _messageStateCommandService;
        private readonly IMessageStateQueryService _messageStateQueryService;
        private readonly IValidator<DeleteMessageStateDto> _validator;
        public MessageStateDeleteHolder(
            IMapper mapper,
            IMessageStateCommandService messageStateCommandService,
            IMessageStateQueryService messageStateQueryService,
            IValidator<DeleteMessageStateDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageStateCommandService = messageStateCommandService;
            _messageStateCommandService.NotNull(nameof(messageStateCommandService));

            _messageStateQueryService = messageStateQueryService;
            _messageStateQueryService.NotNull(nameof(messageStateQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(DeleteMessageStateDto deleteMessageStateDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(deleteMessageStateDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var messageState = await _messageStateQueryService.Get(deleteMessageStateDto.Id);
            _messageStateCommandService.Delete(messageState);
        }
    }
}
