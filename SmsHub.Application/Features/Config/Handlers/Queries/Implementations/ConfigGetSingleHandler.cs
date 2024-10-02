using AutoMapper;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Queries.Implementations
{
    public class ConfigGetSingleHandler : IConfigGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly IConfigQueryService _configQueryService;
        public ConfigGetSingleHandler(IMapper mapper, IConfigQueryService configQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _configQueryService = configQueryService;
            _configQueryService.NotNull(nameof(configQueryService));
        }
        public async Task<GetConfigDto> Handle(int Id)
        {
            var config = await _configQueryService.Get(Id);
            return _mapper.Map<GetConfigDto>(config);
        }
    }
}
