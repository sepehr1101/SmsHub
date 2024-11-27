using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Queries
{
    public record GetPermittedTimeDto 
    {
        public int Id { get; init; }
        public int ConfigTypeGroupId { get; init; }
        public string FromTime { get; init; } = null!;
        public string ToTime { get; init; } = null!;
    }
}
