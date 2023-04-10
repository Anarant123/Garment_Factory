using Garment_Factory.Models.db;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Garment_Factory.Views
{
    /// <summary>
    /// Логика взаимодействия для ProductManufacturingPage.xaml
    /// </summary>
    public partial class ProductManufacturingPage : Page
    {
        GarmentFactoryContext db = new GarmentFactoryContext();
        public ProductManufacturingPage()
        {
            InitializeComponent();
        }

        private void btnGetPrice_Click(object sender, RoutedEventArgs e)
        {
            if (tbIdTextile.Text != "" && tbIdAccessories.Text != "" && tbLenght.Text != "" && tbWidth.Text != "" && tbCountAccessories.Text != "")
            {
                Textile textile = db.Textiles.First(x => x.Id == Convert.ToInt32(tbIdTextile.Text));
                Accessory accessory = db.Accessories.First(x => x.Id == tbIdAccessories.Text);
                double squareTextile = Convert.ToDouble(textile.Width * textile.Lenght);
                double squareTextileProduct = Convert.ToDouble(Convert.ToInt32(tbWidth.Text) * Convert.ToInt32(tbLenght.Text));
                double priceS = squareTextile / textile.Price;
                double priceSProduct = squareTextileProduct * priceS;
                double priceA = Convert.ToInt32(tbCountAccessories.Text) * accessory.Price;
                tbPrice.Text = (priceS + priceA).ToString();
            }

        }

        private void btnToPrint_Click(object sender, RoutedEventArgs e)
        {
            string doc = $"Артикул ткани: {tbIdTextile.Text}\n" +
                $"Ширина ткани: {tbWidth.Text}\n" +
                $"Длина ткани: {tbLenght.Text}\n" +
                $"Артикул фурнитуры: {tbIdAccessories.Text}\n" +
                $"Количество фурнитурытуры: {tbCountAccessories.Text}\n" +
                $"Итоговая стоимость изделия: {tbPrice.Text}";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".txt";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, doc, Encoding.UTF8);
        }
    }
}
