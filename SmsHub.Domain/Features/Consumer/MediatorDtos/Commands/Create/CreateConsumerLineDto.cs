namespace SmsHub.Domain.Features.Consumer.MediatorDtos.Commands.Create
{
    public record CreateConsumerLineDto  
    {
        public int ConsumerId { get; set; }
        public int LineId { get; set; }
    }
}
