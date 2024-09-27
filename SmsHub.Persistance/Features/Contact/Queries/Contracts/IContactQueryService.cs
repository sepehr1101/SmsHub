namespace SmsHub.Persistence.Features.Contact.Queries.Contracts
{
    public interface IContactQueryService
    {
        Task<ICollection<Domain.Features.Entities.Contact>> Get();
        Task<Domain.Features.Entities.Contact> Get(int id);
    }
}
