namespace SmsHub.Persistence.Features.Contact.Commands.Contracts
{
    public interface IContactNumberCategoryCommandService
    {
        Task Add(Domain.Features.Entities.ContactNumberCategory contactNumberCategory);
        Task Add(ICollection<Domain.Features.Entities.ContactNumberCategory> contactNumberCategories);
    }
}
