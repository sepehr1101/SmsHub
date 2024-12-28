namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands
{
    public record UpdateDeepLogDto  
    {
        public long Id { get; init; }
        public int OperationTypeId { get; init; }
        public string PrimaryDb { get; init; } = null!;
        public string PrimaryTable { get; init; } = null!;
        public string PrimaryId { get; init; } = null!;
        public string? ValueBefore { get; init; }
        public string? ValueAfter { get; init; }
        public string Ip { get; init; } = null!;
        public DateTime InsertDateTime { get; init; }
        public string ClientInfo { get; init; } = null!;
    }
}
