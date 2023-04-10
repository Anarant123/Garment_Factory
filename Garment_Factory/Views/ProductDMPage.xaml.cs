using Garment_Factory.Models.db;
using System.Linq;
using System.Windows.Controls;

namespace Garment_Factory.Views
{
    /// <summary>
    /// Логика взаимодействия для ProductDMPage.xaml
    /// </summary>
    public partial class ProductDMPage : Page
    {
        GarmentFactoryContext db = new GarmentFactoryContext();

        public ProductDMPage()
        {
            InitializeComponent();
            Product product = db.Products.FirstOrDefault(x => x.Id == ProductNow.Id)!;

            ProductNow.Name = product.Name;
            ProductNow.Width = product.Width;
            ProductNow.Length = product.Length;
            ProductNow.Img = product.Img;

            lbId.Text = $"Артикул: {ProductNow.Id}";
            lbName.Text = ProductNow.Name;
            lbWidth.Text = $"Ширина {ProductNow.Width} (см)";
            lbLength.Text = $"Длина {ProductNow.Length} (см)";
            imgProduct.Source = ProductNow.Img;
        }
    }
}
