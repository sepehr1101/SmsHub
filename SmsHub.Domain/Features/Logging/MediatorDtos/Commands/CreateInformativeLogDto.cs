using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands
{
    public record CreateInformativeLogDto:IRequest
    { 
        public int LogLevelId { get; init; }
        public string? Section { get; init; } 
        public string? Description { get; init; }
        public Guid? UserId { get; init; }
        public string? UserInfo { get; init; }
        public string? Ip { get; init; }
        public DateTime InsertDateTime { get; init; }
        public string? ClientInfo { get; init; } 
    }
}
