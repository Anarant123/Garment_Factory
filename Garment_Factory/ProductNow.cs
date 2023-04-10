using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Garment_Factory
{
    public static class ProductNow
    {
        public static int Id { get; set; }

        public static string Name { get; set; } = null!;

        public static int Width { get; set; }

        public static int Length { get; set; }

        public static BitmapImage Img { get; set; }
    }
}
