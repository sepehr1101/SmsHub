namespace SmsHub.Persistence.Features.Config.Commands.Create.Contracts
{
    public interface IDisallowedPhraseCommandService
    {
        Task Add(Domain.Features.Entities.DisallowedPhrase disallowedPhrase);
        Task Add(ICollection<Domain.Features.Entities.DisallowedPhrase> disallowedPhrases);
    }
}
