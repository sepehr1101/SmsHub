using AutoMapper;
using SmsHub.Application.Features.Sending.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Update.Implementations
{
    public class MessageDetailUpdateHandler: IMessageDetailUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessagesDetailQueryService _messagesDetailQueryService;
        public MessageDetailUpdateHandler(IMapper mapper, IMessagesDetailQueryService messagesDetailQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messagesDetailQueryService = messagesDetailQueryService;
            _messagesDetailQueryService.NotNull(nameof(messagesDetailQueryService));
        }
        public async Task Handle(UpdateMessageDetailDto updateMessageDetailDto, CancellationToken cancellationToken)
        {
            var messageDetail=await _messagesDetailQueryService.Get(updateMessageDetailDto.Id);
            _mapper.Map(updateMessageDetailDto, messageDetail);
        }
    }
}
