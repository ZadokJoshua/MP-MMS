using MP_MMS.Data;
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

            this.Hide();
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

            this.Hide();
        }
    }
}
