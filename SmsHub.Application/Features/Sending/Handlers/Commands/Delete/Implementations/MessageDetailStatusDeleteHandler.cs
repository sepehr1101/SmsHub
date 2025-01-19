using AutoMapper;
using SmsHub.Application.Features.Sending.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Delete.Implementations
{
    public class MessageDetailStatusDeleteHandler : IMessageDetailStatusDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageDetailStatusCommandService _messageDetailStatusCommandService;

        public MessageDetailStatusDeleteHandler(
            IMapper mapper,
            IMessageDetailStatusCommandService messageDetailStatusCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageDetailStatusCommandService = messageDetailStatusCommandService;
            _messageDetailStatusCommandService.NotNull(nameof(messageDetailStatusCommandService));
        }
        
        public async Task Handle(DeleteMessageDetailStatusDto request, CancellationToken cancellationToken)
        {
            var messageDetailStatus = _mapper.Map<MessageDetailStatus>(request);
             _messageDetailStatusCommandService.Delete(messageDetailStatus);
        }
    }
}
