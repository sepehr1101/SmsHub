namespace SmsHub.Domain.Features.Entities
{
    public partial class ContactNumber
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public int ContactCategoryId { get; set; }
        public int ContactNumberCategoryId { get; set; }

        public virtual ContactCategory ContactCategory { get; set; } = null!;
        public virtual ContactNumberCategory ContactNumberCategory { get; set; } = null!;
    }
}
