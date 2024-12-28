using AutoMapper;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Logging.Queries.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Queries.Implementations
{
    public class InformativeLogGetSingleHandler: IInformativeLogGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly IInformativeLogQueryService _informativeLogQueryService;
        public InformativeLogGetSingleHandler(
            IMapper mapper, 
            IInformativeLogQueryService informativeLogQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));
            _informativeLogQueryService = informativeLogQueryService;
            _informativeLogQueryService.NotNull(nameof(informativeLogQueryService));
        }
        public async Task<GetInforamtaiveLogDto> Handle(LongId Id)
        {
            var informativeLog = await _informativeLogQueryService.Get(Id.Id);
            return _mapper.Map<GetInforamtaiveLogDto>(informativeLog);
        }
    }
}
