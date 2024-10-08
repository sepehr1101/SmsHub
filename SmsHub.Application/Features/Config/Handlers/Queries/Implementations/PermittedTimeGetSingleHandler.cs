using AutoMapper;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Queries.Implementations
{
    public class PermittedTimeGetSingleHandler : IPermittedTimeGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly IPermittedTimeQueryService _permittedTimeQueryService;
        public PermittedTimeGetSingleHandler(IMapper mapper, IPermittedTimeQueryService permittedTimeQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _permittedTimeQueryService = permittedTimeQueryService;
            _permittedTimeQueryService.NotNull(nameof(permittedTimeQueryService));
        }
        public async Task<GetPermittedTimeDto> Handle(int Id)
        {
            var permittedTime = await _permittedTimeQueryService.Get(Id);
            return _mapper.Map<GetPermittedTimeDto>(permittedTime);
        }
    }
}
