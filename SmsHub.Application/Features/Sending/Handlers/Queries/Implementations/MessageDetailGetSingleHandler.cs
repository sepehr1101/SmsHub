using AutoMapper;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Queries.Implementations
{
    public class MessageDetailGetSingleHandler: IMessageDetailGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessagesDetailQueryService _messagesDetailQueryService;
        public MessageDetailGetSingleHandler(IMapper mapper, IMessagesDetailQueryService messagesDetailQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messagesDetailQueryService = messagesDetailQueryService;
            _messagesDetailQueryService.NotNull(nameof(messagesDetailQueryService));
        }
        public async Task<GetMessageDetailDto> Handle(LongId Id)
        {
            var messageDetail = await _messagesDetailQueryService.Get(Id.Id);
            return _mapper.Map<GetMessageDetailDto>(messageDetail);
        }
    }
}
