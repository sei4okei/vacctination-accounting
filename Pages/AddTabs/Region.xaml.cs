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
    /// Логика взаимодействия для Region.xaml
    /// </summary>
    public partial class Region : Page
    {
        public Region()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            VacctinationAccountingDb db = new VacctinationAccountingDb();

            try
            {
                if (EmployeeComboBox.SelectedItem != null)
                {
                    db.Region.Add(new Data.Models.Region
                    {
                        EmployeeId = db.Employee.First(x => x.SecondName + " " + x.FirstName + " " + x.MiddleName == EmployeeComboBox.SelectedItem.ToString()).Id,
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
        }

        private void SetRegionId()
        {
            using (VacctinationAccountingDb db = new VacctinationAccountingDb())
            {
                RegionTextBox.Text = (db.Region.Max(x => x.Id) + 1).ToString();
            }
        }
    }
}
