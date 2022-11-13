using Microsoft.EntityFrameworkCore;
using MP_MMS.Data;
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
    /// Interaction logic for IssuesPage.xaml
    /// </summary>
    public partial class IssuesPage : Page
    {
        public AddIssue AddIssueWindow { get; set; } = new();
        public IList<Issue?> Issues { get; private set; }

        public IList<Part?> Parts { get; private set; }
        public IList<Employee?> Employees { get; private set; }

        public IssuesPage()
        {
            InitializeComponent();
            LoadListView();
        }

        private async Task LoadListView()
        {
            using (MPMMSDbContext context = new())
            {
                Issues = await context.Issues.ToListAsync();
                Parts = await context.Parts.ToListAsync();
                Employees = await context.Employees.ToListAsync();
            }

            if (Issues != null)
            {
                issuesListView.ItemsSource = Issues;
            }
        }

        private async void AddIssue_Click(object sender, RoutedEventArgs e)
        {
            AddIssueWindow = new();
            AddIssueWindow.ShowDialog();
            await LoadListView();
        }

        private async void UpdateIssue_Click(object sender, RoutedEventArgs e)
        {
            Issue selectedIssue = (Issue)issuesListView.SelectedItem;
            if (selectedIssue != null)
            {
                var updateIssueWindow = new UpdateIssue(selectedIssue);
                updateIssueWindow.ShowDialog();
            }
            await LoadListView();
        }

        private async void DeleteIssue_Click(object sender, RoutedEventArgs e)
        {
            Issue selectedIssue = (Issue)issuesListView.SelectedItem;
            if (selectedIssue != null)
            {
                string message = $"Do you want to delete {selectedIssue.Name}'s data?";
                string title = "Delete Issue";
                MessageBoxButton buttons = MessageBoxButton.YesNo;
                var result = MessageBox.Show(message, title, buttons, MessageBoxImage.Warning);
                if (result is MessageBoxResult.Yes)
                {
                    using (var context = new MPMMSDbContext())
                    {
                        context.Issues.Remove(selectedIssue);
                        context.SaveChanges();
                    }
                }
            }

            await LoadListView();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filteredList = Issues.Where(e => e.Name!.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            issuesListView.ItemsSource = filteredList;
        }
    }
}
