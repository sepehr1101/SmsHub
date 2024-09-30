using Entities = SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Contact.Commands.Contracts
{
    public interface IContactCommandService
    {
        Task Add(Entities.Contact contact);
        Task Add(ICollection<Entities.Contact> contacts);
        void Delete(Entities.Contact contact);
    }
}
