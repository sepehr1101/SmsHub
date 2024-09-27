namespace SmsHub.Persistence.Features.Contact.Queries.Contracts
{
    public interface IContactNumberQueryService
    {
        Task<ICollection<Domain.Features.Entities.ContactNumber>> Get();
        Task<Domain.Features.Entities.ContactNumber> Get(int id);
    }
}
