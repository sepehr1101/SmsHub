using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Contact.Commands.Contracts
{
    public interface IContactNumberCategoryCommandService
    {
        Task Add(ContactNumberCategory contactNumberCategory);
        Task Add(ICollection<ContactNumberCategory> contactNumberCategories);
        void Delete(ContactNumberCategory contactNumberCategory);
    }
}
