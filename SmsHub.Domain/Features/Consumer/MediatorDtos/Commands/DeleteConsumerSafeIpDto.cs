using MediatR;

namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Commands
{
    public record DeleteConsumerSafeIpDto : IRequest
    {
        public int Id { get; init; }

    }
}
