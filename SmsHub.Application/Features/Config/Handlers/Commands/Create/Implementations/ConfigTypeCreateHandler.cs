using AutoMapper;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Common.Extensions;
using MediatR;
using SmsHub.Persistence.Features.Config.Commands.Contracts;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Create.Implementations
{
    public class ConfigTypeCreateHandler:IConfigTypeCreateHandler
    {
        private readonly IConfigTypeCommandService _configTypeCommandService;
        private readonly IMapper _mapper;
        public ConfigTypeCreateHandler(IConfigTypeCommandService configCommandService, IMapper mapper)
        {
            _configTypeCommandService = configCommandService;
            _configTypeCommandService.NotNull(nameof(_configTypeCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));
        }
        public async Task Handle(CreateConfigTypeDto request, CancellationToken cancellationToken)
        {
            var configType = _mapper.Map<Entities.ConfigType>(request);
            await _configTypeCommandService.Add(configType);
        }
    }
}
