using MediatR;

namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands
{
    public record CreateContactNumberCategoryDto : IRequest
    {
        public string? Title { get; init; }
        public string? Css { get; init; }
    }
}
