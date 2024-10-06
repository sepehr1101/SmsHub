using MediatR;

namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Commands
{
    public record CreateConsumerLineDto:IRequest
    {
        public int ConsumerId { get; init; }
        public int LineId { get; init; }
    }
}
