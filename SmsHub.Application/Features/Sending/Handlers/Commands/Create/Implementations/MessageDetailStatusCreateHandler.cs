using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Implementations
{
    public class MessageDetailStatusCreateHandler : IMessageDetailStatusCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageDetailStatusCommandService _messageDetailStatusCommandService;
        private readonly IValidator<CreateMessageDetailStatusDto> _validator;

        public MessageDetailStatusCreateHandler(
            IMapper mapper,
            IMessageDetailStatusCommandService messageDetailStatusCommandService,
            IValidator<CreateMessageDetailStatusDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageDetailStatusCommandService = messageDetailStatusCommandService;
            _messageDetailStatusCommandService.NotNull(nameof(messageDetailStatusCommandService));

            _validator = validator;
           _validator.NotNull(nameof(validator));
        }
        public async Task Handle(CreateMessageDetailStatusDto createMessageDetailStatusDto, CancellationToken cancellationToken)
        {
            await CheckValidator(createMessageDetailStatusDto, cancellationToken);

            var messageDetailStatus = _mapper.Map<MessageDetailStatus>(createMessageDetailStatusDto);
            await _messageDetailStatusCommandService.Add(messageDetailStatus);
        }

        private async Task CheckValidator(CreateMessageDetailStatusDto createMessageDetailStatusDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(createMessageDetailStatusDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }
        }


    }
}
