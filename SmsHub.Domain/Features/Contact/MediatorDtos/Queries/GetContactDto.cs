using MediatR;

namespace SmsHub.Domain.Features.Contact.MediatorDtos.Queries
{
    public record GetContactDto:IRequest
    {
        public int Id { get; init; }
        public string Title { get; init; } = null!;
    }
}
