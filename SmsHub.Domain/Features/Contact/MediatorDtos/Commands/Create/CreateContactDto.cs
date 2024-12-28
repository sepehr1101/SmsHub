namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create
{
    public record CreateContactDto  
    {
        public string Title { get; init; } = null!;

    }
}
