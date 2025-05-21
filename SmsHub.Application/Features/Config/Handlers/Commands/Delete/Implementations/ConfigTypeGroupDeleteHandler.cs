using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Config.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Config.Commands.Contracts;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Delete.Implementations
{
    public class ConfigTypeGroupDeleteHandler: IConfigTypeGroupDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IConfigTypeGroupCommandService _configTypeGroupCommandService;
        private readonly IConfigTypeGroupQueryService _configTypeGroupQueryService;
        private readonly IConfigQueryService _configQueryService;
        private readonly IConfigCommandService _configCommandService;
        public ConfigTypeGroupDeleteHandler(
            IMapper mapper,
            IConfigTypeGroupCommandService configTypeGroupCommandService,
            IConfigTypeGroupQueryService configTypeGroupQueryService,
            IConfigQueryService configQueryService,
            IConfigCommandService configCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _configTypeGroupCommandService = configTypeGroupCommandService;
            _configTypeGroupCommandService.NotNull(nameof(configTypeGroupCommandService));

            _configTypeGroupQueryService = configTypeGroupQueryService;
            _configTypeGroupQueryService.NotNull(nameof(configTypeGroupQueryService));

            _configQueryService = configQueryService;
            _configQueryService.NotNull(nameof( configQueryService));

            _configCommandService = configCommandService;
            _configCommandService.NotNull(nameof( configCommandService));
        }
        public async Task Handle(DeleteConfigTypeGroupDto deleteConfigTypeGroupDto, CancellationToken cancellationToken)
        {
            var configTypeGroup = await _configTypeGroupQueryService.Get(deleteConfigTypeGroupDto.Id);
            ICollection<SmsHub.Domain.Features.Entities.Config> configs = await _configQueryService.GetByConfigTypeGroupId(deleteConfigTypeGroupDto.Id);
            if (configs != null)
            {
                _configCommandService.Delete(configs);
            }
            _configTypeGroupCommandService.Delete(configTypeGroup);
        }
    }
}
