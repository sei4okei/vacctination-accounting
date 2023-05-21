using courseproject.Data;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        public Add()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            VacctinationAccountingDb db = new VacctinationAccountingDb();

            try
            {
                if (FirstNameTextBox.Text != null && LastNameTextBox.Text != null && MiddleNameTextBox.Text != null
                    && CityTextBox.Text != null && RegionComboBox.SelectedItem != null
                    && InsurancePolicyTextBox.Text.Length == 9 && DatePicker.SelectedDate != null)
                {
                    db.Patient.Add(new Data.Models.Patient
                    {
                        FirstName = FirstNameTextBox.Text,
                        LastName = LastNameTextBox.Text,
                        MiddleName = MiddleNameTextBox.Text,
                        DateBirth = DatePicker.SelectedDate.Value,
                        Registration = CityTextBox.Text,
                        RegionId = Convert.ToInt32(RegionComboBox.SelectedValue),
                        InsurancePolicy = InsurancePolicyTextBox.Text
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
            DatePicker.SelectedDate = null;
            CityTextBox.Clear();
            RegionComboBox.SelectedValue = null;
            InsurancePolicyTextBox.Clear();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            VacctinationAccountingDb db = new VacctinationAccountingDb();

            var list = db.Region.Select(x => x.Id).ToList();

            RegionComboBox.ItemsSource = list;
        }
    }
}
