using System;
using System.Collections.Generic;

namespace REPR_API.Models;

public partial class Category : EntityBase
{
    public Category()
    {
        
    }
    public int CategoryUniqueId { get; set; }

    public string CategoryId { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public int BasePrice { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
