using System;
using System.Collections.Generic;

namespace CookSite.Models;

public partial class CookType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
