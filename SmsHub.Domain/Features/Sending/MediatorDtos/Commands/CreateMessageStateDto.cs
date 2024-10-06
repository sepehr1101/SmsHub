using MediatR;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands
{
    public record CreateMessageStateDto:IRequest
    {
        public int MessageStateCategoryId { get; init; }
        public long? MessagesDetailId { get; init; }
        public DateTime InsertDateTime { get; init; }
    }
}
