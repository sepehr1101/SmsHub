namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Commands
{
    public record UpdateConsumerDto  
    {
        public int Id { get; init; }
        public string Title { get; init; } = null!;
        public string Description { get; init; } = null!;
        public string ApiKey { get; init; } = null!;
    }
}
