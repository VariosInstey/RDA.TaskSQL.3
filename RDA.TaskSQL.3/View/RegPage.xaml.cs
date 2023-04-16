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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
            CbRole.ItemsSource = CoreDB.DB.Role.ToList();
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            CoreDB.CoreFrame.Navigate(new LoginPage());
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
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
                    CoreDB.DB.Users.Add(new Users()
                    {
                        login = TbLogin.Text,
                        password = PbPassword.Password,
                        RoleID = Convert.ToInt32(CbRole.Text)
                    });
                    CoreDB.DB.SaveChanges();
                    MessageBox.Show("Учетная запись создана",
                        "Системное сообщение",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    CoreDB.CoreFrame.Navigate(new LoginPage());
                }
                catch(Exception ex)
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
