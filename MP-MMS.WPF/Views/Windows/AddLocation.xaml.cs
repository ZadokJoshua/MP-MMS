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
    /// Interaction logic for AddLocation.xaml
    /// </summary>
    public partial class AddLocation : Window
    {
        Location location = new Location();
        public AddLocation()
        {
            InitializeComponent();
        }

        private void AddLocation_Click(object sender, RoutedEventArgs e)
        {
            location.Name = txtName.Text;
            location.Address = txtAddress.Text;

            using (var context = new MPMMSDbContext())
            {
                context.Locations.Add(location);
                context.SaveChanges();
            }

            this.Hide();
        }
    }
}
