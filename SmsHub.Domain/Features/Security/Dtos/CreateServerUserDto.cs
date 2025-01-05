using MediatR;

namespace SmsHub.Domain.Features.Security.Dtos
{
    public record CreateServerUserDto : IRequest<ApiKeyAndHash>
    {
        public string Username { get; init; } = null!;
        public bool IsAdmin { get; init; }
        public string ApiKeyHash { get; set; } = null!;

    }
}
