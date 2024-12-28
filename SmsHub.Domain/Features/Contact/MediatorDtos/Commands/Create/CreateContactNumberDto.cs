namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create
{
    public record CreateContactNumberDto  
    {
        public string Number { get; init; } = null!;
        public int ContactCategoryId { get; init; }
        public int ContactNumberCategoryId { get; init; }
    }
}
