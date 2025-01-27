using AutoMapper;
using FluentValidation;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Update.Implementations
{
    public class ConfigTypeGroupeUpdateHandler : IConfigTypeGroupeUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IConfigTypeGroupQueryService _configTypeGroupQueryService;
        private readonly IValidator<UpdateConfigTypeGroupDto> _validator;
        public ConfigTypeGroupeUpdateHandler(
            IMapper mapper,
            IConfigTypeGroupQueryService configTypeGroupQueryService,
            IValidator<UpdateConfigTypeGroupDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _configTypeGroupQueryService = configTypeGroupQueryService;
            _configTypeGroupQueryService.NotNull(nameof(configTypeGroupQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdateConfigTypeGroupDto updateConfigTypeGroupDto, CancellationToken cancellationToken)
        {
            await CheckValidator(updateConfigTypeGroupDto, cancellationToken);


            var configTypeGroup = await _configTypeGroupQueryService.Get(updateConfigTypeGroupDto.Id);
            _mapper.Map(updateConfigTypeGroupDto, configTypeGroup);
        }

        private async Task CheckValidator(UpdateConfigTypeGroupDto updateConfigTypeGroupDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateConfigTypeGroupDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }
    }
}