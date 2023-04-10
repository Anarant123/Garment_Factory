using Garment_Factory.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Garment_Factory.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateOrderPage.xaml
    /// </summary>
    public partial class CreateOrderPage : Page
    {
        GarmentFactoryContext db = new GarmentFactoryContext();
        List<ProductOrder> list = new List<ProductOrder>();
        public CreateOrderPage()
        {
            InitializeComponent();
        }

        private void btnAddToOrder_Click(object sender, RoutedEventArgs e)
        {
            if (tbId.Text != "" && tbCount.Text != "" && db.Products.First(x => x.Id == Convert.ToInt32(tbId.Text)) != null)
            {
                int id = Convert.ToInt32(tbId.Text);
                int count = Convert.ToInt32(tbCount.Text);
                ProductOrder productOrder = new ProductOrder();
                productOrder.IdProduct = id;
                productOrder.Count = count;
                productOrder.IdOrder = db.Orders.Max(x => x.Id) + 1;
                productOrder.Name = db.Products.First(x => x.Id == Convert.ToInt32(tbId.Text)).Name;

                list.Add(productOrder);

                tbFullOrder.Text += $"Артикул: {productOrder.IdProduct} Количество: {productOrder.Count} Название: {productOrder.Name}\n";

            }
            else
                MessageBox.Show("Такого артикула не существует, либо вы не заполнили все поля.");
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = new Order();
                order.Id = db.Orders.Max(x => x.Id) + 1;
                order.Status = "Новый";
                order.Date = DateTime.Now;
                order.Customer = UserNow.Login;
                if (UserNow.Role == "Менеджер")
                    order.Manager = UserNow.Login;
                else
                    order.Manager = "Empty";

                order.Price = 0;

                db.Orders.Add(order);

                foreach (var item in list)
                {
                    db.ProductOrders.Add(item);
                }
                db.SaveChanges();

                MessageBox.Show("Заказ уже в обработке.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
