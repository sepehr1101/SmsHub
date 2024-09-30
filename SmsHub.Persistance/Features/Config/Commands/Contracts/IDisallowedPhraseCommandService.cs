using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Config.Commands.Contracts
{
    public interface IDisallowedPhraseCommandService
    {
        Task Add(DisallowedPhrase disallowedPhrase);
        Task Add(ICollection<DisallowedPhrase> disallowedPhrases);
        void Delete(DisallowedPhrase disallowedPhrase);
    }
}
