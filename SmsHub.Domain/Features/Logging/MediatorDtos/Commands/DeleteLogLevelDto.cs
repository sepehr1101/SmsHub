using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands
{
    public record DeleteLogLevelDto : IRequest
    {
        public int Id { get; init; }
    }
}
