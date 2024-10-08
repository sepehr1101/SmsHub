using AutoMapper;
using SmsHub.Application.Features.Sending.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Features.Sending.Queries.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Update.Implementations
{
    public class MessageStateUpdateHandler: IMessageStateUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageStateQueryService _messageStateQueryService;
        public MessageStateUpdateHandler(IMapper mapper, IMessageStateQueryService messageStateQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageStateQueryService = messageStateQueryService;
            _messageStateQueryService.NotNull(nameof(messageStateQueryService));
        }
        public async Task Handle(UpdateMessageStateDto updateMessageStateDto, CancellationToken cancellationToken)

        {
            var messageState = await _messageStateQueryService.Get(updateMessageStateDto.Id);
            _mapper.Map(updateMessageStateDto, messageState);
        }
    }
}
