namespace SmsHub.Domain.Providers.Magfa3000.Entities.Responses
{
    public record CredentialDto
    {
        public string Domain { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string ClientSecret { get; set; } = null!;

    }
}
