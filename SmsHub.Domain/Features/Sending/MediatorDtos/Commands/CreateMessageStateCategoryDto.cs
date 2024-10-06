using MediatR;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands
{
    public record CreateMessageStateCategoryDto:IRequest
    {
        public string? Title { get; init; }
        public short Provider { get; init; }
        public bool IsError { get; init; }
        public string? Css { get; init; } 
    }
}
