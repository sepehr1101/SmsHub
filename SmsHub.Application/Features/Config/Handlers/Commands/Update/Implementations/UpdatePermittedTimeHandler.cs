using AutoMapper;
using SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Update.Implementations
{
    public class UpdatePermittedTimeHandler: IUpdatePermittedTimeHandler
    {
        private readonly IMapper _mapper;
        private readonly IPermittedTimeQueryService _permittedTimeQueryService;
        public UpdatePermittedTimeHandler(IMapper mapper, IPermittedTimeQueryService permittedTimeQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _permittedTimeQueryService = permittedTimeQueryService;
            _permittedTimeQueryService.NotNull(nameof(permittedTimeQueryService));
        }
        public async Task Handle(UpdatePermittedTimeDto updatePermittedTimeDto, CancellationToken cancellationToken)
        {
            var permittedTime = await _permittedTimeQueryService.Get(updatePermittedTimeDto.Id);
            _mapper.Map(updatePermittedTimeDto, permittedTime);
        }
    }
}
