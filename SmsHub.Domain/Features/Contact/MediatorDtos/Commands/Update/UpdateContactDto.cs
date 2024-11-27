using MediatR;

namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands
{
    public record UpdateContactDto  
    {
        public int Id { get; init; }
        public string Title { get; init; } = null!;
    }
}
