using MP_MMS.Data;
using MP_MMS.Data.DataService;
using MP_MMS.Domain.Model;
using MP_MMS.WPF.Views.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MP_MMS.WPF.Views.Pages
{
    /// <summary>
    /// Interaction logic for LocationsPage.xaml
    /// </summary>
    public partial class LocationsPage : Page
    {
        public IEnumerable<Location> Locations { get; private set; }
        public LocationsPage()
        {
            InitializeComponent();

            Locations = new List<Location>();

            LoadListViewAsync();
        }

        private void AddLocation_Click(object sender, RoutedEventArgs e)
        {
            var addLocationWindow = new AddLocation();
            addLocationWindow.ShowDialog();
            LoadListViewAsync();
        }

        async Task LoadListViewAsync()
        {
            //using (var context = new MPMMSDbContext())
            //{
            //    Locations = context.Locations.ToList<Location>();
            //}
            var dataAccess = new GenericDataService<Location>();
            await dataAccess.GetAll();

            if (Locations != null)
            {
                locationsListView.ItemsSource = Locations;
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
            LoadListViewAsync();
        }

        private async void DeleteLocation_Click(object sender, RoutedEventArgs e)
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
                    //using (var context = new MPMMSDbContext())
                    //{
                    //    context.Locations.Remove(selectedLocation);
                    //    context.SaveChanges();
                    //}

                    var dataAccess = new GenericDataService<Location>();
                    await dataAccess.Delete(selectedLocation);
                }
            }

            LoadListViewAsync();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filteredList = Locations.Where(e => e.Name.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            locationsListView.ItemsSource = filteredList;
        }
    }
}
