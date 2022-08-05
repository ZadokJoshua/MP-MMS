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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        Employee employee = new Employee();
        public AddUser()
        {
            InitializeComponent();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            employee.FirstName = txtFirstName.Text;
            employee.LastName = txtLastName.Text;
            employee.Role = txtRole.Text;
            employee.Email = txtEmail.Text;

            using (var context = new MPMMSDbContext())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }

            this.Hide();
        }
    }
}
