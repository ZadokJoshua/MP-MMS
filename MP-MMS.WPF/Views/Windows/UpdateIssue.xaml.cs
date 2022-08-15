using Microsoft.EntityFrameworkCore;
using MP_MMS.Data;
using MP_MMS.Domain.Model;
using Syncfusion.Windows.Tools;
using Syncfusion.XlsIO.Parser.Biff_Records.Formula;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MP_MMS.WPF.Views.Windows
{
    /// <summary>
    /// Interaction logic for UpdateIssue.xaml
    /// </summary>
    public partial class UpdateIssue : Window
    {
        Issue issue = new();
        private List<Part> parts;
        private List<Employee> employees;
        private readonly IList<string> priority = new List<string>()
        {
            "Low",
            "Medium",
            "High"
        };
        public UpdateIssue(Issue issue)
        {
            InitializeComponent();
            this.issue = issue;
            txtName.Text = issue.Name;
            txtDescription.Text = issue.Description;
            BindComboBox(issue.PartId, issue.EmployeeId);
            cBoxPriority.SelectedItem = issue.Priority;
            txtDueDate.Value = issue.DueDate;
            checkBoxCompleted.IsChecked = issue.IsCompleted;
        }

        private void UpdateIssue_Click(object sender, RoutedEventArgs e)
        {
            issue.Name = txtName.Text;
            issue.Description = txtDescription.Text;
            issue.PartId = ((Part)cBoxParts.SelectedItem).Id;
            issue.EmployeeId = ((Employee)cBoxEmployees.SelectedItem).Id;
            issue.Priority = cBoxPriority.Text;
            issue.DueDate = Convert.ToDateTime(txtDueDate.Value);

            issue.IsCompleted = checkBoxCompleted.IsChecked is true ? true : false;

            using (MPMMSDbContext context = new())
            {
                context.Issues.Update(issue);
                context.SaveChanges();
            }

            Close();
        }

        private void DeleteIssue_Click(object sender, RoutedEventArgs e)
        {
            string message = $"Do you want to delete {issue.Name}'s data?";
            string title = "Delete Issue";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            var result = MessageBox.Show(message, title, buttons, MessageBoxImage.Warning);
            if (result is MessageBoxResult.Yes)
            {
                using (var context = new MPMMSDbContext())
                {
                    context.Issues.Remove(issue);
                    context.SaveChanges();
                }
            }

            Close();
        }

        async void BindComboBox(int partId, int employeeId)
        {
            using (MPMMSDbContext context = new())
            {
                parts = await context.Parts.ToListAsync();
                employees = await context.Employees.ToListAsync();
            }

            cBoxParts.ItemsSource = parts;
            cBoxEmployees.ItemsSource = employees;
            cBoxPriority.ItemsSource = priority;

            foreach (var dbPart in parts)
            {
                if (dbPart.Id == partId)
                {
                    cBoxParts.SelectedItem = dbPart;
                    break;
                }
            }

            foreach (var dbEmployee in employees)
            {
                if (dbEmployee.Id == employeeId)
                {
                    cBoxEmployees.SelectedItem = dbEmployee;
                    break;
                }
            }
        }


    }
}
