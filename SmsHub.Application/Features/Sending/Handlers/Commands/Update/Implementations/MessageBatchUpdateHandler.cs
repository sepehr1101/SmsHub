using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Sending.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Update.Implementations
{
    public class MessageBatchUpdateHandler : IMessageBatchUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageBatchQueryService _messageBatchQueryService;
        private readonly IValidator<UpdateMessageBatchDto> _validator;
        public MessageBatchUpdateHandler(IMapper mapper, IMessageBatchQueryService messageBatchQueryService, IValidator<UpdateMessageBatchDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageBatchQueryService = messageBatchQueryService;
            _messageBatchQueryService.NotNull(nameof(messageBatchQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdateMessageBatchDto updateMessageBatchDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateMessageBatchDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var messageBatch = await _messageBatchQueryService.Get(updateMessageBatchDto.Id);
            _mapper.Map(updateMessageBatchDto, messageBatch);
        }
    }
}
