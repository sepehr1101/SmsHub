using AutoMapper;
using FluentValidation;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Update.Implementations
{
    public class PermittedTimeUpdateHandler : IPermittedTimeUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IPermittedTimeQueryService _permittedTimeQueryService;
        private readonly IValidator<UpdatePermittedTimeDto> _validator;
        public PermittedTimeUpdateHandler(
            IMapper mapper,
            IPermittedTimeQueryService permittedTimeQueryService,
            IValidator<UpdatePermittedTimeDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _permittedTimeQueryService = permittedTimeQueryService;
            _permittedTimeQueryService.NotNull(nameof(permittedTimeQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdatePermittedTimeDto updatePermittedTimeDto, CancellationToken cancellationToken)
        {
            await CheckValidator(updatePermittedTimeDto, cancellationToken);

            var permittedTime = await _permittedTimeQueryService.Get(updatePermittedTimeDto.Id);
            _mapper.Map(updatePermittedTimeDto, permittedTime);
        }


        private async Task CheckValidator(UpdatePermittedTimeDto updatePermittedTimeDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updatePermittedTimeDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }
    }
}