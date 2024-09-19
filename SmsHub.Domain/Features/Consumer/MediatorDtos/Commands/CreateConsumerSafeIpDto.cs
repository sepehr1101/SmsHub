using MediatR;

namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Commands
{
    public record CreateConsumerSafeIpDto:IRequest
    {
        //todo : everyone null?
        public int ConsumerId { get; set; }
        public string FromIp { get; set; } //todo : is it null?
        public string ToIp { get; set; } // todo: is it null?
        public bool IsV6 { get; set; }
    }
}
