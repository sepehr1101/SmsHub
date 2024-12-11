using MediatR;

namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Create
{
    public record CreateContactNumberCategoryDto  
    {
        public string Title { get; init; } = null!;
        public string Css { get; init; } = null!;
    }
}
