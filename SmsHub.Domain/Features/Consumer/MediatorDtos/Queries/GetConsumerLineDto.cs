namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Queries
{
    public record GetConsumerLineDto 
    {
        public int Id { get; init; }
        public int ConsumerId { get; init; }
        public int LineId { get; init; }
    }
}
