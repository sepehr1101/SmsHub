using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Implementations
{
    public class CreateMessageDetailCommandHandler : ICreateMessageDetailCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageDetailCommandService _messageDetailCommandService;
        public CreateMessageDetailCommandHandler(IMapper mapper, IMessageDetailCommandService messageDetailCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _messageDetailCommandService = messageDetailCommandService;
            _messageDetailCommandService.NotNull(nameof(_messageDetailCommandService));
        }

        public async Task Handle(CreateMessageDetailDto request, CancellationToken cancellationToken)
        {
            var messageDetail = _mapper.Map<Entities.MessagesDetail>(request);
            await _messageDetailCommandService.Add(messageDetail);
        }
    }
}
