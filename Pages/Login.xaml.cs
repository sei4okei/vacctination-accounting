using courseproject.Data;
using courseproject.Data.Models;
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

namespace courseproject.Pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string Login = LoginTextBox.Text;
            string Password = PasswordBox.Password;

            if (isInputValid(Login, Password))
            {
                NavigationManager.MainFrame.Navigate(new View());
                NavigationManager.SideMenuFrame.Navigate(new SideMenu());
            }
            else
            {
                ShowMessageBox();
            }
        }

        private bool isInputValid(string Login, string Password)
        {
            using (VacctinationAccountingDb db = new VacctinationAccountingDb())
            {
                try
                {
                    List<Account> account = db.Account.Where(o => o.Login == Login).ToList();

                    if (account[0].Password != Password)
                    {
                        return false;
                    }

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        private void ShowMessageBox()
        {
            MessageBox.Show("Неверно введены данные", "Ошибка ввода",
                MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
