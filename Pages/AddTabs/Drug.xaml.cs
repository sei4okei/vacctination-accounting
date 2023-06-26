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
    /// Логика взаимодействия для Drug.xaml
    /// </summary>
    public partial class Drug : Page
    {
        Data.Models.Drug drug;

        public Drug(Data.Models.Drug _drug)
        {
            InitializeComponent();

            drug = _drug;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            VacctinationAccountingDb db = new VacctinationAccountingDb();

            try
            {
                if (NameTextBox.Text == null && DosageTextBox.Text == null && ContraindicatorsTextBox.Text == null
                    && ExpirationDatePicker.SelectedDate == null)
                {
                    MessageBox.Show("Данные ввдены неверно, попробуйте снова!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (drug != null)
                {
                    drug = GetUserInput(drug);

                    db.Drug.Update(drug);

                    db.SaveChanges();

                    ClearInput();

                    MessageBox.Show("Данные обновлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    db.Drug.Add(GetUserInput(new Data.Models.Drug()));

                    db.SaveChanges();

                    ClearInput();

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
            NameTextBox.Clear();
            DosageTextBox.Clear();
            ContraindicatorsTextBox.Clear();
            ExpirationDatePicker.SelectedDate = null;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (drug != null) FillFields(drug);
            else DeleteButton.Visibility = Visibility.Hidden;
        }

        private Data.Models.Drug GetUserInput(Data.Models.Drug d)
        {
            d.Name = NameTextBox.Text;
            d.Dosage = int.Parse(DosageTextBox.Text);
            d.Contraindicators = ContraindicatorsTextBox.Text;
            d.ExpirationDate = ExpirationDatePicker.SelectedDate.Value;

            return d;
        }

        private void FillFields(Data.Models.Drug d)
        {
            NameTextBox.Text = d.Name;
            DosageTextBox.Text = d.Dosage.ToString();
            ContraindicatorsTextBox.Text = d.Contraindicators;
            ExpirationDatePicker.SelectedDate = d.ExpirationDate;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (drug == null) return;
            using (VacctinationAccountingDb db = new VacctinationAccountingDb())
            {
                try
                {
                    db.Drug.Remove(drug);

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
