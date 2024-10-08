using MediatR;
using SmsHub.Domain.Constants;

namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands.Delete
{
    public record DeleteContactNumberDto : IRequest
    {
        public int Id { get; init; }

    }
}
