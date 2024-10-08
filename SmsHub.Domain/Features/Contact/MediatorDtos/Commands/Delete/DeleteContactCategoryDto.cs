using MediatR;

namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete
{
    public record DeleteContactCategoryDto: IRequest
    {
        public int Id { get; init; }

    }
}
