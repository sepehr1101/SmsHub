namespace SmsHub.Persistence.Features.Contact.Queries.Contracts
{
    public interface IContactNumberCategoryQueryService
    {
        Task<ICollection<Domain.Features.Entities.ContactNumberCategory>> Get();
        Task<Domain.Features.Entities.ContactNumberCategory> Get(int id);
    }
}
