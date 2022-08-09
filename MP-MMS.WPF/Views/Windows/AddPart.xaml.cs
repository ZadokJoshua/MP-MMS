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
    /// Interaction logic for AddPart.xaml
    /// </summary>
    public partial class AddPart : Window
    {
        Part part = new();
        IEnumerable<Location> locations;
        private readonly IList<String> categories = new List<string>()
        {
            "Screw",
            "Bolt",
            "Bearing",
            "Cam",
            "Fastener",
            "Key",
            "Belt",
            "Engine",
            "Actuator",
            "Linkage",
            "Seal",
            "Others"
        };
        

        public AddPart()
        {
            InitializeComponent();
            BindComboBox();
            cBoxCategory.ItemsSource = categories;
        }

        private void AddPart_Click(object sender, RoutedEventArgs e)
        {
            part.Name = txtName.Text;
            part.Manufacturer = txtManufacturer.Text;
            part.SerialNumber = txtSerialNumber.Text;
            part.ModelNumber = txtModelNumber.Text;
            part.Category = cBoxCategory.Text;

            part.LocationId = ((Location)cBoxLocation.SelectedItem).Id;

            part.UnitCost = (double)txtCostPerUnit.Value;
            part.Quantity = (int)txtQuantity.Value;
            part.DateAdded = Convert.ToDateTime(txtDateAdded.Value);

            using (MPMMSDbContext context = new ())
            {
                context.Parts.Add(part);
                context.SaveChanges();
            }

            Close();
        }

        void BindComboBox()
        {
            using (MPMMSDbContext context = new())
            {
                locations = context.Locations.ToList();
            }

            cBoxLocation.ItemsSource = locations;
        }
    }
}
