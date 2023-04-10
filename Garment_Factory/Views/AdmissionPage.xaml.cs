using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Garment_Factory.Views
{
    /// <summary>
    /// Логика взаимодействия для AdmissionPage.xaml
    /// </summary>
    public partial class AdmissionPage : Page
    {
        public AdmissionPage()
        {
            InitializeComponent();
        }

        private void btnToPrint_Click(object sender, RoutedEventArgs e)
        {
            string doc = $"Артикул: {tbId.Text}\n" +
                $"Материал: {cb.Text}\n" +
                $"Количество: {tbCount.Text}\n" +
                $"Закупочная цена: {tbPrice.Text}\n" +
                $"Сумма: {tbSum.Text}";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".txt";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, doc, Encoding.UTF8);
        }

        private void tbCount_TextChanged(object sender, TextChangedEventArgs e)
        {

            int n;
            if (tbPrice.Text != "" && tbCount.Text != "")
            {
                if (int.TryParse(tbCount.Text,out n))
                {
                    if (int.TryParse(tbPrice.Text, out n))
                    {
                            tbSum.Text = (Convert.ToInt32(tbPrice.Text) * Convert.ToInt32(tbCount.Text)).ToString();
                    }
                    else
                        tbPrice.Text = tbPrice.Text.TrimEnd();
                }
                else
                    tbCount.Text = tbCount.Text.TrimEnd();
            }
        }
    }
}
