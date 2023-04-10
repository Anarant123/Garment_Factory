using System;
using System.Collections.Generic;

namespace Garment_Factory.Models.db;

public partial class TypePicture
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Textile> Textiles { get; } = new List<Textile>();
}
