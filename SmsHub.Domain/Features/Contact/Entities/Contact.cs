using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Entities
{
    [Table(nameof(Contact))]
    public class Contact
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
