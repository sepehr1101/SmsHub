using AutoMapper;
using SmsHub.Application.Features.Config.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Config.Commands.Contracts;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Delete.Implementations
{
    public class ConfigDeleteHandler: IConfigDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IConfigCommandService _configCommandService;
        private readonly IConfigQueryService _configQueryService;
        public ConfigDeleteHandler(
            IMapper mapper,
            IConfigCommandService configCommandService,
            IConfigQueryService configQueryService)
        {
            _mapper= mapper;
            _mapper.NotNull(nameof(mapper));

            _configCommandService= configCommandService;
            _configCommandService.NotNull(nameof(configCommandService));

            _configQueryService= configQueryService;
            _configQueryService.NotNull(nameof(configQueryService));
        }
        public async Task Handle(DeleteConfigDto deleteConfigDto, CancellationToken cancellationToken)
        {
            var config= await _configQueryService.Get(deleteConfigDto.Id);
            _configCommandService.Delete(config);
        }
    }
}
