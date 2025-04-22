using System;
using System.Collections.Generic;

namespace CookSite.Models;

public partial class MediaType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Medium> Media { get; set; } = new List<Medium>();
}
