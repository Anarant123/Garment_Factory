using Garment_Factory.Models.db;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Garment_Factory.Views
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        GarmentFactoryContext db = new GarmentFactoryContext();
        public OrderPage()
        {
            InitializeComponent();
            foreach (var item in db.ProductOrders.Where(x => x.IdOrder == OrderNow.IdOrder))
            {
                tbFullOrder.Text += $"Артикул: {item.IdProduct} Количество: {item.Count} Название: {item.Name}\n";
            }
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            Order order = db.Orders.First(x => x.Id == OrderNow.IdOrder);
            order.Status = "К оплате";
            db.SaveChanges();
            MessageBox.Show("Заказ успешно принят");
        }

        private void btnDeleteFromOrder_Click(object sender, RoutedEventArgs e)
        {
            ProductOrder po = db.ProductOrders.First(x => x.IdProduct == Convert.ToInt32(tbId.Text));
            db.ProductOrders.Remove(po);
            db.SaveChanges();
            MessageBox.Show("Позиция заказа удаленна");
            tbFullOrder.Text = "";
            foreach (var item in db.ProductOrders.Where(x => x.IdOrder == OrderNow.IdOrder))
            {
                tbFullOrder.Text += $"Артикул: {item.IdProduct} Количество: {item.Count} Название: {item.Name}\n";
            }
        }

        private void btnReject_Click(object sender, RoutedEventArgs e)
        {
            Order order = db.Orders.First(x => x.Id == OrderNow.IdOrder);
            order.Status = "Отклонен";
            db.SaveChanges();
            MessageBox.Show("Заказ успешно отклонен");
        }
    }
}
