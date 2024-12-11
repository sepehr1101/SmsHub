using MediatR;

namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Queries
{
   public record GetConsumerDto 
    {
        public int Id { get; init; }
        public string Title { get; init; } = null!;
        public string Description { get; init; } = null!;
        public string ApiKey { get; init; } = null!;
    }
}
