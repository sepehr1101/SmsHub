using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands
{
    public record CreateOperationTypeDto:IRequest
    { 
        public string? Title { get; init; }
        public string? Css { get; init; } 
    }
}
