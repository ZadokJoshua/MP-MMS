using MP_MMS.Data;
using MP_MMS.Domain.Model;
using System.Windows;

namespace MP_MMS.WPF.Views.Windows
{
    /// <summary>
    /// Interaction logic for AddLocation.xaml
    /// </summary>
    public partial class AddLocation : Window
    {
        Location location = new Location();
        public AddLocation()
        {
            InitializeComponent();

            // Startup location
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void AddLocation_Click(object sender, RoutedEventArgs e)
        {
            //Location tt = new Location
            //{
            //    Address = "",
            //    Id = 2,
            //    Name = "",
            //    Parts = null
            //};
            location.Name = txtName.Text;
            location.Address = txtAddress.Text;

            using (var context = new MPMMSDbContext())
            {
                context.Locations.Add(location);
                context.SaveChanges();
            }

            Close();
        }
    }
}
