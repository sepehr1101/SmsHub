using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Logging.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Logging.Queries.Contracts;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Update.Implementations
{
    public class DeepLogUpdateHandler : IDeepLogUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IDeepLogQueryService _deepLogQueryService;
        private readonly IValidator<UpdateDeepLogDto> _validator;
        public DeepLogUpdateHandler(IMapper mapper, IDeepLogQueryService deepLogQueryService, IValidator<UpdateDeepLogDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _deepLogQueryService = deepLogQueryService;
            _deepLogQueryService.NotNull(nameof(deepLogQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdateDeepLogDto updateDeepLogDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateDeepLogDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var deepLog = await _deepLogQueryService.Get(updateDeepLogDto.Id);
            _mapper.Map(updateDeepLogDto, deepLog);
        }
    }
}
