using MediatR;
using SmsHub.Domain.Constants;
namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete
{
    public record DeleteContactDto : IRequest
    {
        public int Id { get; init; }

    }
}
