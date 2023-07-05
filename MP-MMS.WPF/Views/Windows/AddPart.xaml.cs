using Microsoft.Win32;
using MP_MMS.Data;
using MP_MMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MP_MMS.WPF.Views.Windows
{
    /// <summary>
    /// Interaction logic for AddPart.xaml
    /// </summary>
    public partial class AddPart : Window
    {
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

            // Startup location
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }
        

        private void AddPart_Click(object sender, RoutedEventArgs e)
        {
            Part part = new();
            part.Name = txtName.Text;
            part.Manufacturer = txtManufacturer.Text;
            part.SerialNumber = txtSerialNumber.Text;
            part.ModelNumber = txtModelNumber.Text;
            part.Category = cBoxCategory.Text;

            if (cBoxLocation.SelectedItem != null) { part.LocationId = ((Location)cBoxLocation.SelectedItem).Id; }


            part.UnitCost = (decimal)txtCostPerUnit.Value;
            part.Quantity = (int)txtQuantity.Value;
            part.DateAdded = Convert.ToDateTime(txtDateAdded.Value);

            string fileUrl = ImgPart.Source.ToString();

            Uri uri = new Uri(fileUrl);
            string filePath = uri.LocalPath;

            byte[] imageBytes = File.ReadAllBytes(filePath);
            part.Image = imageBytes;

            using (MPMMSDbContext context = new())
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

        private void FileDialogBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png; *.jpg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";

            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            // Set the initial dialog page to My Pictures directory

            if (dialog.ShowDialog() == true)
            {
                string filename = dialog.FileName;
                ImgPart.Source = new BitmapImage(new Uri(filename));
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
                TbImgName.Text = fileNameWithoutExtension;
            }
        }
    }
}
