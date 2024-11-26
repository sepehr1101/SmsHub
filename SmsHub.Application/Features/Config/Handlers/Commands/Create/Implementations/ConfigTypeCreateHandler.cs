using AutoMapper;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Common.Extensions;
using MediatR;
using SmsHub.Persistence.Features.Config.Commands.Contracts;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts;
using FluentValidation;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Create.Implementations
{
    public class ConfigTypeCreateHandler:IConfigTypeCreateHandler
    {
        private readonly IConfigTypeCommandService _configTypeCommandService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateConfigTypeDto> _validator;
        public ConfigTypeCreateHandler(IConfigTypeCommandService configCommandService, IMapper mapper,IValidator<CreateConfigTypeDto> validator)
        {
            _configTypeCommandService = configCommandService;
            _configTypeCommandService.NotNull(nameof(_configTypeCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _validator = validator; 
            _validator.NotNull(nameof(_validator)); 
        }
        public async Task Handle(CreateConfigTypeDto request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var configType = _mapper.Map<Entities.ConfigType>(request);
            await _configTypeCommandService.Add(configType);
        }
    }
}
