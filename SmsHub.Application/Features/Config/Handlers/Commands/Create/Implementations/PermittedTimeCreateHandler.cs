using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Config.Commands.Contracts;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts;
using FluentValidation;
using System.Linq;
using SmsHub.Common.Exceptions;
using SmsHub.Application.Exceptions;

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

        public async Task Handle(CreatePermittedTimeDto createPermittedTimeDto, CancellationToken cancellationToken)
        {
            await CheckValidator(createPermittedTimeDto, cancellationToken);

            var permittedTime = _mapper.Map<Entities.PermittedTime>(createPermittedTimeDto);
            await _permittedTimeCommandService.Add(permittedTime);
        }
        private async Task CheckValidator(CreatePermittedTimeDto createPermittedTimeDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(createPermittedTimeDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }

    }
}
