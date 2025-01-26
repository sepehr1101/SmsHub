using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Implementations
{
    public class MessageDetailStatusCreateHandler : IMessageDetailStatusCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageDetailStatusCommandService _messageDetailStatusCommandService;

        public MessageDetailStatusCreateHandler(
            IMapper mapper,
            IMessageDetailStatusCommandService messageDetailStatusCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _messageDetailStatusCommandService = messageDetailStatusCommandService;
            _messageDetailStatusCommandService.NotNull(nameof(messageDetailStatusCommandService));

        }
        public async Task Handle(CreateMessageDetailStatusDto createMessageDetailStatusDto, CancellationToken cancellationToken)
        {
            var messageDetailStatus = _mapper.Map<MessageDetailStatus>(createMessageDetailStatusDto);
            await _messageDetailStatusCommandService.Add(messageDetailStatus);
        }

        
    }
}
