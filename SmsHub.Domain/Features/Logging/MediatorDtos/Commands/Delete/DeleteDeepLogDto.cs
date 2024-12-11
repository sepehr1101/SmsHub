using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete
{
    public record DeleteDeepLogDto  
    {
        public long Id { get; init; }
    }
}
