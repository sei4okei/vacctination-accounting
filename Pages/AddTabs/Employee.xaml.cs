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

namespace courseproject.Pages.AddTabs
{
    /// <summary>
    /// Логика взаимодействия для Employee.xaml
    /// </summary>
    public partial class Employee : Page
    {
        Data.Models.Employee employee;

        public Employee(Data.Models.Employee _employee )
        {
            InitializeComponent();

            employee = _employee;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            VacctinationAccountingDb db = new VacctinationAccountingDb();

            try
            {
                if (FirstNameTextBox.Text == null && MiddleNameTextBox.Text == null && LastNameTextBox.Text == null
                    && PostComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Данные ввдены неверно, попробуйте снова!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (employee != null)
                {
                    employee = GetUserInput(employee);

                    db.Employee.Update(employee);

                    db.SaveChanges();

                    MessageBox.Show("Данные обновлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    db.Employee.Add(GetUserInput(new Data.Models.Employee()));

                    db.SaveChanges();

                    MessageBox.Show("Данные сохранены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private Data.Models.Employee GetUserInput(Data.Models.Employee p)
        {
            p.FirstName = FirstNameTextBox.Text;
            p.SecondName = LastNameTextBox.Text;
            p.MiddleName = MiddleNameTextBox.Text;
            p.Post = PostComboBox.SelectedValue.ToString();

            return p;
        }

        private void FillFields(Data.Models.Employee e)
        {
            FirstNameTextBox.Text = e.FirstName;
            LastNameTextBox.Text = e.SecondName;
            MiddleNameTextBox.Text = e.MiddleName;
            PostComboBox.SelectedItem = e.Post;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PostComboBox.ItemsSource = new List<string>() { "Doctor", "Admin" };

            if (employee != null) FillFields(employee);
            else DeleteButton.Visibility = Visibility.Hidden;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (employee == null) return;
            using (VacctinationAccountingDb db = new VacctinationAccountingDb())
            {
                try
                {
                    db.Employee.Remove(employee);

                    db.SaveChanges();

                    ClearInput();

                    MessageBox.Show("Данные сохранены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Данные ввдены неверно, попробуйте снова!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
