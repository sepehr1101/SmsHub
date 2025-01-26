using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Config.Commands.Contracts;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts;
using FluentValidation;
using SmsHub.Application.Exceptions;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Create.Implementations
{
    public class DisallowedPhraseCreateHandler : IDisallowedPhraseCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IDisallowedPhraseCommandService _disallowedPhraseCommandService;
        private readonly IValidator<CreateDisallowedPhraseDto> _validator;
        public DisallowedPhraseCreateHandler(
            IDisallowedPhraseCommandService disallowedPhraseCommandService,
            IMapper mapper,
            IValidator<CreateDisallowedPhraseDto> validator)
        {
            _disallowedPhraseCommandService = disallowedPhraseCommandService;
            _disallowedPhraseCommandService.NotNull(nameof(_disallowedPhraseCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateDisallowedPhraseDto createDisallowedPhraseDto, CancellationToken cancellationToken)
        {
            await CheckValidator(createDisallowedPhraseDto, cancellationToken);

            var disallowedPhrase = _mapper.Map<Entities.DisallowedPhrase>(createDisallowedPhraseDto);
            await _disallowedPhraseCommandService.Add(disallowedPhrase);
        }
        private async Task CheckValidator(CreateDisallowedPhraseDto createDisallowedPhraseDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(createDisallowedPhraseDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }

    }
}
