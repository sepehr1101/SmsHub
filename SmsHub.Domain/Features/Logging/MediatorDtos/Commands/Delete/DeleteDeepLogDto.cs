using MediatR;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete
{
    public record DeleteDeepLogDto : IRequest
    {
        public long Id { get; init; }
    }
}
