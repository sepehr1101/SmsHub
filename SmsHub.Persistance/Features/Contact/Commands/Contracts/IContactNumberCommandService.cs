using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Contact.Commands.Contracts
{
    public interface IContactNumberCommandService
    {
        Task Add(ContactNumber  contactNumber);
        Task Add(ICollection<ContactNumber> contactNumbers);
        void Delete(ContactNumber contactNumber);
    }
}
