using System;
using System.Collections.Generic;

namespace Garment_Factory.Models.db;

public partial class Accessory
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public double Width { get; set; }

    public double? Lenght { get; set; }

    public int Price { get; set; }

    public int? Weight { get; set; }

    public virtual ICollection<AccessoriesProduct> AccessoriesProducts { get; } = new List<AccessoriesProduct>();

    public virtual ICollection<AccessoriesStock> AccessoriesStocks { get; } = new List<AccessoriesStock>();

    public virtual ICollection<TypeAccessory> IdTypeAccessories { get; } = new List<TypeAccessory>();
}
