namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create
{
    public record CreateMessagesHolderDto  
    {
        public int MessageBatchId { get; init; }
        public DateTime InsertDateTime { get; init; }
        public int RetryCount { get; init; }
        public int DetailsSize { get; init; }
        public bool SendDone { get; init; }
    }
}
