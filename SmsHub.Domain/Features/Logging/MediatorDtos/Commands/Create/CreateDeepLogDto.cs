using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create
{
    public record CreateDeepLogDto  
    { 
        public int OperationTypeId { get; init; }
        public string PrimaryDb { get; init; } = null!;
        public string PrimaryTable { get; init; } = null!;
        public string PrimaryId { get; init; } = null!;
        public string? ValueBefore { get; init; }
        public string? ValueAfter { get; init; }
        public string? Ip { get; init; }
        public DateTime InsertDateTime { get; init; }
        public string ClientInfo { get; init; } = null!;
    }
}
