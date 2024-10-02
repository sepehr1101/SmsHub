using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using MediatR;
using SmsHub.Persistence.Features.Config.Commands.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Create
{
    public class CreateCcSendCommandHandler :IRequestHandler<CreateCcSendDto>
    {
        private readonly ICcSendCommandService _ccSendCommandService;
        private readonly IMapper _mapper;
        public CreateCcSendCommandHandler(ICcSendCommandService ccSendCommandService, IMapper mapper)
        {
            _ccSendCommandService = ccSendCommandService;
            _ccSendCommandService.NotNull(nameof(_ccSendCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));
        }
        public async Task Handle(CreateCcSendDto request, CancellationToken cancellationToken)
        {
            var ccSend = _mapper.Map<Entities.CcSend>(request);
            await _ccSendCommandService.Add(ccSend);
        }
    }
}
