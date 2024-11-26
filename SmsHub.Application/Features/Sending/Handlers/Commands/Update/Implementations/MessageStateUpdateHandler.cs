using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Sending.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Update.Implementations
{
    public class MessageStateUpdateHandler : IMessageStateUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageStateQueryService _messageStateQueryService;
        private readonly IValidator<UpdateMessageStateDto> _validator;
        public MessageStateUpdateHandler(IMapper mapper, IMessageStateQueryService messageStateQueryService, IValidator<UpdateMessageStateDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageStateQueryService = messageStateQueryService;
            _messageStateQueryService.NotNull(nameof(messageStateQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdateMessageStateDto updateMessageStateDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateMessageStateDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var messageState = await _messageStateQueryService.Get(updateMessageStateDto.Id);
            _mapper.Map(updateMessageStateDto, messageState);
        }
    }
}
