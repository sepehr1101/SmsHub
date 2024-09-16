using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Entities
{
    [Table(nameof(ConfigTypeGroup))]
    public class ConfigTypeGroup
    {
        public ConfigTypeGroup()
        {
            CcSends = new HashSet<CcSend>();
            Configs = new HashSet<Config>();
            DisallowedPhrases = new HashSet<DisallowedPhrase>();
            PermittedTimes = new HashSet<PermittedTime>();
        }

        public int Id { get; set; }
        public short ConfigTypeId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ConfigType ConfigType { get; set; } = null!;
        public virtual ICollection<CcSend> CcSends { get; set; }
        public virtual ICollection<Config> Configs { get; set; }
        public virtual ICollection<DisallowedPhrase> DisallowedPhrases { get; set; }
        public virtual ICollection<PermittedTime> PermittedTimes { get; set; }
    }
}
