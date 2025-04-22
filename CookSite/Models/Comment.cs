using System;
using System.Collections.Generic;

namespace CookSite.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string Nickname { get; set; } = null!;

    public string CreateDate { get; set; } = null!;

    public string Content { get; set; } = null!;

    public int Rating { get; set; }
}
