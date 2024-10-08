using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Implementations
{
    public class MessageBatchCreateHandler : IMessageBatchCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageBatchCommandService _messageBatchCommandService;
        public MessageBatchCreateHandler(IMapper mapper, IMessageBatchCommandService messageBatchCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _messageBatchCommandService = messageBatchCommandService;
            _messageBatchCommandService.NotNull(nameof(_messageBatchCommandService));
        }

        public async Task Handle(CreateMessageBatchDto request, CancellationToken cancellationToken)
        {
            var messageBatch = _mapper.Map<Entities.MessageBatch>(request);
            await _messageBatchCommandService.Add(messageBatch);
        }
    }
}
