using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands
{
    public record CreateConfigTypeGroupDto : IRequest
    {
        public short ConfigTypeId { get; init; }
        public string? Title { get; init; } 
        public string? Description { get; init; } 
    }
}
