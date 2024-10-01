namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands
{
    public record UpdateMessageDetailDto
    {//todo: check Prop
        public long Id { get; set; }
        public Guid MessagesHolderId { get; set; }
        public string Receptor { get; set; } = null!;
        public long ProviderResult { get; set; }
        public DateTime SendDateTime { get; set; }
        public string Text { get; set; } = null!;
        public short SmsCount { get; set; }
    }
}
