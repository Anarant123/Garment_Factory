using Garment_Factory.Models.db;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Garment_Factory.Views
{
    /// <summary>
    /// Логика взаимодействия для ProductMovementPage.xaml
    /// </summary>
    public partial class ProductMovementPage : Page
    {
        GarmentFactoryContext db = new GarmentFactoryContext();
        public ProductMovementPage()
        {
            InitializeComponent();

            var tbOrders = from zak in db.Orders.ToList()
                           join us in db.Users on zak.Customer equals us.Login
                           select new
                           {
                               Номер = zak.Id,
                               Дата = zak.Date,
                               Статус = zak.Status,
                               Заказчик = us.Name,
                               Количество = db.ProductOrders.Where(x => x.IdOrder == zak.Id).Select(x => x.Count).Sum(),
                               Менеджер = db.Users.FirstOrDefault(x => x.Login == zak.Manager).Name
                           };
            dgOrders.ItemsSource = tbOrders.ToList();

            cbFrom.ItemsSource = db.Orders.Select(x => x.Date).Distinct().ToList();
            cbTo.ItemsSource = db.Orders.Select(x => x.Date).Distinct().ToList();
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            //ComboBoxItem typeItem = (ComboBoxItem)cbFrom.SelectedItem;
            //string v1 = typeItem.Content.ToString();
            //typeItem = (ComboBoxItem)cbTo.SelectedItem;
            //string v2 = typeItem.Content.ToString();

            var tbOrders = from zak in db.Orders.ToList()
                           join us in db.Users on zak.Customer equals us.Login
                           where zak.Date >= Convert.ToDateTime(cbFrom.SelectedItem.ToString()) && zak.Date <= Convert.ToDateTime(cbTo.SelectedItem.ToString())
                           select new
                           {
                               Номер = zak.Id,
                               Дата = zak.Date,
                               Статус = zak.Status,
                               Заказчик = us.Name,
                               Количество = db.ProductOrders.Where(x => x.IdOrder == zak.Id).Select(x => x.Count).Sum(),
                               Менеджер = db.Users.FirstOrDefault(x => x.Login == zak.Manager).Name
                           };
            dgOrders.ItemsSource = tbOrders.ToList();
        }
    }
}
