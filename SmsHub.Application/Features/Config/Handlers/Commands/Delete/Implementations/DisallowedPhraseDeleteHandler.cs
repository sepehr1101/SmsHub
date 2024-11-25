using AutoMapper;
using FluentValidation;
using SmsHub.Application.Features.Config.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Config.Commands.Contracts;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Delete.Implementations
{
    public class DisallowedPhraseDeleteHandler : IDisallowedPhraseDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IDisallowedPhraseCommandService _disallowedPhraseCommandService;
        private readonly IDisallowedPhraseQueryService _disallowedPhraseQueryService;
        private readonly IValidator<DeleteDisallowedPhraseDto> _validator;
        public DisallowedPhraseDeleteHandler(
            IMapper mapper,
            IDisallowedPhraseCommandService disallowedPhraseCommandService,
            IDisallowedPhraseQueryService disallowedPhraseQueryService,
            IValidator<DeleteDisallowedPhraseDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _disallowedPhraseCommandService = disallowedPhraseCommandService;
            _disallowedPhraseCommandService.NotNull(nameof(disallowedPhraseQueryService));

            _disallowedPhraseQueryService = disallowedPhraseQueryService;
            _disallowedPhraseQueryService.NotNull(nameof(disallowedPhraseQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(DeleteDisallowedPhraseDto deleteDisallowedPhraseDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(deleteDisallowedPhraseDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var disallowedPhrase = await _disallowedPhraseQueryService.Get(deleteDisallowedPhraseDto.Id);
            _disallowedPhraseCommandService.Delete(disallowedPhrase);
        }
    }
}
