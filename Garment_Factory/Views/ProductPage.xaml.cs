using Garment_Factory.Models.db;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Garment_Factory.Views
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        GarmentFactoryContext db = new GarmentFactoryContext();
        public ProductPage()
        {
            InitializeComponent();
            Product product = db.Products.FirstOrDefault(x => x.Id == ProductNow.Id)!;

            ProductNow.Name = product.Name;
            ProductNow.Width = product.Width;
            ProductNow.Length = product.Length;
            ProductNow.Img= product.Img;

            lbId.Text = $"Артикул: {ProductNow.Id}";
            lbName.Text = ProductNow.Name;
            lbWidth.Text = $"Ширина {ProductNow.Width} (см)";
            lbLength.Text = $"Длина {ProductNow.Length} (см)";
            imgProduct.Source = ProductNow.Img;
            //lbCompound.Text = "Состав:\n";

            //var list = product.IdTextiles.ToList();
            //foreach (var t in list)
            //{
            //    var textile = db.Textiles.FirstOrDefault(x => x.Id == t.Id);

            //    lbCompound.Text += textile.Name.ToString();
            //    lbCompound.Text += "\n";
            //}

            //var list = product.AccessoriesProducts.ToList();
            //foreach (var a in list)
            //{
            //    var accessory = db.Accessories.FirstOrDefault(x => x.Id == a.IdAccessories);

            //    lbCompound.Text += accessory.Name.ToString();
            //    lbCompound.Text += " " + a.Count.ToString() + " шт\n";
            //}
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri(@"Views\ProductListPage.xaml", UriKind.Relative));
        }
    }
}
