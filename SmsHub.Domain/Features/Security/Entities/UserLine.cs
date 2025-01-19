using System.ComponentModel.DataAnnotations.Schema;
using Entity = SmsHub.Domain.Features.Entities;

namespace SmsHub.Domain.Features.Security.Entities
{
    [Table(nameof(UserLine))]
    public class UserLine
    {
        public long Id { get; set; }
        public int LineId { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Entity.Line Line { get; set; }=null!;
    }
}
