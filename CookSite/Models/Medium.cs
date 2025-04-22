using System;
using System.Collections.Generic;

namespace CookSite.Models;

public partial class Medium
{
    public int Id { get; set; }

    public string Path { get; set; } = null!;

    public string? AltText { get; set; }

    public int MediaTypeId { get; set; }

    public int RecipeId { get; set; }

    public virtual MediaType MediaType { get; set; } = null!;

    public virtual Recipe Recipe { get; set; } = null!;
}
