namespace SmsHub.Domain.Features.Entities
{
    public class DisallowedPhrase
    {
        public int Id { get; set; }
        public int DisallowedPhraseGroupId { get; set; }
        public string Phrase { get; set; } = null!;

        public virtual DisallowedPhraseGroup DisallowedPhraseGroup { get; set; } = null!;
    }
}
