using MP_MMS.Data;
using MP_MMS.Domain.Model;
using System.Windows;

namespace MP_MMS.WPF.Views.Windows
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();

            // Startup location
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();
            employee.FirstName = txtFirstName.Text;
            employee.LastName = txtLastName.Text;
            employee.Role = txtRole.Text;
            employee.Email = txtEmail.Text;

            using (var context = new MPMMSDbContext())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }

            Close();
        }
    }
}
