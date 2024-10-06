using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete
{
    public record DeleteInformativeLogDto : IRequest
    {
        public long Id { get; init; }
    }
}
