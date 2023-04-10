using Garment_Factory.Models.db;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Garment_Factory.Views
{
    /// <summary>
    /// Логика взаимодействия для LeftoversPage.xaml
    /// </summary>
    public partial class LeftoversPage : Page
    {
        GarmentFactoryContext db = new GarmentFactoryContext();
        public LeftoversPage()
        {
            InitializeComponent();
            cb.SelectedIndex= 0;
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb.SelectedIndex == 0)
            {
                var tbLeftovers = from textile in db.Textiles.ToList()
                                  join us in db.TextileStocks.ToList() on textile.Id equals us.IdTextile
                                  select new
                                  {
                                      Артикул = textile.Id,
                                      Название = textile.Name,
                                      Длина = textile.Lenght,
                                      Ширина = textile.Width,
                                      Остатки = us.Count,
                                  };
                dgLeftovers.ItemsSource = tbLeftovers.ToList();
            }
            else
            {
                var tbLeftovers = from accessories in db.Accessories.ToList()
                                  join us in db.AccessoriesStocks.ToList() on accessories.Id equals us.IdAccessories
                                  select new
                                  {
                                      Артикул = accessories.Id,
                                      Название = accessories.Name,
                                      Остатки = db.AccessoriesStocks.First(x => x.IdAccessories == accessories.Id).Count,
                                  };
                dgLeftovers.ItemsSource = tbLeftovers.ToList();
            }
        }
    }
}
