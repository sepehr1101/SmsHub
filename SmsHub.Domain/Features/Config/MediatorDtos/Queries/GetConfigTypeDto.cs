using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Queries
{
    public record GetConfigTypeDto:IRequest
    {
        public short Id { get; init; }
        public string Title { get; init; } = null!;
        public string Description { get; init; } = null!;
    }
}
