using System;
using System.Collections.Generic;

namespace Garment_Factory.Models.db;

public partial class TextileStock
{
    public int Id { get; set; }

    public int IdTextile { get; set; }

    public int Lenght { get; set; }

    public int Width { get; set; }

    public int? Count { get; set; }

    public virtual Textile IdTextileNavigation { get; set; } = null!;
}
