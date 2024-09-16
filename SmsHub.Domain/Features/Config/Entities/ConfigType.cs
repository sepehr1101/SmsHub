using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Entities
{
    [Table(nameof(ConfigType))]
    public class ConfigType
    {
        public ConfigType()
        {
            ConfigTypeGroups = new HashSet<ConfigTypeGroup>();
        }

        public short Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<ConfigTypeGroup> ConfigTypeGroups { get; set; }
    }
}
