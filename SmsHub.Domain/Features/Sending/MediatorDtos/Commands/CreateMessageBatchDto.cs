using MediatR;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands
{
    public record CreateMessageBatchDto:IRequest
    {
        public int HolerSize { get; set; }
        public int AllSize { get; set; }
        public DateTime InsertDateTime { get; set; }
        public int LineId { get; set; }
    }
}
