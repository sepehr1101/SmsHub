using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Security.Entities;

[Table(nameof(Role))]
public class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Title { get; set; } = null!;
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
