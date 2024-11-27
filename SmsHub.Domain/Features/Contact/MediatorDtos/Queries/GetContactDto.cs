using MediatR;

namespace SmsHub.Domain.Features.Contact.MediatorDtos.Queries
{
    public record GetContactDto 
    {
        public int Id { get; init; }
        public string Title { get; init; } = null!;
    }
}
