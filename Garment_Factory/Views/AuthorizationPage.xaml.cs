using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Garment_Factory.Models.db;

namespace Garment_Factory.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin != null && pbPassword != null)
            {
                using (GarmentFactoryContext db = new GarmentFactoryContext())
                {
                    User user = db.Users.FirstOrDefault(x => x.Login == tbLogin.Text)!;
                    if (user == null)
                        MessageBox.Show("Пользователя с таким логином не существует!");
                    else
                    {
                        if (user.Password == pbPassword.Password.ToString())
                        {
                            UserNow.Login = user.Login;
                            UserNow.Name = user.Name;
                            UserNow.Role = user.Role;

                            WorkWindow workwindow = new WorkWindow();
                            workwindow.Show();

                            switch (user.Role)
                            {
                                case "Заказчик":
                                    workwindow.MainFrame.NavigationService.Navigate(new Uri(@"Views\CastomerPage.xaml", UriKind.Relative));
                                    break;
                                case "Кладовщик":
                                    workwindow.MainFrame.NavigationService.Navigate(new Uri(@"Views\StorekeeperPage.xaml", UriKind.Relative));
                                    break;
                                case "Менеджер":
                                    workwindow.MainFrame.NavigationService.Navigate(new Uri(@"Views\ManagerPage.xaml", UriKind.Relative));
                                    break;
                                case "Директор":
                                    workwindow.MainFrame.NavigationService.Navigate(new Uri(@"Views\DirectorPage.xaml", UriKind.Relative));
                                    break;
                            }

                            Window.GetWindow(this).Close();
                        }
                        else
                        {
                            MessageBox.Show("Неверный пароль!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните поля!");
            }
        }

        private void btnToRegistr_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Title = "Регистрация";
            this.NavigationService.Navigate(new Uri(@"Views\RegistrationPage.xaml", UriKind.Relative));
        }

        private void cbChangeMode_Click(object sender, RoutedEventArgs e)
        {
            if (cbChangeMode.IsChecked.Value)
            {
                tbPassword.Text = pbPassword.Password; 
                tbPassword.Visibility = Visibility.Visible; 
                pbPassword.Visibility = Visibility.Hidden; 
            }
            else
            {
                pbPassword.Password = tbPassword.Text; 
                tbPassword.Visibility = Visibility.Hidden; 
                pbPassword.Visibility = Visibility.Visible;
            }
        }

        private void tbPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            pbPassword.Password = tbPassword.Text;
        }
    }
}
