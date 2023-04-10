using System;
using System.Collections.Generic;

namespace Garment_Factory.Models.db;

public partial class Textile
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TypePicture { get; set; }

    public double? Width { get; set; }

    public double? Lenght { get; set; }

    public int Price { get; set; }

    public virtual ICollection<TextileStock> TextileStocks { get; } = new List<TextileStock>();

    public virtual TypePicture TypePictureNavigation { get; set; } = null!;

    public virtual ICollection<Color> IdColors { get; } = new List<Color>();

    public virtual ICollection<Compound> IdCompounds { get; } = new List<Compound>();

    public virtual ICollection<Product> IdProducts { get; } = new List<Product>();
}
