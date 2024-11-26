using SmsHub.Domain.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Entities
{
    [Table(nameof(Provider))]
    public class Provider
    {
        public Provider()
        {
            Lines = new HashSet<Line>();
            MessageStateCategories = new HashSet<MessageStateCategory>();
        }

        public ProviderEnum Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Website { get; set; }
        public string? DefaultPreNumber { get; set; }
        public int BatchSize { get; set; }
        public string BaseUri { get; set; } = null!;
        public string? FallbackBaseUri { get; set; }
        public string CredentialTemplate { get; set; } = default!;

        public virtual ICollection<Line> Lines { get; set; }
        public virtual ICollection<MessageStateCategory> MessageStateCategories { get; set; }

        public void Update()
        {

        }
    }
}
