﻿using MP_MMS.Data;
using MP_MMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MP_MMS.WPF.Views.Windows
{
    /// <summary>
    /// Interaction logic for UpdatePart.xaml
    /// </summary>
    public partial class UpdatePart : Window
    {
        private Part part;
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
        public UpdatePart(Part part)
        {
            InitializeComponent();
            this.part = part;
            txtName.Text = part.Name;
            txtManufacturer.Text = part.Manufacturer;
            txtSerialNumber.Text = part.SerialNumber;
            txtModelNumber.Text = part.ModelNumber;

            cBoxCategory.ItemsSource = categories;
            cBoxCategory.SelectedItem = part.Category;
            BindComboBox();
            cBoxLocation.SelectedItem = part.LocationId;

            txtCostPerUnit.Value = (long?)part.UnitCost;
            txtQuantity.Value = (long?)part.Quantity;
            txtDateAdded.Value = part.DateAdded;
        }

        private void UpdatePart_Click(object sender, RoutedEventArgs e)
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

            using (MPMMSDbContext context = new())
            {
                context.Parts.Add(part);
                context.SaveChanges();
            }

            Close();
        }

        private void DeletePart_Click(object sender, RoutedEventArgs e)
        {
            string message = $"Do you want to delete {part.Name}'s data?";
            string title = "Delete Item";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            var result = MessageBox.Show(message, title, buttons, MessageBoxImage.Warning);
            if (result is MessageBoxResult.Yes)
            {
                using (var context = new MPMMSDbContext())
                {
                    context.Parts.Remove(part);
                    context.SaveChanges();
                }
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
