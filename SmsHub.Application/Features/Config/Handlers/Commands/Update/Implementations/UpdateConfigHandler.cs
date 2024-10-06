using AutoMapper;
using SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Update.Implementations
{
    public class UpdateConfigHandler: IUpdateConfigHandler
    {
        private readonly IMapper _mapper;
        private readonly IConfigQueryService _configQueryService;
        public UpdateConfigHandler(IMapper mapper, IConfigQueryService configQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _configQueryService = configQueryService;
            _configQueryService.NotNull(nameof(configQueryService));
        }
        public async Task Handle(UpdateConfigDto updateConfigDto, CancellationToken cancellationToken)
        {
            var config=await _configQueryService.Get(updateConfigDto.Id);
            _mapper.Map(updateConfigDto, config);
        }
    }
}
