using AutoMapper;
using MediatR;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Config.Commands.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Create
{
    public class CreateDisallowedPhraseCommandHandler:IRequestHandler<CreateDisallowedPhraseDto>
    {
        private readonly IMapper _mapper;
        private readonly IDisallowedPhraseCommandService _disallowedPhraseCommandService;
        public CreateDisallowedPhraseCommandHandler(IMapper mapper, IDisallowedPhraseCommandService disallowedPhraseCommandService)
        {
           _disallowedPhraseCommandService= disallowedPhraseCommandService;
            _disallowedPhraseCommandService.NotNull(nameof(_disallowedPhraseCommandService));

            _mapper= mapper;
            _mapper.NotNull(nameof(_mapper));
        }

        public async Task Handle(CreateDisallowedPhraseDto request, CancellationToken cancellationToken)
        {
            var disallowedPhrase = _mapper.Map<Entities.DisallowedPhrase>(request);
            await _disallowedPhraseCommandService.Add(disallowedPhrase);
        }
    }
}
