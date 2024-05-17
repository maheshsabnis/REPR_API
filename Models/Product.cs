using System;
using System.Collections.Generic;

namespace REPR_API.Models;

public partial class Product : EntityBase
{
    public Product()
    {
        
    }
    public int ProductUniqueId { get; set; }

    public string? ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;

    public int Price { get; set; }

    public int CategoryUniqueId { get; set; }

    public virtual Category CategoryUnique { get; set; } = null!;
}
