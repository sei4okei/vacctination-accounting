using courseproject.Data;
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

namespace courseproject.Pages.AddTabs
{
    /// <summary>
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        public Account()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            VacctinationAccountingDb db = new VacctinationAccountingDb();

            try
            {
                if (LoginTextBox.Text != null && PasswordBox.Password != null && ConfirmPasswordBox.Password != null
                    && RightsComboBox.SelectedItem != null && PasswordBox.Password == ConfirmPasswordBox.Password)
                {
                    db.Account.Add(new Data.Models.Account
                    {
                        Login = LoginTextBox.Text,
                        Password = ConfirmPasswordBox.Password,
                        Rights = RightsComboBox.SelectedItem.ToString(),
                        EmployeeId = db.Employee.First(x => x.SecondName + " " + x.FirstName + " " + x.MiddleName == EmployeeComboBox.SelectedItem.ToString()).Id,
                    });

                    db.SaveChanges();

                    ClearInput();

                    MessageBox.Show("Данные сохранены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Данные ввдены неверно, попробуйте снова!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Данные ввдены неверно, попробуйте снова!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearInput()
        {
            LoginTextBox.Clear();
            PasswordBox.Clear();
            ConfirmPasswordBox.Clear();
            RightsComboBox.SelectedValue = null;
            EmployeeComboBox.SelectedValue = null;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RightsComboBox.ItemsSource = new List<string>() { "doctor", "admin" };
            using (VacctinationAccountingDb db = new VacctinationAccountingDb())
            {
                List<string> list = db.Employee.Select(x => x.SecondName + " " + x.FirstName + " " + x.MiddleName).ToList();
                EmployeeComboBox.ItemsSource = list;
            }
        }
    }
}
