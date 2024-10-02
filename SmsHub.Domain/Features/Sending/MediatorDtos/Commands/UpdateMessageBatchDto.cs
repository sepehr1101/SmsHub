namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands
{
    public record UpdateMessageBatchDto
    {//todo: check Prop
        public int Id { get; set; }
        public int HolerSize { get; set; }
        public int AllSize { get; set; }
        public DateTime InsertDateTime { get; set; }
        public int LineId { get; set; }
    }
}
