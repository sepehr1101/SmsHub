using MediatR;

namespace SmsHub.Domain.Features.Line.MediatorDtos.Commands
{
    public record CreateProviderDto:IRequest
    {
        public string? Title { get; init; } 
        public string? Website { get; init; }
        public string? DefaultPreNumber { get; init; }
        public int BatchSize { get; init; }
        public string? BaseUri { get; init; }
        public string? FallbackBaseUri { get; init; } 
    }
}
