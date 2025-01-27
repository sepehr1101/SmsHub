using AutoMapper;
using FluentValidation;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Update.Implementations
{
    public class DisallowedPhraseUpdateHandler : IDisallowedPhraseUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IDisallowedPhraseQueryService _disallowedPhraseQueryService;
        private readonly IValidator<UpdateDisallowedPhraseDto> _validator;
        public DisallowedPhraseUpdateHandler(
            IMapper mapper,
            IDisallowedPhraseQueryService disallowedPhraseQueryService,
            IValidator<UpdateDisallowedPhraseDto> validtor)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _disallowedPhraseQueryService = disallowedPhraseQueryService;
            _disallowedPhraseQueryService.NotNull(nameof(disallowedPhraseQueryService));

            _validator = validtor;
            _validator.NotNull(nameof(validtor));
        }
        public async Task Handle(UpdateDisallowedPhraseDto updateDisallowedPhraseDto, CancellationToken cancellationToken)
        {
            await CheckValidator(updateDisallowedPhraseDto, cancellationToken);

            var disallowedPhrase = await _disallowedPhraseQueryService.Get(updateDisallowedPhraseDto.Id);
            _mapper.Map(updateDisallowedPhraseDto, disallowedPhrase);
        }

        private async Task CheckValidator(UpdateDisallowedPhraseDto updateDisallowedPhraseDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateDisallowedPhraseDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }
    }
}