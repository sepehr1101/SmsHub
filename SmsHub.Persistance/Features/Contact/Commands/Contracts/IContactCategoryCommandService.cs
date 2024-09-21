namespace SmsHub.Persistence.Features.Contact.Commands.Contracts
{
    public interface IContactCategoryCommandService
    {
        Task Add(Domain.Features.Entities.ContactCategory contactCategory);
        Task Add(ICollection<Domain.Features.Entities.ContactCategory> contactCategories);
    }
}
