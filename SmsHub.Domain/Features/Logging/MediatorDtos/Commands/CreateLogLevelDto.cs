using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands
{
    public record CreateLogLevelDto:IRequest
    { 
        public string? Title { get; init; } 
        public string? Css { get; init; } 
    }
}
