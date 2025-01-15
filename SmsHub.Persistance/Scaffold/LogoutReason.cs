using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Scaffold;

public partial class LogoutReason
{
    public short Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<UserLogin> UserLogins { get; set; } = new List<UserLogin>();
}
