using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Config.Commands.Contracts;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts;
using FluentValidation;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Create.Implementations
{
    public class PermittedTimeCreateHandler : IPermittedTimeCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IPermittedTimeCommandService _permittedTimeCommandService;
        private readonly IValidator<CreatePermittedTimeDto> _validator;
        public PermittedTimeCreateHandler(
            IPermittedTimeCommandService permittedTimeCommandService,
            IMapper mapper,
            IValidator<CreatePermittedTimeDto> validator)
        {
            _permittedTimeCommandService = permittedTimeCommandService;
            _permittedTimeCommandService.NotNull(nameof(_permittedTimeCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreatePermittedTimeDto request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var permittedTime = _mapper.Map<Entities.PermittedTime>(request);
            await _permittedTimeCommandService.Add(permittedTime);
        }
    }
}
