namespace SmsHub.Persistence.Features.Config.Queries.Contracts
{
    public interface IDisallowedPhraseQueryService
    {
        Task<ICollection<Domain.Features.Entities.DisallowedPhrase>> Get();
        Task<Domain.Features.Entities.DisallowedPhrase> Get(int id);
    }
}
