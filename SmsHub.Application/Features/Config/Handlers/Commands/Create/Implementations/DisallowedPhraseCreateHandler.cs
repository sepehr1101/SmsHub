using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Config.Commands.Contracts;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Config.Handlers.Commands.Create.Contracts;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Create.Implementations
{
    public class DisallowedPhraseCreateHandler : IDisallowedPhraseCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IDisallowedPhraseCommandService _disallowedPhraseCommandService;
        private readonly IValidator<CreateDisallowedPhraseDto> _validator;
        public DisallowedPhraseCreateHandler(IMapper mapper, IDisallowedPhraseCommandService disallowedPhraseCommandService, IValidator<CreateDisallowedPhraseDto> validator)
        {
            _disallowedPhraseCommandService = disallowedPhraseCommandService;
            _disallowedPhraseCommandService.NotNull(nameof(_disallowedPhraseCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateDisallowedPhraseDto request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var disallowedPhrase = _mapper.Map<Entities.DisallowedPhrase>(request);
            await _disallowedPhraseCommandService.Add(disallowedPhrase);
        }
    }
}
