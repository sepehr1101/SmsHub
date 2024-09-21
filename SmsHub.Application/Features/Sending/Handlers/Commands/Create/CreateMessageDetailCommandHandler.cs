using AutoMapper;
using MediatR;
using SmsHub.Common;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create
{
    public class CreateMessageDetailCommandHandler:IRequestHandler<CreateMessageDetailDto>
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
