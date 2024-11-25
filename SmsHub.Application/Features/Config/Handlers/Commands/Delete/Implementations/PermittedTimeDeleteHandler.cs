using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Config.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Config.Commands.Contracts;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Delete.Implementations
{
    public class PermittedTimeDeleteHandler : IPermittedTimeDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IPermittedTimeCommandService _permittedTimeCommandService;
        private readonly IPermittedTimeQueryService _permittedTimeQueryService;
        private readonly IValidator<DeletePermittedTimeDto> _validator;
        public PermittedTimeDeleteHandler(
            IMapper mapper,
            IPermittedTimeCommandService permittedTimeCommandService,
            IPermittedTimeQueryService permittedTimeQueryService,
            IValidator<DeletePermittedTimeDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _permittedTimeCommandService = permittedTimeCommandService;
            _permittedTimeCommandService.NotNull(nameof(permittedTimeQueryService));

            _permittedTimeQueryService = permittedTimeQueryService;
            _permittedTimeQueryService.NotNull(nameof(permittedTimeQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(DeletePermittedTimeDto deletePermittedTimeDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(deletePermittedTimeDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var permittedTime = await _permittedTimeQueryService.Get(deletePermittedTimeDto.Id);
            _permittedTimeCommandService.Delete(permittedTime);
        }
    }
}
