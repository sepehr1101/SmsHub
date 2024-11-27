using MediatR;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Queries
{
    public record GetMessageHolderDto  
    {
        public Guid Id { get; init; }
        public int MessageBatchId { get; init; }
        public DateTime InsertDateTime { get; init; }
        public int RetryCount { get; init; }
        public int DetailsSize { get; init; }
        public bool SendDone { get; init; }
    }
}
