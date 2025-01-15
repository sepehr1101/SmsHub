using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Scaffold;

public partial class ContactNumberCategory
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Css { get; set; } = null!;

    public virtual ICollection<ContactNumber> ContactNumbers { get; set; } = new List<ContactNumber>();
}
