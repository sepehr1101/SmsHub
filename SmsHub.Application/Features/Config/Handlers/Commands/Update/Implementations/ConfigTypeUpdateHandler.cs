using AutoMapper;
using SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Persistence.Features.Config.Queries.Contracts;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using FluentValidation;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Update.Implementations
{
    public class ConfigTypeUpdateHandler : IConfigTypeUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IConfigTypeQueryService _configTypeQueryService;
        private readonly IValidator<UpdateConfigTypeDto> _validator;
        public ConfigTypeUpdateHandler(
            IMapper mapper,
            IConfigTypeQueryService configTypeQueryService, 
            IValidator<UpdateConfigTypeDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _configTypeQueryService = configTypeQueryService;
            _configTypeQueryService.NotNull(nameof(configTypeQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdateConfigTypeDto updateConfigTypeDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateConfigTypeDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var configType = await _configTypeQueryService.Get(updateConfigTypeDto.Id);
            _mapper.Map(updateConfigTypeDto, configType);
        }
    }
}
