using MediatR;

namespace SmsHub.Domain.Features.Contact.MediatorDtos.Queries
{
    public record GetContactNumberDto:IRequest
    {
        public int Id { get; init; }
        public string Number { get; init; } = null!;
        public int ContactCategoryId { get; init; }
        public int ContactNumberCategoryId { get; init; }
    }
}
