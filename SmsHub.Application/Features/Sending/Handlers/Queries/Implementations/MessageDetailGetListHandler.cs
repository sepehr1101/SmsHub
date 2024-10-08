using AutoMapper;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Queries.Implementations
{
    public  class MessageDetailGetListHandler: IMessageDetailGetListHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessagesDetailQueryService _messagesDetailQueryService;
        public MessageDetailGetListHandler(IMapper mapper,IMessagesDetailQueryService messagesDetailQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messagesDetailQueryService= messagesDetailQueryService;
            _messagesDetailQueryService.NotNull(nameof(messagesDetailQueryService));
        }
        public async Task<ICollection<GetMessageDetailDto>> Handle()
        {
            var messageDetails = await _messagesDetailQueryService.Get();
            return _mapper.Map<ICollection<GetMessageDetailDto>>(messageDetails);
        }
    }
}
