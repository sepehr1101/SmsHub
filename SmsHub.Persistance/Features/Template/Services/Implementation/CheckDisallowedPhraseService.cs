using SmsHub.Common.Extensions;
using SmsHub.Persistence.Features.Config.Queries.Contracts;
using SmsHub.Persistence.Features.Template.Services.Contracts;

namespace SmsHub.Persistence.Features.Template.Services.Implementation
{
    public class CheckDisallowedPhraseService : ICheckDisallowedPhraseService
    {
        private readonly IDisallowedPhraseQueryService _disallowedPhraseQuery;
        public CheckDisallowedPhraseService(IDisallowedPhraseQueryService disallowedPhraseQuery)
        {
            _disallowedPhraseQuery = disallowedPhraseQuery;
            _disallowedPhraseQuery.NotNull(nameof(disallowedPhraseQuery));
        }
        public async Task Check(string input)
        {
            var disallowedPhrase = await _disallowedPhraseQuery.Get();
            foreach (var item in disallowedPhrase)
            {
                if (input.Contains(item.Phrase))
                    throw new InvalidDataException();
            }
        }
    }
}
