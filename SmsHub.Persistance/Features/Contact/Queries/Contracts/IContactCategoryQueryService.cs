namespace SmsHub.Persistence.Features.Contact.Queries.Contracts
{
    public interface IContactCategoryQueryService
    {
        Task<ICollection<Domain.Features.Entities.ContactCategory>> Get();
        Task<Domain.Features.Entities.ContactCategory> Get(int id);
    }
}
