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
        public MessageBatchDeleteHandler(
            IMapper mapper,
            IMessageBatchCommandService messageBatchCommandService,
            IMessageBatchQueryService messageBatchQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageBatchCommandService = messageBatchCommandService;
            _messageBatchCommandService.NotNull(nameof(messageBatchCommandService));

            _messageBatchQueryService = messageBatchQueryService;
            _messageBatchQueryService.NotNull(nameof(messageBatchQueryService));
        }
        public async Task Handle(DeleteMessageBatchDto deleteMessageBatchDto, CancellationToken cancellationToken)
        {
            var messageBatch = await _messageBatchQueryService.Get(deleteMessageBatchDto.Id);
            _messageBatchCommandService.Delete(messageBatch);
        }
    }
}
