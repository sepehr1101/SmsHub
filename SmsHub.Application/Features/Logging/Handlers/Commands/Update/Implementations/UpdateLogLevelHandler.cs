using AutoMapper;
using SmsHub.Application.Features.Logging.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Logging.Queries.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Update.Implementations
{
    public class UpdateLogLevelHandler: IUpdateLogLevelHandler
    {
        private readonly IMapper _mapper;
        private readonly ILogLevelQueryService _logLevelQueryService;
        public UpdateLogLevelHandler(IMapper mapper, ILogLevelQueryService logLevelQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _logLevelQueryService = logLevelQueryService;
            _logLevelQueryService.NotNull(nameof(logLevelQueryService));
        }
        public async Task Handle(UpdateLogLevelDto updateLogLevelDto, CancellationToken cancellationToken)
        {
            var logLevel = await _logLevelQueryService.Get(updateLogLevelDto.Id);
            _mapper.Map(updateLogLevelDto, logLevel);
        }
    }
}
