using MediatR;

namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create
{
    public record CreateContactCategoryDto : IRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Css { get; set; }
    }
}
