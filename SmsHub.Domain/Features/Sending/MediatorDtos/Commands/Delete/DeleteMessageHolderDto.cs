using MediatR;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete
{
    public record DeleteMessageHolderDto : IRequest
    {
        public Guid Id { get; init; }
    }
}
