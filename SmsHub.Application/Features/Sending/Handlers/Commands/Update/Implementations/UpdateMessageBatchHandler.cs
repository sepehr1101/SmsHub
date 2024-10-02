using AutoMapper;
using SmsHub.Application.Features.Sending.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Update.Implementations
{
    public class UpdateMessageBatchHandler: IUpdateMessageBatchHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageBatchQueryService _messageBatchQueryService;
        public UpdateMessageBatchHandler(IMapper mapper, IMessageBatchQueryService messageBatchQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageBatchQueryService = messageBatchQueryService;
            _messageBatchQueryService.NotNull(nameof(messageBatchQueryService));
        }
        public async Task Handle(UpdateMessageBatchDto updateMessageBatchDto, CancellationToken cancellationToken)
        {
            var messageBatch = await _messageBatchQueryService.Get(updateMessageBatchDto.Id);
            _mapper.Map(updateMessageBatchDto, messageBatch);
        }
    }
}
