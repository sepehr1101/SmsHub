using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Queries
{
    public record GetInforamtaiveLogDto:IRequest
    {
        public long Id { get; init; }
        public int LogLevelId { get; init; }
        public string Section { get; init; } = null!;
        public string Description { get; init; } = null!;
        public Guid? UserId { get; init; }
        public string? UserInfo { get; init; }
        public string Ip { get; init; } = null!;
        public DateTime InsertDateTime { get; init; }
        public string ClientInfo { get; init; } = null!;
    }
}
