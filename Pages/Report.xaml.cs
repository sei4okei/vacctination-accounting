using courseproject.Data;
using courseproject.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Report.xaml
    /// </summary>
    public partial class Report : Page
    {
        public Report()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            using (VacctinationAccountingDb db = new VacctinationAccountingDb())
            {
                foreach (var item in db.Report.ToList())
                {
                    db.Report.Remove(item);
                }

                db.Report.Add(new Data.Models.Report()
                {
                    StartDate = FirstDatePicker.SelectedDate.Value.Date,
                    EndDate = SecondDatePicker.SelectedDate.Value.Date,
                    CreatedDate = DateTime.Now
                });

                db.SaveChanges();
            }

            var reportData = ExcelReport.GetReport();
            var reportExcel = new ReportCreator().Create(reportData);

            File.WriteAllBytes(@"C:\\Users\\Public\\Documents\\Отчет.xlsx", reportExcel);

            MessageBox.Show("Отчет создан!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);

            //try
            //{
            //    using (VacctinationAccountingDb db = new VacctinationAccountingDb())
            //    {
            //        foreach (var item in db.Report.ToList())
            //        {
            //            db.Report.Remove(item);
            //        }

            //        db.Report.Add(new Data.Models.Report()
            //        {
            //            StartDate = FirstDatePicker.SelectedDate.Value.Date,
            //            EndDate = SecondDatePicker.SelectedDate.Value.Date,
            //            CreatedDate = DateTime.Now
            //        });

            //        db.SaveChanges();
            //    }

            //    var reportData = ExcelReport.GetReport();
            //    var reportExcel = new ReportCreator().Create(reportData);

            //    File.WriteAllBytes(@"C:\\Users\\Public\\Documents\\Отчет.xlsx", reportExcel);

            //    MessageBox.Show("Отчет создан!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Произошла ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            //}
        }
    }
}
