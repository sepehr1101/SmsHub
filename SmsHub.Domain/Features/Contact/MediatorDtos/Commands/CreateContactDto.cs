using MediatR;

namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands
{
    public record CreateContactDto : IRequest
    {
        public string? Title { get; init; }

    }
}
