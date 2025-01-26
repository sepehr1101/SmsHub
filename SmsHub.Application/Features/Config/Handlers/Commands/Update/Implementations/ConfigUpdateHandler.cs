using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Update.Implementations
{
    public class ConfigUpdateHandler : IConfigUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IConfigQueryService _configQueryService;
        private readonly IValidator<UpdateConfigDto> _validator;
        public ConfigUpdateHandler(
            IMapper mapper,
            IConfigQueryService configQueryService,
            IValidator<UpdateConfigDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _configQueryService = configQueryService;
            _configQueryService.NotNull(nameof(configQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdateConfigDto updateConfigDto, CancellationToken cancellationToken)
        {
            await CheckValidator(updateConfigDto, cancellationToken);

            var config = await _configQueryService.Get(updateConfigDto.Id);
            _mapper.Map(updateConfigDto, config);
        }

        private async Task CheckValidator(UpdateConfigDto updateConfigDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateConfigDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }
        }
    }
}