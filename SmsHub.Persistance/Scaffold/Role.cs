using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Scaffold;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Title { get; set; } = null!;

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
