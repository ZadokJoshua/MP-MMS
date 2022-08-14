﻿using Microsoft.EntityFrameworkCore;
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
        private IList<Issue> issues;
        private IList<Part> parts; 
        private IList<Employee> employees;

        public IssuesPage()
        {
            InitializeComponent();
            LoadListView();
        }

        private async void LoadListView()
        {
            using (MPMMSDbContext context = new())
            {
                issues = await context.Issues.ToListAsync();
                parts = await context.Parts.ToListAsync();
                employees = await context.Employees.ToListAsync();
            }

            if (issues != null)
            {
                issuesListView.ItemsSource = issues;
            }
        }

        private void AddIssue_Click(object sender, RoutedEventArgs e)
        {
            var addIssueWindow = new AddIssue();
            addIssueWindow.ShowDialog();

            LoadListView();
        }

        private void UpdateIssue_Click(object sender, RoutedEventArgs e)
        {
            Issue selectedIssue = (Issue)issuesListView.SelectedItem;
            if (selectedIssue != null)
            {
                var updateIssueWindow = new UpdateIssue(selectedIssue);
                updateIssueWindow.ShowDialog();
            }
            LoadListView();
        }

        private void DeleteIssue_Click(object sender, RoutedEventArgs e)
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

            LoadListView();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filteredList = issues.Where(e => e.Name.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            issuesListView.ItemsSource = filteredList;
        }
    }
}
