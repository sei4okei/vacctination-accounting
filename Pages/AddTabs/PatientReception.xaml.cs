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
    /// Логика взаимодействия для PatientReception.xaml
    /// </summary>
    public partial class PatientReception : Page
    {
        Data.Models.PatientReception reception;

        public PatientReception(Data.Models.PatientReception _reception)
        {
            InitializeComponent();
            reception = _reception;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            VacctinationAccountingDb db = new VacctinationAccountingDb();

            try
            {
                if (EmployeeComboBox.SelectedItem == null && PatientComboBox.SelectedItem == null && ReceptionDatePicker.SelectedDate == null 
                    && DrugComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Данные ввдены неверно, попробуйте снова!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (reception != null)
                {
                    reception = GetUserInput(reception);

                    db.PatientReception.Update(reception);

                    db.SaveChanges();

                    MessageBox.Show("Данные обновлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    db.PatientReception.Add(GetUserInput(new Data.Models.PatientReception()));

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
            PatientComboBox.SelectedValue = null;
            DrugComboBox.SelectedValue = null;
            EmployeeComboBox.SelectedValue = null;
            ReceptionDatePicker.SelectedDate = null;
        }

        private void FillFields(Data.Models.PatientReception pr)
        {
            using (VacctinationAccountingDb db = new VacctinationAccountingDb())
            {
                Data.Models.Patient patient = db.Patient.Single(x => x.Id == pr.PatientId);
                Data.Models.Employee employee = db.Employee.Single(x => x.Id == pr.EmployeeId);

                PatientComboBox.SelectedValue = patient.LastName + " " + patient.FirstName + " " + patient.MiddleName;
                EmployeeComboBox.SelectedValue = employee.SecondName + " " + employee.FirstName + " " + employee.MiddleName;
                DrugComboBox.SelectedValue = db.Drug.Single(x => x.Id == pr.DrugId).Name;
                ReceptionDatePicker.SelectedDate = pr.Date;
            } 
        }

        private Data.Models.PatientReception GetUserInput(Data.Models.PatientReception pr)
        {
            using (VacctinationAccountingDb db = new VacctinationAccountingDb())
            {
                pr.DrugId = db.Drug.Single(x => x.Name == DrugComboBox.SelectedValue.ToString()).Id;
                pr.EmployeeId = db.Employee.Single(x => x.SecondName + " " + x.FirstName + " " + x.MiddleName == EmployeeComboBox.SelectedItem.ToString()).Id;
                pr.PatientId = db.Patient.Single(x => x.LastName + " " + x.FirstName + " " + x.MiddleName == PatientComboBox.SelectedValue.ToString()).Id;
                pr.Date = ReceptionDatePicker.SelectedDate.Value;
            }

            return pr;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (VacctinationAccountingDb db = new VacctinationAccountingDb())
            {
                List<string> employee = db.Employee.Select(x => x.SecondName + " " + x.FirstName + " " + x.MiddleName).ToList();
                EmployeeComboBox.ItemsSource = employee;

                List<string> patient = db.Patient.Select(x => x.LastName + " " + x.FirstName + " " + x.MiddleName).ToList();
                PatientComboBox.ItemsSource = patient;

                List<string> drug = db.Drug.Select(x => x.Name).ToList();
                DrugComboBox.ItemsSource = drug;
            }

            if (reception != null) FillFields(reception);
            else DeleteButton.Visibility = Visibility.Hidden;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (reception == null) return;
            using (VacctinationAccountingDb db = new VacctinationAccountingDb())
            {
                try
                {
                    db.PatientReception.Remove(reception);

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
