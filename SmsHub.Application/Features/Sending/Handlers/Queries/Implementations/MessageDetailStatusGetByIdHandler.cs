using AutoMapper;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Queries.Implementations
{
    public class MessageDetailStatusGetByIdHandler : IMessageDetailStatusGetByIdHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageDetailStatusQueryService _messageDetailStatusQueryService;

        public MessageDetailStatusGetByIdHandler(
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
            var messageDetailStatus = await _messageDetailStatusQueryService.GetById(Id);
            var getMessageDetailStatus = _mapper
                .Map<GetMessageDetailStatusByIdDto>(messageDetailStatus);

            return getMessageDetailStatus;
        }
    }
}
