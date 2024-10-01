namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands
{
    public record UpdateMessageHolderDto
    {//todo: check Prop
        public Guid Id { get; set; }
        public int MessageBatchId { get; set; }
        public DateTime InsertDateTime { get; set; }
        public int RetryCount { get; set; }
        public int DetailsSize { get; set; }
        public bool SendDone { get; set; }
    }
}
