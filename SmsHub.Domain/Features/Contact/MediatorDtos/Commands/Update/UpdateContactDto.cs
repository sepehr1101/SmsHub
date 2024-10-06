using MediatR;

namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands
{
    public record UpdateContactDto : IRequest
    {
        public int Id { get; init; }
        public string Title { get; init; } = null!;
    }
}
