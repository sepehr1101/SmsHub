using SmsHub.Domain.Constants;

namespace SmsHub.Domain.Features.Line.MediatorDtos.Queries
{
    public record GetProviderDto 
    {
        public ProviderEnum Id { get; init; }
        public string Title { get; init; } = null!;
        public string? Website { get; init; }
        public string? DefaultPreNumber { get; init; }
        public int BatchSize { get; init; }
        public string BaseUri { get; init; } = null!;
        public string? FallbackBaseUri { get; init; }
        public string CredentialTemplate { get; set; } =null!;
    }
}
