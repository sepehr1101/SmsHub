using MediatR;

namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands
{
    public record UpdateContactNumberCategoryDto  
    {
        public int Id { get; init; }
        public string Title { get; init; } = null!;
        public string Css { get; init; } = null!;
    }
}
