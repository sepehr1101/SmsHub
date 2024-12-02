using MediatR;

namespace SmsHub.Domain.Features.Config.MediatorDtos.Queries
{
    public record GetDisallowedPhraseDto 
    {
        public int Id { get; init; }
        public int ConfigTypeGroupId { get; init; }
        public string Phrase { get; init; } = null!;
    }
}
