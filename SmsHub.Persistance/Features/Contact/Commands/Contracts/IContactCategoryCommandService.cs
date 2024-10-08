using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Contact.Commands.Contracts
{
    public interface IContactCategoryCommandService
    {
        Task Add(ContactCategory contactCategory);
        Task Add(ICollection<ContactCategory> contactCategories);
        void Delete(ContactCategory contactCategory);
    }
}
