namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands
{
    public record UpdateConfigTypeDto
    {//todo: check Prop
        public short Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
