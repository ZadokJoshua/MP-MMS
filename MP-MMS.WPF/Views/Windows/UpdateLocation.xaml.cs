using MP_MMS.Data;
using MP_MMS.Domain.Model;
using System.Windows;

namespace MP_MMS.WPF.Views.Windows
{
    /// <summary>
    /// Interaction logic for UpdateLocation.xaml
    /// </summary>
    public partial class UpdateLocation : Window
    {
        private Location location;
        public UpdateLocation(Location location)
        {
            InitializeComponent();
            this.location = location;
            txtName.Text = location.Name;
            txtAddress.Text = location.Address;

            // Startup location
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void UpdateLocation_Click(object sender, RoutedEventArgs e)
        {
            location.Name = txtName.Text;
            location.Address = txtAddress.Text;

            using (var context = new MPMMSDbContext())
            {
                context.Locations.Update(location);
                context.SaveChanges();
            }

            Close();
        }

        private void DeleteLocation_Click(object sender, RoutedEventArgs e)
        {
            string message = $"Do you want to delete {location.Name}'s data?";
            string title = "Delete Location";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            var result = MessageBox.Show(message, title, buttons, MessageBoxImage.Warning);
            if (result is MessageBoxResult.Yes)
            {
                using (var context = new MPMMSDbContext())
                {
                    context.Locations.Remove(location);
                    context.SaveChanges();
                }
            }

            Close();
        }
    }
}
