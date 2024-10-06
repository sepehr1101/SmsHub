using MediatR;

namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create
{
    public record CreateContactNumberDto : IRequest
    {
        public string? Number { get; init; }
        public int ContactCategoryId { get; init; }
        public int ContactNumberCategoryId { get; init; }
    }
}
