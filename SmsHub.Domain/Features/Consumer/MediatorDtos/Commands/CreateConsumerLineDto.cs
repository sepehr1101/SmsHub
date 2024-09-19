using MediatR;

namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Commands
{
    public record CreateConsumerLineDto:IRequest
    {
        //todo : everyone null?
        public int ConsumerId { get; set; }
        public int LineId { get; set; }
    }
}
