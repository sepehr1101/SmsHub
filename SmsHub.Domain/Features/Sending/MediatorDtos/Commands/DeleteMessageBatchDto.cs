using MediatR;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands
{
    public record DeleteMessageBatchDto : IRequest
    {
        public int Id { get; init; }
    }
}
