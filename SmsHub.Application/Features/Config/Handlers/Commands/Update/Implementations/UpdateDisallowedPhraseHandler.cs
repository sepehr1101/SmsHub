using AutoMapper;
using SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Update;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Update.Implementations
{
    public class UpdateDisallowedPhraseHandler: IUpdateDisallowedPhraseHandler
    {
        private readonly IMapper _mapper;
        private readonly IDisallowedPhraseQueryService _disallowedPhraseQueryService;
        public UpdateDisallowedPhraseHandler(IMapper mapper, IDisallowedPhraseQueryService disallowedPhraseQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _disallowedPhraseQueryService = disallowedPhraseQueryService;
            _disallowedPhraseQueryService.NotNull(nameof(disallowedPhraseQueryService));
        }
        public async Task Handle(UpdateDisallowedPhraseDto updateDisallowedPhraseDto, CancellationToken cancellationToken)
        {
            var disallowedPhrase = await _disallowedPhraseQueryService.Get(updateDisallowedPhraseDto.Id);
            _mapper.Map(updateDisallowedPhraseDto,disallowedPhrase);
        }
    }
}
