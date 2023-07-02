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
    /// Логика взаимодействия для Patient.xaml
    /// </summary>
    public partial class Patient : Page
    {
        Data.Models.Patient patient;

        public Patient(Data.Models.Patient _patient)
        {
            InitializeComponent();

            patient = _patient;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            VacctinationAccountingDb db = new VacctinationAccountingDb();

            try
            {
                if (PatientFirstNameTextBox.Text == null && PatientLastNameTextBox.Text == null && PatientMiddleNameTextBox.Text == null
                    && PatientCityTextBox.Text == null && PatientRegionComboBox.SelectedItem == null
                    && PatientInsurancePolicyTextBox.Text.Length != 9 && PatientDatePicker.SelectedDate == null)
                {
                    MessageBox.Show("Данные ввдены неверно, попробуйте снова!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (patient != null)
                {
                    patient = GetUserInput(patient);

                    db.Patient.Update(patient);

                    db.SaveChanges();

                    MessageBox.Show("Данные обновлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    db.Patient.Add(GetUserInput(new Data.Models.Patient()));

                    db.SaveChanges();

                    MessageBox.Show("Данные сохранены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Данные ввдены неверно, попробуйте снова!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private Data.Models.Patient GetUserInput(Data.Models.Patient p)
        {
            p.FirstName = PatientFirstNameTextBox.Text;
            p.LastName = PatientLastNameTextBox.Text;
            p.MiddleName = PatientMiddleNameTextBox.Text;
            p.DateBirth = PatientDatePicker.SelectedDate.Value;
            p.Registration = PatientCityTextBox.Text;
            p.RegionId = Convert.ToInt32(PatientRegionComboBox.SelectedValue);
            p.InsurancePolicy = PatientInsurancePolicyTextBox.Text;

            return p;
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

            patient = null;
        }

        private void FillFields(Data.Models.Patient patient)
        {
            PatientFirstNameTextBox.Text = patient.FirstName;
            PatientLastNameTextBox.Text = patient.LastName;
            PatientMiddleNameTextBox.Text = patient.MiddleName;
            PatientDatePicker.SelectedDate = patient.DateBirth;
            PatientCityTextBox.Text = patient.Registration;
            PatientRegionComboBox.SelectedItem = patient.RegionId;
            PatientInsurancePolicyTextBox.Text = patient.InsurancePolicy;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            VacctinationAccountingDb db = new VacctinationAccountingDb();

            var list = db.Region.Select(x => x.Id).ToList();

            PatientRegionComboBox.ItemsSource = list;

            if (patient != null) FillFields(patient);
            else DeleteButton.Visibility = Visibility.Hidden;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (patient == null) return;
            using (VacctinationAccountingDb db = new VacctinationAccountingDb())
            {
                try
                {
                    db.Patient.Remove(patient);

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
