using System;
using System.Windows;
using System.Windows.Controls;

namespace Garment_Factory.Views
{
    /// <summary>
    /// Логика взаимодействия для ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        public ManagerPage()
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

        private void btnToOrderList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Uri(@"Views\OrderListPage.xaml", UriKind.Relative));
            Window.GetWindow(this).Title = "Список заказов";
        }

        private void btnToProductList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Uri(@"Views\ProductListPage.xaml", UriKind.Relative));
            Window.GetWindow(this).Title = "Список изделий";
        }

        private void btnToCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Uri(@"Views\CreateOrderPage.xaml", UriKind.Relative));
            Window.GetWindow(this).Title = "Формирование заказа";
        }

        private void btnToCreateProduct_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Uri(@"Views\ProductManufacturingPage.xaml", UriKind.Relative));
            Window.GetWindow(this).Title = "Производство изделия";
        }

        private void btnToCostEstimate_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Uri(@"Views\CostEstimatePage.xaml", UriKind.Relative));
            Window.GetWindow(this).Title = "Оценка затрат";
        }
    }
}
