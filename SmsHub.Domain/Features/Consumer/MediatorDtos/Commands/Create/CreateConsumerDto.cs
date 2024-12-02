using MediatR;

namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create
{
    public record CreateConsumerDto  
    {
        public string? Title { get; init; }
        public string? Description { get; init; }
        public string? ApiKey { get; init; }
    }
}
