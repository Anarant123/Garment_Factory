using Garment_Factory.Models.db;
using System.Linq;
using System.Windows.Controls;

namespace Garment_Factory.Views
{
    /// <summary>
    /// Логика взаимодействия для AccessoriesListPage.xaml
    /// </summary>
    public partial class AccessoriesListPage : Page
    {
        int lustUnit = 1;
        GarmentFactoryContext db = new GarmentFactoryContext();
        public AccessoriesListPage()
        {
            InitializeComponent();
            dgAccessory.ItemsSource = db.Accessories.ToList();
        }

        private void cbUnitChange_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = db.Accessories.ToList();
            switch (cbUnitChange.SelectedIndex)
            {
                case 0:
                    if (lustUnit == 1)
                        foreach (var item in list)
                        {
                            item.Lenght /= 100;
                            item.Width /= 100;
                        }
                    else if (lustUnit == 2)
                        foreach (var item in list)
                        {
                            item.Lenght /= 1000;
                            item.Width /= 1000;
                        }
                    dgAccessory.ItemsSource = list;
                    lustUnit = 0;
                    break;
                case 1:
                    if (lustUnit == 0)
                        foreach (var item in list)
                        {
                            item.Lenght *= 100;
                            item.Width *= 100;
                        }
                    else if (lustUnit == 2)
                        foreach (var item in list)
                        {
                            item.Lenght /= 10;
                            item.Width /= 10;
                        }
                    dgAccessory.ItemsSource = list;
                    lustUnit = 1;
                    break;
                case 2:
                    if (lustUnit == 0)
                        foreach (var item in list)
                        {
                            item.Lenght *= 1000;
                            item.Width *= 1000;
                        }
                    else if (lustUnit == 1)
                        foreach (var item in list)
                        {
                            item.Lenght *= 10;
                            item.Width *= 10;
                        }
                    dgAccessory.ItemsSource = list;
                    lustUnit = 2;
                    break;
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var list = db.Accessories.ToList();
            dgAccessory.ItemsSource = list.Where(x => x.Name.Contains(tbSearch.Text));
        }
    }
}
