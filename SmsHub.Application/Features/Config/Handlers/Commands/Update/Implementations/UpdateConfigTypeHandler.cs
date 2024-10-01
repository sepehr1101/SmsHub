using AutoMapper;
using SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Update.Implementations
{
    public class UpdateConfigTypeHandler: IUpdateConfigTypeHandler
    {
        private readonly IMapper _mapper;
        private readonly IConfigTypeQueryService _configTypeQueryService;
        public UpdateConfigTypeHandler(IMapper mapper, IConfigTypeQueryService configTypeQueryService)
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
