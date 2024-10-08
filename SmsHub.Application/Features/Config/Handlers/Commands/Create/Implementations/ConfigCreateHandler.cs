using AutoMapper;
using MediatR;
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
        public ConfigCreateHandler(IConfigCommandService configCommandService, IMapper mapper)
        {
            _configCommandService = configCommandService;
            _configCommandService.NotNull(nameof(_configCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));
        }
        public async Task Handle(CreateConfigDto request, CancellationToken cancellationToken)
        {
            var config = _mapper.Map<Entities.Config>(request);
            await _configCommandService.Add(config);
        }
    }
}
