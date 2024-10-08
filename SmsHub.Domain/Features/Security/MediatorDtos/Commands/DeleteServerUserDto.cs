using MediatR;

namespace SmsHub.Domain.Features.Security.MediatorDtos.Commands
{
    public record DeleteServerUserDto : IRequest
    {
        public int Id { get; init; }
    }
}
