namespace SmsHub.Domain.Features.Security.Dtos
{
    public class BearerTokenOptions
    {
        public string Key { set; get; } = default!;
        public string Issuer { set; get; } = default!;
        public string Audience { set; get; } = default!;
        public int AccessTokenExpirationMinutes { set; get; }
        public int RefreshTokenExpirationMinutes { set; get; }
        public bool AllowMultipleLoginsFromTheSameUser { set; get; }
        public bool AllowSignoutAllUserActiveClients { set; get; }
    }
}
