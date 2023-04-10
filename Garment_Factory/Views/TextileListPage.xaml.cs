using Garment_Factory.Models.db;
using System.Linq;
using System.Windows.Controls;

namespace Garment_Factory.Views
{
    /// <summary>
    /// Логика взаимодействия для TextileListPage.xaml
    /// </summary>
    public partial class TextileListPage : Page
    {
        int lustUnit = 1;
        GarmentFactoryContext db = new GarmentFactoryContext();
        public TextileListPage()
        {
            InitializeComponent();
            dgTextile.ItemsSource = db.Textiles.ToList();
        }


        private void cbUnitChange_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = db.Textiles.ToList();
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
                    dgTextile.ItemsSource = list;
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
                    dgTextile.ItemsSource = list;
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
                    dgTextile.ItemsSource = list;
                    lustUnit = 2;
                    break;
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var list = db.Textiles.ToList();
            dgTextile.ItemsSource = list.Where(x => x.Name.Contains(tbSearch.Text));
        }
    }
}
