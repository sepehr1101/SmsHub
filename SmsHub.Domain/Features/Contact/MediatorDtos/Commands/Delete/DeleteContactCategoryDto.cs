using MediatR;

namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete
{
    public record DeleteContactCategoryDto 
    {
        public int Id { get; init; }

    }
}
