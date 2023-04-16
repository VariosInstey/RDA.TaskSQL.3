using RDA.TaskSQL._3.Core;
using RDA.TaskSQL._3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RDA.TaskSQL._3.View
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            CoreDB.CoreFrame.Navigate(new RegPage());
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLogin.Text) ||
                string.IsNullOrEmpty(PbPassword.Password))
            {
                MessageBox.Show("Ошибка ввода данных",
                        "Системное сообщение",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    Users userModel = CoreDB.DB.Users.FirstOrDefault(u => u.login == TbLogin.Text && u.password == PbPassword.Password);
                    if (userModel != null)
                    {
                        MessageBox.Show($"{userModel.login}- успешный вход!",
                        "Системное сообщение",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка ввода данных",
                        "Системное сообщение",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(),
                        "Системное сообщение",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }
    }
}
