using MediatR;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands
{
    public record DeleteMessageDetailDto : IRequest
    {
        public long Id { get; init; }
    }
}
