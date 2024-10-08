using AutoMapper;
using SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos;
using SmsHub.Persistence.Features.Config.Queries.Contracts;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Update.Implementations
{
    public class ConfigTypeUpdateHandler: IConfigTypeUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IConfigTypeQueryService _configTypeQueryService;
        public ConfigTypeUpdateHandler(IMapper mapper, IConfigTypeQueryService configTypeQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _configTypeQueryService = configTypeQueryService;
            _configTypeQueryService.NotNull(nameof(configTypeQueryService));
        }
        public async Task Handle(UpdateConfigTypeDto updateConfigTypeDto, CancellationToken cancellationToken)
        {
            var configType=await _configTypeQueryService.Get(updateConfigTypeDto.Id);
            _mapper.Map(updateConfigTypeDto, configType);
        }
    }
}
