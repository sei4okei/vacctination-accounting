using courseproject.Data;
using courseproject.Data.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
    /// Логика взаимодействия для Region.xaml
    /// </summary>
    public partial class Region : Page
    {
        Data.Models.Region region;

        public Region(Data.Models.Region _region)
        {
            InitializeComponent();

            region = _region;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            VacctinationAccountingDb db = new VacctinationAccountingDb();

            try
            {
                if (EmployeeComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Данные ввдены неверно, попробуйте снова!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (region != null)
                {
                    region = GetUserInput(region);

                    db.Region.Update(region);

                    db.SaveChanges();

                    MessageBox.Show("Данные обновлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    db.Region.Add(GetUserInput(new Data.Models.Region()));

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
            EmployeeComboBox.SelectedValue = null;
            SetRegionId();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SetRegionId();

            using (VacctinationAccountingDb db = new VacctinationAccountingDb())
            {
                List<string> list = db.Employee.Select(x => x.SecondName + " " + x.FirstName + " " + x.MiddleName).ToList();
                EmployeeComboBox.ItemsSource = list;
            }

            if (region != null) FillFields(region);
            else DeleteButton.Visibility = Visibility.Hidden;
        }

        private Data.Models.Region GetUserInput(Data.Models.Region r)
        {
            using (VacctinationAccountingDb db = new VacctinationAccountingDb())
            {
                r.EmployeeId = db.Employee.Single(x => x.SecondName + " " + x.FirstName + " " + x.MiddleName == EmployeeComboBox.SelectedItem.ToString()).Id;
            }

            return r;
        }

        private void FillFields(Data.Models.Region region)
        {
            RegionTextBox.Text = region.Id.ToString();

            using (VacctinationAccountingDb db = new VacctinationAccountingDb())
            {
                var employee = db.Employee.Single(e => e.Id == region.EmployeeId);

                EmployeeComboBox.SelectedItem = employee.SecondName + " " + employee.FirstName + " " + employee.MiddleName;
            }
        }

        private void SetRegionId()
        {
            using (VacctinationAccountingDb db = new VacctinationAccountingDb())
            {
                try
                {
                    RegionTextBox.Text = (db.Region.Max(x => x.Id) + 1).ToString();
                }
                catch (Exception)
                {
                    RegionTextBox.Text = "1";
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (region == null) return;
            using (VacctinationAccountingDb db = new VacctinationAccountingDb())
            {
                try
                {
                    db.Region.Remove(region);

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
