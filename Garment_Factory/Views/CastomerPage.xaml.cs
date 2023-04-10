using System;
using System.Windows;
using System.Windows.Controls;

namespace Garment_Factory.Views
{
    /// <summary>
    /// Логика взаимодействия для CastomerPage.xaml
    /// </summary>
    public partial class CastomerPage : Page
    {
        public CastomerPage()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new Uri(@"Views\ProductListPage.xaml", UriKind.Relative));
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            Window.GetWindow(this).Close();
        }

        private void btnToCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Uri(@"Views\CreateOrderPage.xaml", UriKind.Relative));
        }

        private void btnToProductList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Uri(@"Views\ProductListPage.xaml", UriKind.Relative));
        }
    }
}
