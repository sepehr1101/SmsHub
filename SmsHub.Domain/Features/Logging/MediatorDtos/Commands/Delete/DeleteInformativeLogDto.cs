using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete
{
    public record DeleteInformativeLogDto  
    {
        public long Id { get; init; }
    }
}
