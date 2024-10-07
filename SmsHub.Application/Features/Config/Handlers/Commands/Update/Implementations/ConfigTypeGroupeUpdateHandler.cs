using AutoMapper;
using SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Update.Implementations
{
    public class ConfigTypeGroupeUpdateHandler: IConfigTypeGroupeUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IConfigTypeGroupQueryService _configTypeGroupQueryService;
        public ConfigTypeGroupeUpdateHandler(IMapper mapper, IConfigTypeGroupQueryService configTypeGroupQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _configTypeGroupQueryService = configTypeGroupQueryService;
           _configTypeGroupQueryService.NotNull(nameof(configTypeGroupQueryService));
        }
        public async Task Handle(UpdateConfigTypeGroupDto updateConfigTypeGroupDto, CancellationToken cancellationToken)
        {
            var configTypeGroup=await _configTypeGroupQueryService.Get(updateConfigTypeGroupDto.Id);
            _mapper.Map(updateConfigTypeGroupDto, configTypeGroup);
        }
    }
}
