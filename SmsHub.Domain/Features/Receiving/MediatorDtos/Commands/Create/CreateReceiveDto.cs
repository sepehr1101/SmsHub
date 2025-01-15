namespace SmsHub.Domain.Features.Receiving.MediatorDtos.Commands.Create
{
    public record CreateReceiveDto
    {
        public long? MessageId { get; init; }
        public int? Status { get; init; }
        public string MessageText { get; init; }
        public string Sender { get; init; }
        public string Receptor { get; init; }
        public DateTime ReceiveDateTime { get; init; }
        public DateTime InsertDateTime { get; init; }
    }
}
