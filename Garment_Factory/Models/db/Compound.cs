using System;
using System.Collections.Generic;

namespace Garment_Factory.Models.db;

public partial class Compound
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Textile> IdTextiles { get; } = new List<Textile>();
}
