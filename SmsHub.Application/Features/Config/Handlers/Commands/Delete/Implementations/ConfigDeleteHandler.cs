using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Config.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Config.Commands.Contracts;
using SmsHub.Persistence.Features.Config.Queries.Contracts;
using System.Threading;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Delete.Implementations
{
    public class ConfigDeleteHandler : IConfigDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IConfigCommandService _configCommandService;
        private readonly IConfigQueryService _configQueryService;
        private readonly IValidator<DeleteConfigDto> _validator;
        public ConfigDeleteHandler(
            IMapper mapper,
            IConfigCommandService configCommandService,
            IConfigQueryService configQueryService,
            IValidator<DeleteConfigDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _configCommandService = configCommandService;
            _configCommandService.NotNull(nameof(configCommandService));

            _configQueryService = configQueryService;
            _configQueryService.NotNull(nameof(configQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(DeleteConfigDto deleteConfigDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(deleteConfigDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var config = await _configQueryService.Get(deleteConfigDto.Id);
            _configCommandService.Delete(config);
        }
    }
}
