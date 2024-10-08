using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Create.Implementations
{
    public class LogLevelCreateHandler : ILogLevelCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly ILogLevelCommandService _logLevelCommandService;
        public LogLevelCreateHandler(IMapper mapper, ILogLevelCommandService logLevelCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _logLevelCommandService = logLevelCommandService;
            _logLevelCommandService.NotNull(nameof(_logLevelCommandService));
        }

        public async Task Handle(CreateLogLevelDto request, CancellationToken cancellationToken)
        {
            var logLevel = _mapper.Map<Entities.LogLevel>(request);
            await _logLevelCommandService.Add(logLevel);
        }
    }
}
