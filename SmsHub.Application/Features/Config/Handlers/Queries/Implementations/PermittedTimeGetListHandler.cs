using AutoMapper;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Queries.Implementations
{
    public class PermittedTimeGetListHandler : IPermittedTimeGetListHandler
    {
        private readonly IMapper _mapper;
        private readonly IPermittedTimeQueryService _permittedTimeQueryService;
        public PermittedTimeGetListHandler(
            IMapper mapper,
            IPermittedTimeQueryService permittedTimeQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _permittedTimeQueryService = permittedTimeQueryService;
            _permittedTimeQueryService.NotNull(nameof(permittedTimeQueryService));
        }
        public async Task<ICollection<GetPermittedTimeDto>> Handle()
        {
            var permittedTimes = await _permittedTimeQueryService.Get();
            return _mapper.Map<ICollection<GetPermittedTimeDto>>(permittedTimes);
        }
    }
}
