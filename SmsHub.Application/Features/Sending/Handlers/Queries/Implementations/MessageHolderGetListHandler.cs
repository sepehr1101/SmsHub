using AutoMapper;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Queries.Implementations
{
    public class MessageHolderGetListHandler: IMessageHolderGetListHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessagesHolderQueryService _messagesHolderQueryService;
        public MessageHolderGetListHandler(
            IMapper mapper ,
            IMessagesHolderQueryService messagesHolderQueryService)
        {
            _mapper=mapper;
           _mapper.NotNull(nameof(mapper));

            _messagesHolderQueryService=messagesHolderQueryService;
            _messagesHolderQueryService.NotNull(nameof(messagesHolderQueryService));
        }
        public async Task<ICollection<GetMessageHolderDto>> Handle()
        {
            var messageHolders = await _messagesHolderQueryService.Get();
            return _mapper.Map<ICollection<GetMessageHolderDto>>(messageHolders);
        }
    }
}
