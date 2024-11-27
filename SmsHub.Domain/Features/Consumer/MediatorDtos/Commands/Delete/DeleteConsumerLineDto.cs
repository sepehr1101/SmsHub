using MediatR;

namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Delete
{
    public record DeleteConsumerLineDto  
    {
        public int Id { get; init; }

    }
}
