using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete
{
    public record DeleteLogLevelDto  
    {
        public int Id { get; init; }
    }
}
