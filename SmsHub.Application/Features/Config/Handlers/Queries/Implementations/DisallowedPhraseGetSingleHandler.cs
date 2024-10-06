using AutoMapper;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Persistence.Features.Config.Queries.Contracts;

namespace SmsHub.Application.Features.Config.Handlers.Queries.Implementations
{
    public class DisallowedPhraseGetSingleHandler: IDisallowedPhraseGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly IDisallowedPhraseQueryService _disallowedPhraseQueryService;
        public DisallowedPhraseGetSingleHandler(IMapper mapper, IDisallowedPhraseQueryService disallowedPhraseQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _disallowedPhraseQueryService = disallowedPhraseQueryService;
            _disallowedPhraseQueryService.NotNull(nameof(disallowedPhraseQueryService));
        }
        public async Task<GetDisallowedPhraseDto> Handle(int Id)
        {
           var disallowedPhrase= await _disallowedPhraseQueryService.Get(Id);
        return _mapper.Map<GetDisallowedPhraseDto>(disallowedPhrase);
        }
    }
}
