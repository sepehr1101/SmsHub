namespace SmsHub.Domain.Features.Security.Dtos
{
    public class JwtTokenData
    {
        public Guid UserId { get; set; }
        public string AccessToken { get; set; } = default!;
        public string RefreshToken { get; set; } = default!;
        public string RefreshTokenSerial { get; set; } = default!;
    }
}
