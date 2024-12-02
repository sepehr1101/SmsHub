using MediatR;

namespace SmsHub.Domain.Features.Contact.MediatorDtos.Queries
{
    public record GetContactNumberCategoryDto  
    {
        public int Id { get; init; }
        public string Title { get; init; } = null!;
        public string Css { get; init; } = null!;
    }
}
