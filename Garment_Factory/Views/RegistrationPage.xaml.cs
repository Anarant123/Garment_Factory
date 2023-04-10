using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Garment_Factory.Models.db;

namespace Garment_Factory.Views
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        private void btnToRegistr_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text != "" && tbName.Text != "" && tbPassword1.Text != "" && pbPassword1.Password == pbPassword2.Password) 
            {
                using (GarmentFactoryContext db = new GarmentFactoryContext())
                {
                    if (db.Users.FirstOrDefault(x => x.Login == tbLogin.Text) == null)
                    {
                        User user = new User();
                        user.Name = tbName.Text;
                        user.Login = tbLogin.Text;
                        user.Password = pbPassword1.Password.ToString();
                        user.Role = "Заказчик";
                        db.Users.Add(user);
                        db.SaveChanges();


                        Window.GetWindow(this).Title = "Авторизация";
                        this.NavigationService.Navigate(new Uri(@"Views\AuthorizationPage.xaml", UriKind.Relative));
                    }
                    else
                    {
                        MessageBox.Show("Данный логин уже занят!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }

        private void cbChangeMode_Click(object sender, RoutedEventArgs e)
        {
            if (cbChangeMode.IsChecked.Value)
            {
                tbPassword1.Text = pbPassword1.Password; 
                tbPassword1.Visibility = Visibility.Visible; 
                pbPassword1.Visibility = Visibility.Hidden; 
                tbPassword2.Text = pbPassword2.Password; 
                tbPassword2.Visibility = Visibility.Visible; 
                pbPassword2.Visibility = Visibility.Hidden;
            }
            else
            {
                pbPassword1.Password = tbPassword1.Text; 
                tbPassword1.Visibility = Visibility.Hidden; 
                pbPassword1.Visibility = Visibility.Visible; 
                pbPassword2.Password = tbPassword2.Text; 
                tbPassword2.Visibility = Visibility.Hidden;
                pbPassword2.Visibility = Visibility.Visible;
            }
        }

        private void btnToBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri(@"Views\AuthorizationPage.xaml", UriKind.Relative));
        }

        private void tbPassword1_TextChanged(object sender, TextChangedEventArgs e)
        {
            pbPassword1.Password = tbPassword1.Text;
        }

        private void tbPassword2_TextChanged(object sender, TextChangedEventArgs e)
        {
            pbPassword2.Password = tbPassword2.Text;
        }
    }
}
