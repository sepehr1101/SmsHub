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

        public async Task Handle(CreateDeepLogDto request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var deepLog = _mapper.Map<Entities.DeepLog>(request);
            await _deepLogCommandService.Add(deepLog);
        }
    }
}
