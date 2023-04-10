using System;
using System.Collections.Generic;

namespace Garment_Factory.Models.db;

public partial class AccessoriesStock
{
    public int Id { get; set; }

    public string IdAccessories { get; set; } = null!;

    public int Count { get; set; }

    public virtual Accessory IdAccessoriesNavigation { get; set; } = null!;
}
