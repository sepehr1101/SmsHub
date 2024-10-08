using MediatR;

namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create
{
    public record CreateContactDto : IRequest
    {
        public string Title { get; init; } = null!;

    }
}
