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
    /// Логика взаимодействия для Patient.xaml
    /// </summary>
    public partial class Patient : Page
    {
        public Patient()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            VacctinationAccountingDb db = new VacctinationAccountingDb();

            try
            {
                if (PatientFirstNameTextBox.Text != null && PatientLastNameTextBox.Text != null && PatientMiddleNameTextBox.Text != null
                    && PatientCityTextBox.Text != null && PatientRegionComboBox.SelectedItem != null
                    && PatientInsurancePolicyTextBox.Text.Length == 9 && PatientDatePicker.SelectedDate != null)
                {
                    db.Patient.Add(new Data.Models.Patient
                    {
                        FirstName = PatientFirstNameTextBox.Text,
                        LastName = PatientLastNameTextBox.Text,
                        MiddleName = PatientMiddleNameTextBox.Text,
                        DateBirth = PatientDatePicker.SelectedDate.Value,
                        Registration = PatientCityTextBox.Text,
                        RegionId = Convert.ToInt32(PatientRegionComboBox.SelectedValue),
                        InsurancePolicy = PatientInsurancePolicyTextBox.Text
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
            PatientFirstNameTextBox.Clear();
            PatientLastNameTextBox.Clear();
            PatientMiddleNameTextBox.Clear();
            PatientDatePicker.SelectedDate = null;
            PatientCityTextBox.Clear();
            PatientRegionComboBox.SelectedValue = null;
            PatientInsurancePolicyTextBox.Clear();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            VacctinationAccountingDb db = new VacctinationAccountingDb();

            var list = db.Region.Select(x => x.Id).ToList();

            PatientRegionComboBox.ItemsSource = list;
        }
    }
}
