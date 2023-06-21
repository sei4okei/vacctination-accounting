using courseproject.Data;
using courseproject.Data.Models;
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
        private Data.Models.View reception;

        public Add(Data.Models.View _reception)
        {
            InitializeComponent();

            reception = _reception;
        }


        private void PatientFrame_Loaded(object sender, RoutedEventArgs e)
        {
            if (reception == null)
            {
                PatientFrame.Navigate(new AddTabs.Patient(null));
            }
            else
            {
                try
                {
                    using (VacctinationAccountingDb db = new VacctinationAccountingDb())
                    {
                        PatientFrame.Navigate(new AddTabs.Patient(db.Patient.Where(patient => (patient.LastName + " " + patient.FirstName + " " + patient.MiddleName) == reception.AllName).ToList()[0]));
                    }
                }
                catch (Exception)
                {
                    PatientFrame.Navigate(new AddTabs.Patient(null));
                }
            }
        }

        private void EmployeeFrame_Loaded(object sender, RoutedEventArgs e)
        {
            if (reception == null)
            {
                EmployeeFrame.Navigate(new AddTabs.Employee(null));
            }
            else
            {
                try
                {
                    using (VacctinationAccountingDb db = new VacctinationAccountingDb())
                    {
                        EmployeeFrame.Navigate(new AddTabs.Employee(db.Employee.Where(employee => (employee.SecondName + " " + employee.FirstName.Substring(0, 1) + "." + employee.MiddleName.Substring(0, 1) + ".") == reception.DoctorAllName).ToList()[0]));
                    }
                }
                catch (Exception)
                {
                    EmployeeFrame.Navigate(new AddTabs.Employee(null));
                }
            }
        }

        private void AccountFrame_Loaded(object sender, RoutedEventArgs e)
        {
            if (reception != null) AccountTab.Visibility = Visibility.Hidden;
            else AccountFrame.Navigate(new AddTabs.Account());
        }

        private void VaccineFrame_Loaded(object sender, RoutedEventArgs e)
        {
            if (reception == null)
            {
                VaccineFrame.Navigate(new AddTabs.Drug(null));
            }
            else
            {
                try
                {
                    using (VacctinationAccountingDb db = new VacctinationAccountingDb())
                    {
                        VaccineFrame.Navigate(new AddTabs.Drug(db.Drug.Where(drug => drug.Name == reception.DrugName).ToList()[0]));
                    }
                }
                catch (Exception)
                {
                    VaccineFrame.Navigate(new AddTabs.Drug(null));
                }
            }
        }

        private void RegionFrame_Loaded(object sender, RoutedEventArgs e)
        {
            if (reception == null)
            {
                RegionFrame.Navigate(new AddTabs.Region(null));
            }
            else
            {
                using (VacctinationAccountingDb db = new VacctinationAccountingDb())
                {
                    RegionFrame.Navigate(new AddTabs.Region(db.Region.Where(region => region.Id == reception.Region).ToList()[0]));
                }
            }
        }

        private void ReceiptionFrame_Loaded(object sender, RoutedEventArgs e)
        {
            if (reception == null)
            {
                ReceiptionFrame.Navigate(new AddTabs.PatientReception(null));
            }
            else
            {
                using (VacctinationAccountingDb db = new VacctinationAccountingDb())
                {
                    ReceiptionFrame.Navigate(new AddTabs.PatientReception(db.PatientReception.Where(pr => pr.Id == reception.Id).ToList()[0]));
                }
            }
        }
    }
}
