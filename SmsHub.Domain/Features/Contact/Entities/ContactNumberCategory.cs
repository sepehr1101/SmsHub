using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Entities
{
    [Table(nameof(ContactNumberCategory))]
    public class ContactNumberCategory
    {
        public ContactNumberCategory()
        {
            ContactNumbers = new HashSet<ContactNumber>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Css { get; set; } = null!;

        public virtual ICollection<ContactNumber> ContactNumbers { get; set; }
    }
}
