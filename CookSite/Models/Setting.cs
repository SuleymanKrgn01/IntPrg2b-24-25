using System;
using System.Collections.Generic;

namespace CookSite.Models;

public partial class Setting
{
    public int Id { get; set; }

    public string Key { get; set; } = null!;

    public string Value { get; set; } = null!;

    public string? Description { get; set; }

    public int IsActive { get; set; }
}
