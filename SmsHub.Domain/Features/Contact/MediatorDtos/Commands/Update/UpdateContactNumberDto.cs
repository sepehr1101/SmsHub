namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Update
{
    public record UpdateContactNumberDto
    {//todo: check Prop
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public int ContactCategoryId { get; set; }
        public int ContactNumberCategoryId { get; set; }
    }
}
