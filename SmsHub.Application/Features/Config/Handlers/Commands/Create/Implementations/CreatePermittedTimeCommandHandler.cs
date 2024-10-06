using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Config.Commands.Contracts;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Create.Implementations
{
    public class CreatePermittedTimeCommandHandler : ICreatePermittedTimeCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IPermittedTimeCommandService _permittedTimeCommandService;
        public CreatePermittedTimeCommandHandler(IMapper mapper, IPermittedTimeCommandService permittedTimeCommandService)
        {
            _permittedTimeCommandService = permittedTimeCommandService;
            _permittedTimeCommandService.NotNull(nameof(_permittedTimeCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));
        }

        public async Task Handle(CreatePermittedTimeDto request, CancellationToken cancellationToken)
        {
            var permittedTime = _mapper.Map<Entities.PermittedTime>(request);
            await _permittedTimeCommandService.Add(permittedTime);
        }
    }
}
