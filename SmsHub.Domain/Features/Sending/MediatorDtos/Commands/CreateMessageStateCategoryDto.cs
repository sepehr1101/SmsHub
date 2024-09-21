using MediatR;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands
{
    public record CreateMessageStateCategoryDto:IRequest
    {
        public string? Title { get; set; }
        public short Provider { get; set; }
        public bool IsError { get; set; }
        public string? Css { get; set; } 
    }
}
