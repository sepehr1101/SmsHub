namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands
{
    public record UpdateDisallowedPhraseDto
    {
        public int Id { get; init; }
        public int ConfigTypeGroupId { get; init; }
        public string Phrase { get; init; } = null!;
    }
}
