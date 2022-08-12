using Microsoft.EntityFrameworkCore;
using MP_MMS.Data;
using MP_MMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MP_MMS.WPF.Views.Windows
{
    /// <summary>
    /// Interaction logic for AddIssue.xaml
    /// </summary>
    public partial class AddIssue : Window
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

        public AddIssue()
        {
            InitializeComponent();
            BindComboBox();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
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
                context.Issues.Add(issue);
                context.SaveChanges();
            }

            Close();

        }

        async void BindComboBox()
        {
            using (MPMMSDbContext context = new())
            {
                parts = await context.Parts.ToListAsync();
                employees = await context.Employees.ToListAsync();
            }

            cBoxParts.ItemsSource = parts;
            cBoxEmployees.ItemsSource = employees;
            cBoxPriority.ItemsSource = priority;
        }
    }
}
