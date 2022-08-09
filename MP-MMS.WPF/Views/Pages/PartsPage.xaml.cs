using MP_MMS.Data;
using MP_MMS.Domain.Model;
using MP_MMS.WPF.Views.Windows;
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

namespace MP_MMS.WPF.Views.Pages
{
    /// <summary>
    /// Interaction logic for PartsPage.xaml
    /// </summary>
    public partial class PartsPage : Page
    {
        private IEnumerable<Part> parts;

        public PartsPage()
        {
            InitializeComponent();

            LoadListView();
        }

        private void LoadListView()
        {
            using (MPMMSDbContext context = new())
            {
                parts = context.Parts.ToList();
            }

            if(parts != null)
            {
                partsListView.ItemsSource = parts;
            }
        }

        private void ImportCSV_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddPart_Click(object sender, RoutedEventArgs e)
        {
            var addPartWindow = new AddPart();
            addPartWindow.ShowDialog();

            LoadListView();
        }



    }
}
