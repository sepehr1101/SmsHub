using AutoMapper;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Queries.Implementations
{
    public class MessageDetailStatusGetAllHandler : IMessageDetailStatusGetAllHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageDetailStatusQueryService _messageDetailStatusQueryService;

        public MessageDetailStatusGetAllHandler(
            IMapper mapper,
            IMessageDetailStatusQueryService messageDetailStatusQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageDetailStatusQueryService = messageDetailStatusQueryService;
            _messageDetailStatusQueryService.NotNull(nameof(messageDetailStatusQueryService));
        }


        public async Task<GetMessageDetailStatusByIdDto> Handle(long Id)
        {
            var messageDetailStatuses = await _messageDetailStatusQueryService.GetById(Id);
            var getMessageDetailStatuses = _mapper
                .Map<GetMessageDetailStatusByIdDto>(messageDetailStatuses);

            return getMessageDetailStatuses;
        }
        public async Task<ICollection<GetMessageDetailStatusDto>> Handle()
        {
            var messageDetailStatuses = await _messageDetailStatusQueryService.GetAll();
            var getMessageDetailStatuses = _mapper
                .Map<ICollection<GetMessageDetailStatusDto>>(messageDetailStatuses);

            return getMessageDetailStatuses;
        }
    }
}
