using Garment_Factory.Models.db;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;

namespace Garment_Factory.Views
{
    /// <summary>
    /// Логика взаимодействия для CostEstimatePage.xaml
    /// </summary>
    public partial class CostEstimatePage : Page
    {
        public CostEstimatePage()
        {
            InitializeComponent();
        }

        private void btnEstimate_Click(object sender, RoutedEventArgs e)
        {
            tbAbout.Text = "";
            bool flag = false;
            int countProductFail = 0;
            using (GarmentFactoryContext db = new GarmentFactoryContext())
            {
                if (cb.SelectedIndex == 0)
                {
                    var productOrder = db.ProductOrders.Where(x => x.IdOrder == Convert.ToInt32(tbId.Text)).ToList();
                    foreach (var item in productOrder)
                    {
                        bool flagA = false;
                        Product product = db.Products.Include(x => x.IdTextiles).First(x => x.Id == item.IdProduct);
                        tbAbout.Text += $"Для изделия '{product.Name}' требуется: \n";

                        var textiles = product.IdTextiles.ToList();
                        if (textiles.Count == 0)
                        {
                            tbAbout.Text += "- \n";
                            continue;
                        }

                        foreach (var textile in textiles)
                        {
                            double square = Convert.ToDouble(textile.Width * textile.Lenght);
                            tbAbout.Text += $"Ткань '{textile.Name}' Площадь: {square}см^2";
                            var t = db.TextileStocks.First(x => x.IdTextile == textile.Id);
                            double squareInStok = t.Lenght * t.Width;

                            if (square <= squareInStok)
                            {
                                tbAbout.Text += " (На складе хватает)";
                            }
                            else
                            {
                                tbAbout.Text += $" (Не хватает: {squareInStok - square}см^2)";
                                flagA = true;
                            }
                            tbAbout.Text += "\n";
                        }
                        if (flagA)
                            countProductFail++;
                    }
                }
                else
                {
                    var productOrder = db.ProductOrders.Where(x => x.IdOrder == Convert.ToInt32(tbId.Text)).ToList();
                    foreach (var item in productOrder)
                    {
                        bool flagA = false;
                        Product product = db.Products.First(x => x.Id == item.IdProduct);
                        tbAbout.Text += $"Для изделия '{product.Name}' требуется: \n";

                        var accessories = db.AccessoriesProducts.Where(x => x.IdProduct == item.IdProduct).ToList();
                        if (accessories.Count == 0)
                        {
                            tbAbout.Text += "- \n";
                            continue;
                        }
                        foreach (var accessory in accessories)
                        {
                            tbAbout.Text += $"Фурнитура '{db.Accessories.First(x => x.Id == accessory.IdAccessories).Name}' Количество: {accessory.Count}";
                            int quantityInStock = db.AccessoriesStocks.First(x => x.IdAccessories == accessory.IdAccessories).Count;
                            if (accessory.Count < quantityInStock)
                            {
                                tbAbout.Text += " (На складе хватает)";
                            }
                            else
                            {
                                tbAbout.Text += $" (Не хватает: {accessory.Count - quantityInStock}шт)";
                                flagA = true;
                            }
                            tbAbout.Text += "\n";
                        }
                        if (flagA)
                            countProductFail++;
                    }
                }
            }
            if (flag)
                tbAbout.Text += $"Не может быть произведенно {countProductFail} изделий";
        }
    }
}
