using Garment_Factory.Models.db;
using System;
using System.Linq;
using System.Windows.Controls;

namespace Garment_Factory.Views
{
    /// <summary>
    /// Логика взаимодействия для ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        GarmentFactoryContext db = new GarmentFactoryContext();
        public ProductListPage()
        {
            InitializeComponent();

            lvProduct.ItemsSource = db.Products.ToList();
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductNow.Id = (lvProduct.SelectedItem as Product).Id;

            if(UserNow.Role == "Заказчик")
                this.NavigationService.Navigate(new Uri(@"Views\ProductPage.xaml", UriKind.Relative));
            else
                this.NavigationService.Navigate(new Uri(@"Views\ProductDMPage.xaml", UriKind.Relative));
        }
    }
}
