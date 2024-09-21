using MediatR;

namespace SmsHub.Domain.Features.Line.MediatorDtos.Commands
{
    public record CreateProviderDto:IRequest
    {
        public string? Title { get; set; } 
        public string? Website { get; set; }
        public string? DefaultPreNumber { get; set; }
        public int BatchSize { get; set; }
        public string? BaseUri { get; set; }
        public string? FallbackBaseUri { get; set; } 


    }
}
