using System;
using System.Collections.Generic;

namespace Garment_Factory.Models.db;

public partial class AccessoriesProduct
{
    public int IdProduct { get; set; }

    public string IdAccessories { get; set; } = null!;

    public string? Cord { get; set; }

    public double? Angle { get; set; }

    public int Count { get; set; }

    public virtual Accessory IdAccessoriesNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
