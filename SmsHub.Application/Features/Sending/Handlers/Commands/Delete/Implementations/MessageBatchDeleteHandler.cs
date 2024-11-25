using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Sending.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Delete.Implementations
{
    public class MessageBatchDeleteHandler : IMessageBatchDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageBatchCommandService _messageBatchCommandService;
        private readonly IMessageBatchQueryService _messageBatchQueryService;
        private readonly IValidator<DeleteMessageBatchDto> _validator;
        public MessageBatchDeleteHandler(
            IMapper mapper,
            IMessageBatchCommandService messageBatchCommandService,
            IMessageBatchQueryService messageBatchQueryService,
            IValidator<DeleteMessageBatchDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageBatchCommandService = messageBatchCommandService;
            _messageBatchCommandService.NotNull(nameof(messageBatchCommandService));

            _messageBatchQueryService = messageBatchQueryService;
            _messageBatchQueryService.NotNull(nameof(messageBatchQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(DeleteMessageBatchDto deleteMessageBatchDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(deleteMessageBatchDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var messageBatch = await _messageBatchQueryService.Get(deleteMessageBatchDto.Id);
            _messageBatchCommandService.Delete(messageBatch);
        }
    }
}
