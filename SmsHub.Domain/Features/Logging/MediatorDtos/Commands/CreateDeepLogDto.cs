using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands
{
    public record CreateDeepLogDto : IRequest
    { 
        public int OperationTypeId { get; set; }
        public string? PrimaryDb { get; set; }
        public string? PrimaryTable { get; set; } 
        public string? PrimaryId { get; set; }
        public string? ValueBefore { get; set; }
        public string? ValueAfter { get; set; }
        public string? Ip { get; set; }
        public DateTime InsertDateTime { get; set; }
        public string? ClientInfo { get; set; }
    }
}
