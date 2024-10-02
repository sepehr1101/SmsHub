using MediatR;

namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Commands
{
    public record CreateConsumerSafeIpDto:IRequest
    {
        public int ConsumerId { get; init; }
        public string? FromIp { get; init; } 
        public string? ToIp { get; init; } 
        public bool IsV6 { get; init; }
    }
}
