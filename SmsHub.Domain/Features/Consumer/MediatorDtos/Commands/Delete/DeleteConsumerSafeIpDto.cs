using MediatR;

namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Delete
{
    public record DeleteConsumerSafeIpDto  
    {
        public int Id { get; init; }

    }
}
