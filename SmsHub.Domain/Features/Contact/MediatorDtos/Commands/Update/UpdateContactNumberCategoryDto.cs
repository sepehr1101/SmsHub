namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Update
{
    public record UpdateContactNumberCategoryDto
    {//todo: check Prop
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Css { get; set; } = null!;
    }
}
