using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Entities
{
    [Table(nameof(ContactCategory))]
    public class ContactCategory
    {
        public ContactCategory()
        {
            ContactNumbers = new HashSet<ContactNumber>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Css { get; set; } = null!;

        public virtual ICollection<ContactNumber> ContactNumbers { get; set; }
    }
}
