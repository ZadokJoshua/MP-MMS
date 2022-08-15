using Microsoft.EntityFrameworkCore;
using MP_MMS.Data;
using MP_MMS.Domain.Model;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Controls;

namespace MP_MMS.WPF.Views.Pages
{
    /// <summary>
    /// Interaction logic for HomeDashboard.xaml
    /// </summary>
    public partial class HomeDashboard : Page
    {
        private IList<Issue> issues;
        private IList<Part> parts;
        private IList<Employee> employees;

        public HomeDashboard()
        {
            InitializeComponent();
            Plot();
        }


        async void Plot()
        {
            using (MPMMSDbContext context = new())
            {
                issues = await context.Issues.ToListAsync();
                parts = await context.Parts.ToListAsync();
                employees = await context.Employees.ToListAsync();
            }

            barChart.ItemsSource = parts;
        }

    }
}
