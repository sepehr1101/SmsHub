using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Logging.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Logging.Queries.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Update.Implementations
{
    public class LogLevelUpdateHandler : ILogLevelUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly ILogLevelQueryService _logLevelQueryService;
        private readonly IValidator<UpdateLogLevelDto> _validator;
        public LogLevelUpdateHandler(IMapper mapper, ILogLevelQueryService logLevelQueryService, IValidator<UpdateLogLevelDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _logLevelQueryService = logLevelQueryService;
            _logLevelQueryService.NotNull(nameof(logLevelQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdateLogLevelDto updateLogLevelDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateLogLevelDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var logLevel = await _logLevelQueryService.Get(updateLogLevelDto.Id);
            _mapper.Map(updateLogLevelDto, logLevel);
        }
    }
}
