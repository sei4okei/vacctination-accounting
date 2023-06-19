using courseproject.Data;
using courseproject.Data.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    /// Логика взаимодействия для View.xaml
    /// </summary>
    public partial class View : Page
    {
        public View()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Data.Models.View view = new Data.Models.View();

            ViewDataGrid.ItemsSource = view.GetList();

            SetupDataGrid();
        }

        private void SetupDataGrid()
        {
            ViewDataGrid.Columns[0].Header = "№";
            ViewDataGrid.Columns[0].Width = 117;
            ViewDataGrid.Columns[1].Header = "ФИО";
            ViewDataGrid.Columns[1].Width = 380;
            ViewDataGrid.Columns[2].Header = "Название вакцины";
            ViewDataGrid.Columns[2].Width = 282;
            ViewDataGrid.Columns[3].Header = "Дата вакцинации";
            ViewDataGrid.Columns[3].Width = 263;
            ViewDataGrid.Columns[4].Header = "Участок";
            ViewDataGrid.Columns[4].Width = 135;
            ViewDataGrid.Columns[5].Header = "ФИО врача";
            ViewDataGrid.Columns[5].Width = 200;
        }

        private void ViewDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGrid DG = sender as DataGrid;
            Data.Models.View row = (Data.Models.View)(sender as DataGrid).SelectedItems[0];

            NavigationManager.MainFrame.Navigate(new Add(row));

        }
    }
}
