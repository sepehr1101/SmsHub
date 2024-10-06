using MediatR;

namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Delete
{
    public record DeleteConsumerSafeIpDto : IRequest
    {
        public int Id { get; init; }

    }
}
