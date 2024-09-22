using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities= SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Create
{
    public class CreateLogLevelCommandHandler : IRequestHandler<CreateLogLevelDto>
    {
        private readonly IMapper _mapper;
        private readonly ILogLevelCommandService _logLevelCommandService;
        public CreateLogLevelCommandHandler(IMapper mapper, ILogLevelCommandService logLevelCommandService)
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
