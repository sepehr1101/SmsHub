using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Queries
{
    public record GetConfigTypeGroupDto 
    {
        public int Id { get; init; }
        public short ConfigTypeId { get; init; }
        public string Title { get; init; } = null!;
        public string Description { get; init; } = null!;
    }
}
