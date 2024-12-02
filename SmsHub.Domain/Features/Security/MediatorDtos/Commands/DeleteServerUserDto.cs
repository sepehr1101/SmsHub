using MediatR;

namespace SmsHub.Domain.Features.Security.MediatorDtos.Commands
{
    public record DeleteServerUserDto  
    {
        public int Id { get; init; }
    }
}
