using MediatR;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update
{
    public record UpdateMessageStateDto  
    {
        public long Id { get; init; }
        public int MessageStateCategoryId { get; init; }
        public long? MessagesDetailId { get; init; }
        public DateTime InsertDateTime { get; init; }
    }
}
