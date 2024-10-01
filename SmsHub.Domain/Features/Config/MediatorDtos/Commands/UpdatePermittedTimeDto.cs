namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands
{
    public record UpdatePermittedTimeDto
    {//todo: check Prop
        public int Id { get; set; }
        public int ConfigTypeGroupId { get; set; }
        public string FromTime { get; set; } = null!;
        public string ToTime { get; set; } = null!;
    }
}
