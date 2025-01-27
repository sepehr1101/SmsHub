using SmsHub.Domain.Constants;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Queries
{
    public record GetLogLevelDto 
    {
        public LogLevelEnum Id { get; init; }
        public string Title { get; init; } = null!;
        public string Css { get; init; } = null!;
    }
}
