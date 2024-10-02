using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands
{
    public record CreatePermittedTimeDto : IRequest
    {
        public int ConfigTypeGroupId { get; init; }
        public string? FromTime { get; init; }
        public string? ToTime { get; init; } 
    }
}
