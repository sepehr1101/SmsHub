using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Queries
{
    public record GetLogLevelDto:IRequest
    {
        public int Id { get; init; }
        public string Title { get; init; } = null!;
        public string Css { get; init; } = null!;
    }
}
