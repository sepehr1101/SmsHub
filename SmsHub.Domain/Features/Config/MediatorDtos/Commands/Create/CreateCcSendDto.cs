namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create
{
    public record CreateCcSendDto
    {
        public int ConfigTypeGroupId { get; set; }
        public string? Mobile { get; set; }
    }
}
