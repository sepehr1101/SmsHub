using MediatR;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands
{
    public record DeleteMessageStateDto : IRequest
    {
        public long Id { get; init; }
    }
}
