using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands
{
    public record DeleteInformativeLogDto : IRequest
    {
        public long Id { get; init; }
    }
}
