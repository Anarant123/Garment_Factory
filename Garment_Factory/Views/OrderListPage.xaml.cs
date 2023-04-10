using Garment_Factory.Models.db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Garment_Factory.Views
{
    /// <summary>
    /// Логика взаимодействия для OrderListPage.xaml
    /// </summary>
    public partial class OrderListPage : Page
    {
        GarmentFactoryContext db = new GarmentFactoryContext();
        public OrderListPage()
        {
            InitializeComponent();

            var tbOrders = from zak in db.Orders.ToList()
                           join us in db.Users on zak.Customer equals us.Login
                           where zak.Manager == UserNow.Login || zak.Manager == "Empty"
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

        private void btnToOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderNow.IdOrder = Convert.ToInt32(tbId.Text);
            Order order = db.Orders.First(x => x.Id == OrderNow.IdOrder);
            if (order.Status == "Новый")
                order.Status = "Обработка";
            order.Manager = UserNow.Login;
            db.SaveChanges();
            this.NavigationService.Navigate(new Uri(@"Views\OrderPage.xaml", UriKind.Relative));
            Window.GetWindow(this).Title = "Заказ";
        }
    }
}
