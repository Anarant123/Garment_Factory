using Microsoft.Win32;
using System.IO;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace Garment_Factory.Models.db;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Width { get; set; }

    public int Length { get; set; }

    public byte[]? Image { get; set; }

    public virtual ICollection<AccessoriesProduct> AccessoriesProducts { get; } = new List<AccessoriesProduct>();

    public virtual ICollection<ProductOrder> ProductOrders { get; } = new List<ProductOrder>();

    public virtual ICollection<Textile> IdTextiles { get; } = new List<Textile>();
    public BitmapImage Img
    {
        get
        {
            if (this.Image == null)
            {
                OpenFileDialog o = new OpenFileDialog();
                o.FileName = @"C:\\Учеба\\Практика\\Учебная весна\\Garment_Factory\\Garment_Factory\\Resources\\icon_image.png";
                return LoadImage.Load(File.ReadAllBytes(o.FileName));
            }
            else
                return LoadImage.Load(this.Image);
        }
    }
}
