using SmsHub.Domain.Constants;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands
{
    public record UpdateInformativeLogDto  
    {
        public long Id { get; init; }
        public LogLevelEnum LogLevelId { get; init; }
        public string Section { get; init; } = null!;
        public string Description { get; init; }
        public Guid? UserId { get; init; }
        public string? UserInfo { get; init; }
        public string Ip { get; init; } = null!;
        public DateTime InsertDateTime { get; init; }
        public string ClientInfo { get; init; } = null!;
    }
}
