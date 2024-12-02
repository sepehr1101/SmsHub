using MediatR;

namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create
{
    public record CreateContactCategoryDto 
    {
        public string? Title { get; init; }
        public string Description { get; init; }
        public string? Css { get; init; }
    }
}
