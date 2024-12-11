using MediatR;

namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Commands
{
    public record UpdateConsumerLineDto  
    {
        public int Id { get; init; }
        public int ConsumerId { get; init; }
        public int LineId { get; init; }
    }
}
