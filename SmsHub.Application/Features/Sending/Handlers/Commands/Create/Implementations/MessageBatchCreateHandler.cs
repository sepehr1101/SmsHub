using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using FluentValidation;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Implementations
{
    public class MessageBatchCreateHandler : IMessageBatchCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageBatchCommandService _messageBatchCommandService;
        private readonly IValidator<CreateMessageBatchDto> _validator;
        public MessageBatchCreateHandler(
            IMapper mapper, 
            IMessageBatchCommandService messageBatchCommandService,
            IValidator<CreateMessageBatchDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _messageBatchCommandService = messageBatchCommandService;
            _messageBatchCommandService.NotNull(nameof(_messageBatchCommandService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateMessageBatchDto createMessageBatchDto, CancellationToken cancellationToken)
        {
            await CheckValidator(createMessageBatchDto, cancellationToken);

            var messageBatch = _mapper.Map<Entities.MessageBatch>(createMessageBatchDto);
            await _messageBatchCommandService.Add(messageBatch);
        }
        private async Task CheckValidator(CreateMessageBatchDto createMessageBatchDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(createMessageBatchDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }
        }

    }
}
