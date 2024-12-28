namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands
{
    public record UpdateContactNumberDto  
    {
        public int Id { get; init; }
        public string Number { get; init; } = null!;
        public int ContactCategoryId { get; init; }
        public int ContactNumberCategoryId { get; init; }
    }
}
