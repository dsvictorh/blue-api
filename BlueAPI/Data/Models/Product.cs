using System;
using System.Collections.Generic;

namespace BlueAPI.Data.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Stock { get; set; }

    public decimal Price { get; set; }

    public int StatusId { get; set; }

    public virtual Status Status { get; set; } = null!;
}
