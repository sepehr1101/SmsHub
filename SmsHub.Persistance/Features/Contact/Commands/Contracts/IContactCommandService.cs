namespace SmsHub.Persistence.Features.Contact.Commands.Contracts
{
    public interface IContactCommandService
    {
        Task Add(Domain.Features.Entities.Contact contact);
        Task Add(ICollection<Domain.Features.Entities.Contact> contacts);
    }
}
