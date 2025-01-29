using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Config.Commands.Contracts;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts;
using FluentValidation;
using SmsHub.Application.Exceptions;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Create.Implementations
{
    public class ConfigTypeGroupCreateHandler : IConfigTypeGroupCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IConfigTypeGroupCommandService _configTypeGroupCommandService;
        private readonly IValidator<CreateConfigTypeGroupDto> _validator;
        public ConfigTypeGroupCreateHandler(
            IConfigTypeGroupCommandService configTypeGroupCommandService,
            IMapper mapper,
            IValidator<CreateConfigTypeGroupDto> validator)
        {
            _configTypeGroupCommandService = configTypeGroupCommandService;
            _configTypeGroupCommandService.NotNull(nameof(_configTypeGroupCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateConfigTypeGroupDto createConfigTypeGroupDto, CancellationToken cancellationToken)
        {
            await CheckValidator(createConfigTypeGroupDto, cancellationToken);

            var configTypeGroup = _mapper.Map<Entities.ConfigTypeGroup>(createConfigTypeGroupDto);
            await _configTypeGroupCommandService.Add(configTypeGroup);
        }
        private async Task CheckValidator(CreateConfigTypeGroupDto createConfigTypeGroupDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(createConfigTypeGroupDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }
    }
}
