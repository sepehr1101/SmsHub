using SmsHub.Domain.Constants;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete
{
    public record DeleteLogLevelDto  
    {
        public LogLevelEnum Id { get; init; }
    }
}
