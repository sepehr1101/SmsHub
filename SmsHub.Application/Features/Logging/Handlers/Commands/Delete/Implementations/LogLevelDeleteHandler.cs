using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Logging.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;
using SmsHub.Persistence.Features.Logging.Queries.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Delete.Implementations
{
    public class LogLevelDeleteHandler : ILogLevelDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly ILogLevelCommandService _logLevelCommandService;
        private readonly ILogLevelQueryService _logLevelQueryService;
        private readonly IValidator<DeleteLogLevelDto> _validator;
        public LogLevelDeleteHandler(
            IMapper mapper,
            ILogLevelCommandService logLevelCommandService,
            ILogLevelQueryService logLevelQueryService,
            IValidator<DeleteLogLevelDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _logLevelCommandService = logLevelCommandService;
            _logLevelCommandService.NotNull(nameof(logLevelQueryService));

            _logLevelQueryService = logLevelQueryService;
            _logLevelQueryService.NotNull(nameof(logLevelQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(DeleteLogLevelDto deleteLogLevelDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(deleteLogLevelDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var logLevel = await _logLevelQueryService.Get(deleteLogLevelDto.Id);
            _logLevelCommandService.Delete(logLevel);
        }
    }
}
