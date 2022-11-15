using Microsoft.Win32;
using MP_MMS.Data.DataService;
using MP_MMS.Domain.Model;
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
using System.Windows.Shapes;

namespace MP_MMS.WPF.Views.Windows
{
    /// <summary>
    /// Interaction logic for ImportCSV.xaml
    /// </summary>
    public partial class ImportCSV : Window
    {
        public string? FilePath { get; private set; }
        public ImportCSV()
        {
            InitializeComponent();
        }

        private void browseBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Csv Files|*.csv|All Files|*.*";
            fileDialog.DefaultExt = ".csv";
            fileDialog.ShowDialog();
            if(fileDialog.FileName is not null)
            {
                csvFilePathTextBox.Text = fileDialog.FileName;
            }
        }

        private void importBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (csvFilePathTextBox.Text is not null)
                {
                    FilePath = csvFilePathTextBox.Text;
                    CsvDataService<Part>.BulkInsertOperation(FilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
