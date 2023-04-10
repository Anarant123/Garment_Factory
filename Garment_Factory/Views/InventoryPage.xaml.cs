using Microsoft.Win32;
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Garment_Factory.Models.db;

namespace Garment_Factory.Views
{
    /// <summary>
    /// Логика взаимодействия для InventoryPage.xaml
    /// </summary>
    public partial class InventoryPage : Page
    {
        GarmentFactoryContext db = new GarmentFactoryContext();
        public InventoryPage()
        {
            InitializeComponent();
        }

        private void btnToPrint_Click(object sender, RoutedEventArgs e)
        {
            string doc = $"Артикул: {tbId.Text}\n" +
                $"Материал: {cb.Text}\n" +
                $"Количество по инвентаризации: {tbCountInventory.Text}\n" +
                $"Количество в системе: {tbCount.Text}\n" +
                $"Итог инвентаризации: {tbResult.Text}";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".txt";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, doc, Encoding.UTF8);
        }

        private void btnInventory_Click(object sender, RoutedEventArgs e)
        {
            int n;
            if (tbCountInventory.Text != "" && tbId.Text != "")
            {
                if (int.TryParse(tbCountInventory.Text, out n))
                {
                    if (cb.SelectedIndex == 0)
                    {
                        if (int.TryParse(tbId.Text, out n))
                        {
                            try
                            {
                                tbCount.Text = db.TextileStocks.FirstOrDefault(x => x.IdTextile == Convert.ToInt32(tbId.Text)).Count.ToString();
                            }
                            catch
                            {
                                tbCount.Text = "";
                            }
                        }
                        else
                            tbId.Text = tbCount.Text.TrimEnd();
                    }
                    else if (cb.SelectedIndex == 1)
                    {
                        try
                        {
                            tbCount.Text = db.AccessoriesStocks.FirstOrDefault(x => x.IdAccessories == tbId.Text).Count.ToString();
                        }
                        catch
                        {
                            tbCount.Text = "";
                        }
                    }

                    int countInventory = Convert.ToInt32(tbCountInventory.Text);
                    int count = Convert.ToInt32(tbCount.Text);

                    if (countInventory * 0.8 < count && count < countInventory * 1.2)
                    {
                        tbResult.Text = "Расхождение в норме";
                        var t = db.TextileStocks.FirstOrDefault(x => x.IdTextile == Convert.ToInt32(tbId.Text));
                        t.Count = countInventory;
                        db.SaveChanges();
                    }    
                    else
                        tbResult.Text = "Расхождение превышает 20%";

                }
                else
                    tbCount.Text = tbCount.Text.TrimEnd();
            }
        }
    }
}
