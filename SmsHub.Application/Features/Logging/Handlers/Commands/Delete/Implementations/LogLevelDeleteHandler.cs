using AutoMapper;
using SmsHub.Application.Features.Logging.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;
using SmsHub.Persistence.Features.Logging.Queries.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Delete.Implementations
{
    public class LogLevelDeleteHandler: ILogLevelDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly ILogLevelCommandService _logLevelCommandService;
        private readonly ILogLevelQueryService _logLevelQueryService;
        public LogLevelDeleteHandler(
            IMapper mapper, 
            ILogLevelCommandService logLevelCommandService, 
            ILogLevelQueryService logLevelQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));
            
            _logLevelCommandService = logLevelCommandService;
            _logLevelCommandService.NotNull(nameof(logLevelQueryService));

            _logLevelQueryService = logLevelQueryService;
            _logLevelQueryService.NotNull(nameof(logLevelQueryService));
        }
        public async Task Handle(DeleteLogLevelDto deleteLogLevelDto, CancellationToken cancellationToken)
        {
            var logLevel=await _logLevelQueryService.Get(deleteLogLevelDto.Id);
            _logLevelCommandService.Delete(logLevel);
        }
    }
}
