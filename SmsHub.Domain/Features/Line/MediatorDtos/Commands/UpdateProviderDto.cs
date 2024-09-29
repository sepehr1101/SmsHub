using SmsHub.Domain.Constants;

namespace SmsHub.Domain.Features.Line.MediatorDtos.Commands
{
    public record UpdateProviderDto
    {
        public ProviderEnum Id { get; set; }
        public string Title { get; init; } = null!;
        public string? Website { get; set; }
        public string? DefaultPreNumber { get; set; }
        public int BatchSize { get; set; }
        public string BaseUri { get; set; } = null!;
        public string FallbackBaseUri { get; set; } = null!;
    }
}
