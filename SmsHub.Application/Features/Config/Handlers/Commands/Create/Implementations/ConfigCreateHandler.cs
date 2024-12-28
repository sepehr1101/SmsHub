using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Features.Config.Commands.Contracts;
using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Create.Implementations
{
    public class ConfigCreateHandler : IConfigCreateHandler
    {
        private readonly IConfigCommandService _configCommandService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateConfigDto> _validator;
        public ConfigCreateHandler(
            IConfigCommandService configCommandService,
            IMapper mapper,
            IValidator<CreateConfigDto> validator)
        {
            _configCommandService = configCommandService;
            _configCommandService.NotNull(nameof(_configCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _validator= validator;
            _validator.NotNull(nameof(_validator)); 
        }
        public async Task Handle(CreateConfigDto request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var config = _mapper.Map<Entities.Config>(request);
            await _configCommandService.Add(config);
        }
    }
}
