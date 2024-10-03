using AutoMapper;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Queries.Implementations
{
    public class MessageStateCategoryGetSingleHandler: IMessageStateCategoryGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageStateCategoryQueryService _messageStateCategoryQueryService;
        public MessageStateCategoryGetSingleHandler(IMapper mapper, IMessageStateCategoryQueryService messageStateCategoryQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageStateCategoryQueryService = messageStateCategoryQueryService;
            _messageStateCategoryQueryService.NotNull(nameof(messageStateCategoryQueryService));
        }
        public async Task<GetMessageStateCategoryDto> Handle(int Id)
        {
            var messageStateCategory = await _messageStateCategoryQueryService.Get(Id);
            return _mapper.Map<GetMessageStateCategoryDto>(messageStateCategory);
        }
    }
}
