using System;
using System.Collections.Generic;

namespace Garment_Factory.Models.db;

public partial class ProductOrder
{
    public int IdProduct { get; set; }

    public int IdOrder { get; set; }

    public int Count { get; set; }

    public string Name { get; set; } = null!;

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
