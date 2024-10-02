using MediatR;

namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands
{
    public record DeleteContactCategoryDto: IRequest
    {
        public int Id { get; init; }

    }
}
