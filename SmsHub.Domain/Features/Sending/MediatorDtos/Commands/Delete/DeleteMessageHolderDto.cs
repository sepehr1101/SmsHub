using MediatR;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete
{
    public record DeleteMessageHolderDto  
    {
        public Guid Id { get; init; }
    }
}
