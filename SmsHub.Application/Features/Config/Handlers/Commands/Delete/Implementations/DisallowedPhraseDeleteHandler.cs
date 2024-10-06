using AutoMapper;
using SmsHub.Application.Features.Config.Handlers.Commands.Delete.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Delete;
using SmsHub.Persistence.Features.Config.Commands.Contracts;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Commands.Delete.Implementations
{
    public class DisallowedPhraseDeleteHandler: IDisallowedPhraseDeleteHandler
    {
        private readonly IMapper _mapper;
        private readonly IDisallowedPhraseCommandService _disallowedPhraseCommandService;
        private readonly IDisallowedPhraseQueryService _disallowedPhraseQueryService;
        public DisallowedPhraseDeleteHandler(
            IMapper mapper, IDisallowedPhraseCommandService disallowedPhraseCommandService, IDisallowedPhraseQueryService disallowedPhraseQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _disallowedPhraseCommandService = disallowedPhraseCommandService;
            _disallowedPhraseCommandService.NotNull(nameof(disallowedPhraseQueryService));

            _disallowedPhraseQueryService = disallowedPhraseQueryService;
            _disallowedPhraseQueryService.NotNull(nameof(disallowedPhraseQueryService));
        }
        public async Task Handle(DeleteDisallowedPhraseDto deleteDisallowedPhraseDto, CancellationToken cancellationToken)
        {
            var disallowedPhrase=await _disallowedPhraseQueryService.Get(deleteDisallowedPhraseDto.Id);
            _disallowedPhraseCommandService.Delete(disallowedPhrase);
        }
    }
}
