using AutoMapper;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Logging.Queries.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Queries.Implementations
{
    public class InformativeLogGetListHandler : IInformativeLogGetListHandler
    {
        private readonly IMapper _mapper;
        private readonly IInformativeLogQueryService _informativeLogQueryService;
        public InformativeLogGetListHandler(
            IMapper mapper,
            IInformativeLogQueryService informativeLogQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));
            _informativeLogQueryService = informativeLogQueryService;
            _informativeLogQueryService.NotNull(nameof(informativeLogQueryService));
        }
        public async Task<ICollection<GetInforamtaiveLogDto>> Handle()
        {
            var informativeLogs = await _informativeLogQueryService.Get();
            return _mapper.Map<ICollection<GetInforamtaiveLogDto>>(informativeLogs);
        }
    }
}
