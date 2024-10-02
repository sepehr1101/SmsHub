using MediatR;
using SmsHub.Domain.Constants;

namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands
{
    public record DeleteContactNumberDto : IRequest
    {
        public int Id { get; init; }

    }
}
