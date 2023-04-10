using System;
using System.Windows;
using System.Windows.Controls;

namespace Garment_Factory.Views
{
    /// <summary>
    /// Логика взаимодействия для StorekeeperPage.xaml
    /// </summary>
    public partial class StorekeeperPage : Page
    {
        public StorekeeperPage()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new Uri(@"Views\TextileListPage.xaml", UriKind.Relative));
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            Window.GetWindow(this).Close();
        }

        private void btnOpenListTextile_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Uri(@"Views\TextileListPage.xaml", UriKind.Relative));
            Window.GetWindow(this).Title = "Список тканей";
        }

        private void btnOpenListAccessories_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Uri(@"Views\AccessoriesListPage.xaml", UriKind.Relative));
            Window.GetWindow(this).Title = "Список фурнитуры";
        }

        private void btnToAdmission_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Uri(@"Views\AdmissionPage.xaml", UriKind.Relative));
            Window.GetWindow(this).Title = "Поступление";
        }

        private void btnToInventory_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Uri(@"Views\InventoryPage.xaml", UriKind.Relative));
            Window.GetWindow(this).Title = "Инвентаризация";
        }
    }
}
