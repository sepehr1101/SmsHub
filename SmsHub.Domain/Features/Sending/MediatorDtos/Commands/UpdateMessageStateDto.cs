namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands
{
    public record UpdateMessageStateDto
    {//todo: check Prop
        public long Id { get; set; }
        public int MessageStateCategoryId { get; set; }
        public long? MessagesDetailId { get; set; }
        public DateTime InsertDateTime { get; set; }
    }
}
