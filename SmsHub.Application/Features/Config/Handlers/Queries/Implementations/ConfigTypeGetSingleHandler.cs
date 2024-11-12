using AutoMapper;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Queries.Implementations
{
    public class ConfigTypeGetSingleHandler: IConfigTypeGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly IConfigTypeQueryService _configTypeQueryService;
        public ConfigTypeGetSingleHandler(IMapper mapper, IConfigTypeQueryService configTypeQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _configTypeQueryService = configTypeQueryService;
            _configTypeQueryService.NotNull(nameof(configTypeQueryService));
        }
        public async Task<GetConfigTypeDto> Handle(ShortId Id)
        {
           var configType= await _configTypeQueryService.Get(Id.Id);
            return _mapper.Map<GetConfigTypeDto>(configType);
        }
    }
}
