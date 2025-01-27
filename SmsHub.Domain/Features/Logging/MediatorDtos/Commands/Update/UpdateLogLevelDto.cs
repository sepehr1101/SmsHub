using SmsHub.Domain.Constants;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands
{
    public record UpdateLogLevelDto  
    {
        public LogLevelEnum Id { get; init; }
        public string Css { get; init; } = null!;
    }
}
