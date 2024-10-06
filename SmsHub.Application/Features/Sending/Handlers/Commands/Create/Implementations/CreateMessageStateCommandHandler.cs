using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Implementations
{
    public class CreateMessageStateCommandHandler : ICreateMessageStateCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageStateCommandService _messageStateCommandService;
        public CreateMessageStateCommandHandler(IMapper mapper, IMessageStateCommandService messageStateCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _messageStateCommandService = messageStateCommandService;
            _messageStateCommandService.NotNull(nameof(_messageStateCommandService));
        }

        public async Task Handle(CreateMessageStateDto request, CancellationToken cancellationToken)
        {
            var messageState = _mapper.Map<Entities.MessageState>(request);
            await _messageStateCommandService.Add(messageState);
        }
    }
}
