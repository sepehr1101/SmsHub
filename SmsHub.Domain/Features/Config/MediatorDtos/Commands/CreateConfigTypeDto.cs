using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands
{
    public record CreateConfigTypeDto : IRequest
    {
        public string? Title { get; init; } 
        public string? Description { get; init; } 
    }
}
