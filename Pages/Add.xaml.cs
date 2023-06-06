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


        private void PatientFrame_Loaded(object sender, RoutedEventArgs e)
        {
            PatientFrame.Navigate(new AddTabs.Patient());
        }

        private void EmployeeFrame_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeeFrame.Navigate(new AddTabs.Employee());
        }

        private void AccountFrame_Loaded(object sender, RoutedEventArgs e)
        {
            AccountFrame.Navigate(new AddTabs.Account());
        }

        private void VaccineFrame_Loaded(object sender, RoutedEventArgs e)
        {
            VaccineFrame.Navigate(new AddTabs.Drug());
        }

        private void RegionFrame_Loaded(object sender, RoutedEventArgs e)
        {
            RegionFrame.Navigate(new AddTabs.Region());
        }

        private void ReceiptionFrame_Loaded(object sender, RoutedEventArgs e)
        {
            ReceiptionFrame.Navigate(new AddTabs.PatientReception());
        }
    }
}
