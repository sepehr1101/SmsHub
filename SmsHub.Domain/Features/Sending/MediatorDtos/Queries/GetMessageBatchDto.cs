using MediatR;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Queries
{
    public record GetMessageBatchDto  
    {
        public int Id { get; init; }
        public int HolderSize { get; init; }
        public int AllSize { get; init; }
        public DateTime InsertDateTime { get; init; }
        public int LineId { get; init; }
    }
}
