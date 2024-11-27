using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create
{
    public record CreateDisallowedPhraseDto  
    {
        public int ConfigTypeGroupId { get; init; }
        public string? Phrase { get; init; } 
    }
}
