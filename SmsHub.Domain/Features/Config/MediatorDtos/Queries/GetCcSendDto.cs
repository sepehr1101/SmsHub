namespace SmsHub.Domain.Features.Config.MediatorDtos.Queries
{
    public record GetCcSendDto 
    {
        public int Id { get; init; }
        public int ConfigTypeGroupId { get; init; }
        public string Mobile { get; init; } = null!;
    }
}
