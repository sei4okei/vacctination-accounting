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
        private Data.Models.PatientReception reception;
        private Data.Models.Patient patient;

        public Add(Data.Models.View _reception)
        {
            InitializeComponent();

            if (_reception != null)
            {
                using (VacctinationAccountingDb db = new VacctinationAccountingDb())
                {
                    reception = db.PatientReception.Single(r => r.Id == _reception.Id);

                    patient = db.Patient.Single(p => p.Id == reception.PatientId);
                }
            }

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
                        PatientFrame.Navigate(new AddTabs.Patient(db.Patient.Single(p => p.Id == reception.PatientId)));
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
                        EmployeeFrame.Navigate(new AddTabs.Employee(db.Employee.Single(employee => employee.Id == reception.EmployeeId)));
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
                        VaccineFrame.Navigate(new AddTabs.Drug(db.Drug.Single(drug => drug.Id == reception.DrugId)));
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
                    RegionFrame.Navigate(new AddTabs.Region(db.Region.Single(region => region.Id == patient.RegionId)));
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
                    try
                    {
                        ReceiptionFrame.Navigate(new AddTabs.PatientReception(db.PatientReception.Single(r => r.Id == reception.Id)));
                    }
                    catch (Exception)
                    {
                        ReceiptionFrame.Navigate(new AddTabs.PatientReception(null));
                    };
                }
            }
        }
    }
}
