using System;
using System.Collections.Generic;

namespace BlueAPI.Data.Models;

public partial class Status
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Product { get; set; } = new List<Product>();
}
