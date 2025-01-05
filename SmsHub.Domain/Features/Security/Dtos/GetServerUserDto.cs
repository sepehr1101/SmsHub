namespace SmsHub.Domain.Features.Security.Dtos
{
    public record GetServerUserDto
    {
        public int Id { get; init; }
        public string Username { get; init; } = null!;
        public bool IsAdmin { get; init; }
        public DateTime CreateDateTime { get; init; }
        public DateTime? DeleteDateTime { get; init; }
        public string ApiKeyHash { get; init; } = null!;
    }
}
