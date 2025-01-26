using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;
using FluentValidation;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Create.Implementations
{
    public class DeepLogCreateHandler : IDeepLogCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IDeepLogCommandService _deepLogCommandService;
        private readonly IValidator<CreateDeepLogDto> _validator;
        public DeepLogCreateHandler(
            IMapper mapper,
            IDeepLogCommandService deepLogCommandService,
            IValidator<CreateDeepLogDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _deepLogCommandService = deepLogCommandService;
            _deepLogCommandService.NotNull(nameof(_deepLogCommandService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateDeepLogDto createDeepLogDto, CancellationToken cancellationToken)
        {
            await CheckValidator(createDeepLogDto, cancellationToken);

            var deepLog = _mapper.Map<Entities.DeepLog>(createDeepLogDto);
            await _deepLogCommandService.Add(deepLog);
        }
        private async Task CheckValidator(CreateDeepLogDto createDeepLogDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(createDeepLogDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }
        }

    }
}
