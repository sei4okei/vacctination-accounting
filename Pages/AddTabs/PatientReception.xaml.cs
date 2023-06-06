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
    /// Логика взаимодействия для PatientReception.xaml
    /// </summary>
    public partial class PatientReception : Page
    {
        public PatientReception()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            VacctinationAccountingDb db = new VacctinationAccountingDb();

            try
            {
                if (PatientComboBox.SelectedItem != null && DrugComboBox.SelectedItem != null && EmployeeComboBox.SelectedItem != null &&
                    ReceptionDatePicker.SelectedDate != null)
                {
                    db.PatientReception.Add(new Data.Models.PatientReception
                    {
                        PatientId = db.Patient.First(x => x.LastName + " " + x.FirstName + " " + x.MiddleName == PatientComboBox.SelectedItem.ToString()).Id,
                        DrugId = db.Drug.First(x => x.Name == DrugComboBox.SelectedItem.ToString()).Id,
                        EmployeeId = db.Employee.First(x => x.SecondName + " " + x.FirstName + " " + x.MiddleName == EmployeeComboBox.SelectedItem.ToString()).Id,
                        Date = ReceptionDatePicker.SelectedDate.Value
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
            PatientComboBox.SelectedValue = null;
            DrugComboBox.SelectedValue = null;
            EmployeeComboBox.SelectedValue = null;
            ReceptionDatePicker.SelectedDate = null;
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
        }
    }
}
