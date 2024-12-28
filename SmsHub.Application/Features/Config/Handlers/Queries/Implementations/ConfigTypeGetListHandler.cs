using AutoMapper;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Queries.Implementations
{
    public class ConfigTypeGetListHandler: IConfigTypeGetListHandler
    {
        private readonly IMapper _mapper;
        private readonly IConfigTypeQueryService _configTypeQueryService;
        public ConfigTypeGetListHandler(
            IMapper mapper, 
            IConfigTypeQueryService configTypeQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

           _configTypeQueryService= configTypeQueryService;
            _configTypeQueryService.NotNull(nameof(configTypeQueryService));
        }
        public async Task<ICollection<GetConfigTypeDto>> Handle()
        {
          var configTypes=  await _configTypeQueryService.Get();
            return _mapper.Map<ICollection<GetConfigTypeDto>>(configTypes);
        }
    }
}
