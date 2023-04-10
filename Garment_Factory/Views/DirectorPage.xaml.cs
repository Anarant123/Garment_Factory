using System;
using System.Windows;
using System.Windows.Controls;

namespace Garment_Factory.Views
{
    /// <summary>
    /// Логика взаимодействия для DirectorPage.xaml
    /// </summary>
    public partial class DirectorPage : Page
    {
        public DirectorPage()
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

        private void btnToLeftovers_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Uri(@"Views\LeftoversPage.xaml", UriKind.Relative));
            Window.GetWindow(this).Title = "Остатки";
        }

        private void btnToMovement_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Uri(@"Views\ProductMovementPage.xaml", UriKind.Relative));
            Window.GetWindow(this).Title = "Движение материалов";
        }

        private void btnToProductList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Uri(@"Views\ProductListPage.xaml", UriKind.Relative));
        }
    }
}
