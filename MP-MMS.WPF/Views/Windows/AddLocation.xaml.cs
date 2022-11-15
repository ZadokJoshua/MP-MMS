using MP_MMS.Data;
using MP_MMS.Data.DataService;
using MP_MMS.Domain.Model;
using System.Windows;

namespace MP_MMS.WPF.Views.Windows
{
    /// <summary>
    /// Interaction logic for AddLocation.xaml
    /// </summary>
    public partial class AddLocation : Window
    {
        public AddLocation()
        {
            InitializeComponent();

            // Startup location
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private async void AddLocation_Click(object sender, RoutedEventArgs e)
        {
            Location location = new()
            {
                Name = txtName.Text,
                Address = txtAddress.Text
            };

            var dataAccess = new GenericDataService<Location>();
            await dataAccess.Create(location);

            Close();
        }
    }
}
