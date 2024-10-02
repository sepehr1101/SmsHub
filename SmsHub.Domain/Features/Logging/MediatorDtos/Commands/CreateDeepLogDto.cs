using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands
{
    public record CreateDeepLogDto : IRequest
    { 
        public int OperationTypeId { get; init; }
        public string? PrimaryDb { get; init; }
        public string? PrimaryTable { get; init; } 
        public string? PrimaryId { get; init; }
        public string? ValueBefore { get; init; }
        public string? ValueAfter { get; init; }
        public string? Ip { get; init; }
        public DateTime InsertDateTime { get; init; }
        public string? ClientInfo { get; init; }
    }
}
