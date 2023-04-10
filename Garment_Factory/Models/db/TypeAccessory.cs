using System;
using System.Collections.Generic;

namespace Garment_Factory.Models.db;

public partial class TypeAccessory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Accessory> IdAccessories { get; } = new List<Accessory>();
}
