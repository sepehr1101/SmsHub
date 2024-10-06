using AutoMapper;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Logging.Queries.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Queries.Implementations
{
    public class DeepLogGetSingleHandler: IDeepLogGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly IDeepLogQueryService _deepLogQueryService;
        public DeepLogGetSingleHandler(IMapper mapper, IDeepLogQueryService deepLogQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _deepLogQueryService = deepLogQueryService;
            _deepLogQueryService.NotNull(nameof(deepLogQueryService));
        }
        public async Task<GetDeepLogDto> Handle(int Id)
        {
            var deepLog = await _deepLogQueryService.Get(Id);
            return _mapper.Map<GetDeepLogDto>(deepLog);
        }
    }
}
