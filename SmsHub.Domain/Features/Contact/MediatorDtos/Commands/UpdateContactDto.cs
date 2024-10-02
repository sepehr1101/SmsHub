namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands
{
    public record UpdateContactDto
    {//todo: check Prop
        public int Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
