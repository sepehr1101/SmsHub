using AutoMapper;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Queries.Implementations
{
    public  class MessageStateGetSingleHandler: IMessageStateGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageStateQueryService _messageStateQueryService;
        public MessageStateGetSingleHandler(IMapper mapper, IMessageStateQueryService messageStateQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageStateQueryService = messageStateQueryService;
            _messageStateQueryService.NotNull(nameof(messageStateQueryService));
        }
        public async Task<GetMessageStateDto> Handle(IntId Id)
        {
            var messageState = await _messageStateQueryService.Get(Id.Id);
            return _mapper.Map<GetMessageStateDto>(messageState);
        }
    }
}
