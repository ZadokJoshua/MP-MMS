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
    /// Interaction logic for LocationsPage.xaml
    /// </summary>
    public partial class LocationsPage : Page
    {
        private List<Location> locations;
        public LocationsPage()
        {
            InitializeComponent();

            locations = new List<Location>();

            LoadListView();
        }

        private void AddLocation_Click(object sender, RoutedEventArgs e)
        {
            var addLocationWindow = new AddLocation();
            addLocationWindow.ShowDialog();
            LoadListView();
        }

        void LoadListView()
        {
            using (var context = new MPMMSDbContext())
            {
                locations = context.Locations.ToList<Location>();
            }

            if (locations != null)
            {
                locationsListView.ItemsSource = locations;
            }
        }

        private void UpdateLocation_Click(object sender, RoutedEventArgs e)
        {
            Location selectedLocation = (Location)locationsListView.SelectedItem;
            if (selectedLocation != null)
            {
                var updateLocationWindow = new UpdateLocation(selectedLocation);
                updateLocationWindow.ShowDialog();
            }
            LoadListView();
        }

        private void DeleteLocation_Click(object sender, RoutedEventArgs e)
        {
            Location selectedLocation = (Location)locationsListView.SelectedItem;
            if (selectedLocation != null)
            {
                string message = $"Do you want to delete {selectedLocation.Name}'s data?";
                string title = "Delete Location";
                MessageBoxButton buttons = MessageBoxButton.YesNo;
                var result = MessageBox.Show(message, title, buttons, MessageBoxImage.Warning);
                if (result is MessageBoxResult.Yes)
                {
                    using (var context = new MPMMSDbContext())
                    {
                        context.Locations.Remove(selectedLocation);
                        context.SaveChanges();
                    }
                }
            }

            LoadListView();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filteredList = locations.Where(e => e.Name.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            locationsListView.ItemsSource = filteredList;
        }
    }
}
