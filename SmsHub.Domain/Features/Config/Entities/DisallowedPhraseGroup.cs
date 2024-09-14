namespace SmsHub.Domain.Features.Entities
{
    public class DisallowedPhraseGroup
    {
        public DisallowedPhraseGroup()
        {
            DisallowedPhrases = new HashSet<DisallowedPhrase>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<DisallowedPhrase> DisallowedPhrases { get; set; }
    }
}
