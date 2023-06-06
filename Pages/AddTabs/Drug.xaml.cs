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
    /// Логика взаимодействия для Drug.xaml
    /// </summary>
    public partial class Drug : Page
    {
        public Drug()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            VacctinationAccountingDb db = new VacctinationAccountingDb();

            try
            {
                if (NameTextBox.Text != null && DosageTextBox.Text != null && ContraindicatorsTextBox.Text != null
                    &&  ExpirationDatePicker.SelectedDate != null)
                {
                    db.Drug.Add(new Data.Models.Drug
                    {
                        Name = NameTextBox.Text,
                        Dosage = Convert.ToInt32(DosageTextBox.Text),
                        Contraindicators = ContraindicatorsTextBox.Text,
                        ExpirationDate = ExpirationDatePicker.SelectedDate.Value,
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
            NameTextBox.Clear();
            DosageTextBox.Clear();
            ContraindicatorsTextBox.Clear();
            ExpirationDatePicker.SelectedDate = null;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
