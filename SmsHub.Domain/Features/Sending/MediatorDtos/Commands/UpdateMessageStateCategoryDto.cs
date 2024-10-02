namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands
{
    public record UpdateMessageStateCategoryDto
    {//todo: check Prop
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public short Provider { get; set; }
        public bool IsError { get; set; }
        public string Css { get; set; } = null!;

    }
}
