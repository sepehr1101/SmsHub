using AutoMapper;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Logging.Queries.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Queries.Implementations
{
    public class LogLevelGetListHandler: ILogLevelGetListHandler
    {
        private readonly IMapper _mapper;
        private readonly ILogLevelQueryService _logLevelQueryService;
        public LogLevelGetListHandler(IMapper mapper, ILogLevelQueryService logLevelQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _logLevelQueryService = logLevelQueryService;
            _logLevelQueryService.NotNull(nameof(logLevelQueryService));
        }
        public async Task<ICollection<GetLogLevelDto>> Handle()
        {
            var logLevels = await _logLevelQueryService.Get();
            return _mapper.Map<ICollection<GetLogLevelDto>>(logLevels);
        }
    }
}
