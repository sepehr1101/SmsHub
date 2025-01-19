using AutoMapper;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Queries.Implementations
{
    public class MessageDetailStatusGetByMessageDetailIdHandler : IMessageDetailStatusGetByMessageDetailIdHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageDetailStatusQueryService _messageDetailStatusQueryService;

        public MessageDetailStatusGetByMessageDetailIdHandler(
            IMapper mapper,
            IMessageDetailStatusQueryService messageDetailStatusQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageDetailStatusQueryService = messageDetailStatusQueryService;
            _messageDetailStatusQueryService.NotNull(nameof(messageDetailStatusQueryService));
        }


        public async Task<ICollection<GetMessageDetailStatusByMessageDetailIdDto>> Handle(long Id)
        {
            var messageDetailStatuses = await _messageDetailStatusQueryService.GetByMessageDetailId(Id);
            var getMessageDetailStatuses = _mapper
                .Map<ICollection<GetMessageDetailStatusByMessageDetailIdDto>>(messageDetailStatuses);

            return getMessageDetailStatuses;
        }
    }
}
