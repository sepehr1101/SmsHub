using AutoMapper;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Queries.Implementations
{
    public class MessageBatchGetSingleHandler: IMessageBatchGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageBatchQueryService _messageBatchQueryService;
        public MessageBatchGetSingleHandler(IMapper mapper, IMessageBatchQueryService messageBatchQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageBatchQueryService = messageBatchQueryService;
            _messageBatchQueryService.NotNull(nameof(messageBatchQueryService));
        }
        public async Task<GetMessageBatchDto> Handle(int Id)
        {
            var messageBatch = await _messageBatchQueryService.Get(Id);
            return _mapper.Map<GetMessageBatchDto>(messageBatch);
        }
    }
}
