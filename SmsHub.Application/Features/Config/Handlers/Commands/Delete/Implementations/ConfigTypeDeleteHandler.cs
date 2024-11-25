using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Config.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Config.Commands.Contracts;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Delete.Implementations
{
    public class ConfigTypeDeleteHandler : IConfigTypeDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IConfigTypeCommandService _configTypeCommandService;
        private readonly IConfigTypeQueryService _configTypeQueryService;
        private readonly IValidator<DeleteConfigTypDto> _validator;
        public ConfigTypeDeleteHandler(
            IMapper mapper,
            IConfigTypeCommandService configTypeCommandService,
            IConfigTypeQueryService configTypeQueryService,
            IValidator<DeleteConfigTypDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _configTypeCommandService = configTypeCommandService;
            _configTypeCommandService.NotNull(nameof(configTypeQueryService));

            _configTypeQueryService = configTypeQueryService;
            _configTypeQueryService.NotNull(nameof(configTypeQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(DeleteConfigTypDto deleteConfigTypDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(deleteConfigTypDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var configType = await _configTypeQueryService.Get(deleteConfigTypDto.Id);
            _configTypeCommandService.Delete(configType);
        }
    }
}
