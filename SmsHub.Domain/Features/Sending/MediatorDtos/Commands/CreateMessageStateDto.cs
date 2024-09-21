using MediatR;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands
{
    public record CreateMessageStateDto:IRequest
    {
        public int MessageStateCategoryId { get; set; }
        public long? MessagesDetailId { get; set; }
        public DateTime InsertDateTime { get; set; }
    }
}
