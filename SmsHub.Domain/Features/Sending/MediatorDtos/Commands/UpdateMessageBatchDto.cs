using MediatR;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands
{
    public record UpdateMessageBatchDto : IRequest
    {
        public int Id { get; init; }
        public int HolerSize { get; init; }
        public int AllSize { get; init; }
        public DateTime InsertDateTime { get; init; }
        public int LineId { get; init; }
    }
}
