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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Data;

namespace MyIVDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            new Task(ShowDatabaseInGrid).Start(); ;
        }

        public async void ShowDatabaseInGrid()
        {
            DataSet dataSet = await Connection.ShowDatabaseInGrid();
            Dispatcher.Invoke(() =>
            {
                if (dataSet.Tables.Count > 0)
                    dataGrid.ItemsSource = dataSet.Tables[0].DefaultView;
            });
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
            new Task(ShowDatabaseInGrid).Start();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddWindow add = new AddWindow();
            add.Show();
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGrid.SelectedItem;

            string removetask = (dataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

            if (item == null)
            {
                await this.ShowMessageAsync("Error","No pokemon selected to remove.");
            }
            else
            {
                MessageDialogResult res = await this.ShowMessageAsync("",$"Are you sure you want to remove {removetask}?", MessageDialogStyle.AffirmativeAndNegative);
                if (res == MessageDialogResult.Negative)
                {
                    await this.ShowMessageAsync("","Cancelled removal.");
                }
                else
                {
                    DeletePoke.DeleteRow(removetask);
                    await this.ShowMessageAsync("", $"Succesfully removed {removetask}.");
                }
                dataGrid.ItemsSource = null;
                new Task(ShowDatabaseInGrid).Start();
            }
        }
    }
}
