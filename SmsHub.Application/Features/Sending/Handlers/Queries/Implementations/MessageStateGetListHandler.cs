using AutoMapper;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Queries.Implementations
{
    public class MessageStateGetListHandler: IMessageStateGetListHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageStateQueryService _messageStateQueryService;
        public MessageStateGetListHandler(IMapper mapper    ,IMessageStateQueryService messageStateQueryService)
        {
            _mapper=mapper;
            _mapper.NotNull(nameof(mapper));

            _messageStateQueryService=messageStateQueryService;
            _messageStateQueryService.NotNull(nameof(messageStateQueryService));
        }
        public async Task<ICollection<GetMessageStateDto>> Handle()
        {
            var messageStates = await _messageStateQueryService.Get();
            return _mapper.Map<ICollection<GetMessageStateDto>>(messageStates);
        }
    }
}
