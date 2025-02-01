using AutoMapper;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Queries.Implementations
{
    public class ConfigTypeGroupGetSingleHandler : IConfigTypeGroupGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly IConfigTypeGroupQueryService _configTypeGroupQueryService;
        public ConfigTypeGroupGetSingleHandler(
            IMapper mapper,
            IConfigTypeGroupQueryService configTypeGroupQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _configTypeGroupQueryService = configTypeGroupQueryService;
            _configTypeGroupQueryService.NotNull(nameof(configTypeGroupQueryService));
        }
        public async Task<GetConfigTypeGroupDto> Handle(IntId Id)
        {
            var configTypeGroup = await _configTypeGroupQueryService.Get(Id.Id);
            return _mapper.Map<GetConfigTypeGroupDto>(configTypeGroup);
        }
    }
}
