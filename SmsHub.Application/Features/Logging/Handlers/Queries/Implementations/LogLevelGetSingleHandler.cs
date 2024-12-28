using AutoMapper;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Logging.Queries.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Queries.Implementations
{
    public class LogLevelGetSingleHandler: ILogLevelGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly ILogLevelQueryService _logLevelQueryService;
        public LogLevelGetSingleHandler(
            IMapper mapper,
            ILogLevelQueryService logLevelQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _logLevelQueryService = logLevelQueryService;
            _logLevelQueryService.NotNull(nameof(logLevelQueryService));
        }
        public async Task<GetLogLevelDto> Handle(IntId Id)
        {
            var logLevels = await _logLevelQueryService.Get(Id.Id);
            return _mapper.Map<GetLogLevelDto>(logLevels);
        }
    }
}
