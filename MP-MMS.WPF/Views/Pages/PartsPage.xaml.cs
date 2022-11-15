﻿using Microsoft.EntityFrameworkCore;
using MP_MMS.Data;
using MP_MMS.Domain.Model;
using MP_MMS.WPF.Views.Windows;
using Syncfusion.ProjIO;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MP_MMS.WPF.Views.Pages
{
    /// <summary>
    /// Interaction logic for PartsPage.xaml
    /// </summary>
    public partial class PartsPage : Page
    {
        public IEnumerable<Part> Parts { get; private set; }
        public IEnumerable<Location> Locations { get; private set; }
        

        public PartsPage()
        {
            InitializeComponent();
            LoadListView();
        }

        private async void LoadListView()
        {
            using (MPMMSDbContext context = new())
            {
                Parts = await context.Parts.ToListAsync();
                Locations = await context.Locations.ToListAsync();
            }

            if (Parts != null)
            {
                partsListView.ItemsSource = Parts;
            }
        }
        
        private void ImportCSV_Click(object sender, RoutedEventArgs e)
        {
            var importWindow = new ImportCSV();
            importWindow.ShowDialog();

            LoadListView();
        }

        private void AddPart_Click(object sender, RoutedEventArgs e)
        {
            var addPartWindow = new AddPart();
            addPartWindow.ShowDialog();

            LoadListView();
        }

        private void UpdatePart_Click(object sender, RoutedEventArgs e)
        {
            Part selectedPart = (Part)partsListView.SelectedItem;
            if (selectedPart != null)
            {
                var updatePartWindow = new UpdatePart(selectedPart);
                updatePartWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select a record.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            LoadListView();
        }

        
        private void DeletePart_Click(object sender, RoutedEventArgs e)
        {
            Part selectedPart = (Part)partsListView.SelectedItem;
            if (selectedPart != null)
            {
                string message = $"Do you want to delete {selectedPart.Name}'s data?";
                string title = "Delete Item";
                MessageBoxButton buttons = MessageBoxButton.YesNo;
                var result = MessageBox.Show(message, title, buttons, MessageBoxImage.Warning);
                if (result is MessageBoxResult.Yes)
                {
                    using (var context = new MPMMSDbContext())
                    {
                        context.Parts.Remove(selectedPart);
                        context.SaveChanges();
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a record.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            LoadListView();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filteredList = Parts.Where(e => e.Name.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            partsListView.ItemsSource = filteredList;
        }
    }
}
