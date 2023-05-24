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
    /// Логика взаимодействия для Employee.xaml
    /// </summary>
    public partial class Employee : Page
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            VacctinationAccountingDb db = new VacctinationAccountingDb();

            try
            {
                if (FirstNameTextBox.Text != null && LastNameTextBox.Text != null && MiddleNameTextBox.Text != null
                    && PostComboBox.SelectedItem != null)
                {
                    db.Employee.Add(new Data.Models.Employee
                    {
                        FirstName = FirstNameTextBox.Text,
                        SecondName = LastNameTextBox.Text,
                        MiddleName = MiddleNameTextBox.Text,
                        Post = PostComboBox.SelectedValue.ToString()
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
            FirstNameTextBox.Clear();
            LastNameTextBox.Clear();
            MiddleNameTextBox.Clear();
            PostComboBox.SelectedValue = null;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PostComboBox.ItemsSource = new List<string>() { "Doctor", "Admin" };
        }
    }
}
