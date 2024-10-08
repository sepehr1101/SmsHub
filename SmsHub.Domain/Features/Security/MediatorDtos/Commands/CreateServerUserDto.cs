using MediatR;
using SmsHub.Domain.Features.Security.Dtos;

namespace SmsHub.Domain.Features.Security.MediatorDtos.Commands
{
    public record CreateServerUserDto : IRequest<ApiKeyAndHash>
    {
        public string Username { get; init; } = null!;
        public bool IsAdmin { get; init; }
        public string ApiKeyHash { get; set; } = null!;

    }
}
