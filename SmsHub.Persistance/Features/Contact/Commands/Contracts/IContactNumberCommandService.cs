namespace SmsHub.Persistence.Features.Contact.Commands.Contracts
{
    public interface IContactNumberCommandService
    {
        Task Add(Domain.Features.Entities.ContactNumber  contactNumber);
        Task Add(ICollection<Domain.Features.Entities.ContactNumber> contactNumbers);
    }
}
