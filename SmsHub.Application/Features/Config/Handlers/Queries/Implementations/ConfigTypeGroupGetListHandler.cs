using AutoMapper;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Queries.Implementations
{
    public class ConfigTypeGroupGetListHandler: IConfigTypeGroupGetListHandler
    {
        private readonly IMapper _mapper;
        private readonly IConfigTypeGroupQueryService _configTypeGroupQueryService;
        public ConfigTypeGroupGetListHandler(IMapper mapper, IConfigTypeGroupQueryService configTypeGroupQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _configTypeGroupQueryService = configTypeGroupQueryService;
            _configTypeGroupQueryService.NotNull(nameof(configTypeGroupQueryService));
        }
        public async Task<ICollection<GetConfigTypeGroupDto>> Handle()
        {
           var configTypeGroups= await _configTypeGroupQueryService.Get();
            return _mapper.Map<ICollection<GetConfigTypeGroupDto>>(configTypeGroups);
        }
    }
}
