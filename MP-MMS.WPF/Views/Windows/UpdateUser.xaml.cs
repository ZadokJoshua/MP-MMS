using MP_MMS.Data;
using MP_MMS.Data.DataService;
using MP_MMS.Domain.Model;
using System.Windows;

namespace MP_MMS.WPF.Views.Windows
{
    /// <summary>
    /// Interaction logic for UpdateUser.xaml
    /// </summary>
    public partial class UpdateUser : Window
    {
        private Employee employee;
        public UpdateUser(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            txtFirstName.Text = employee.FirstName;
            txtLastName.Text = employee.LastName;
            txtRole.Text = employee.Role;
            txtEmail.Text = employee.Email;

            // Startup location
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private async void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            employee.FirstName = txtFirstName.Text;
            employee.LastName = txtLastName.Text;
            employee.Role = txtRole.Text;
            employee.Email = txtEmail.Text;

            //using (var context = new MPMMSDbContext())
            //{
            //    context.Employees.Update(employee);
            //    context.SaveChanges();
            //}

            var dataAccess = new GenericDataService<Employee>();
            await dataAccess.Update(employee);

            Close();
        }

        private async void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            string message = $"Do you want to delete {employee.FirstName}'s data?";
            string title = "Delete User";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            var result = MessageBox.Show(message, title, buttons, MessageBoxImage.Warning);
            if (result is MessageBoxResult.Yes)
            {
                //using (var context = new MPMMSDbContext())
                //{
                //    context.Employees.Remove(employee);
                //    context.SaveChanges();
                //}

                var dataAccess = new GenericDataService<Employee>();
                await dataAccess.Delete(employee);
            }

            Close();
        }
    }
}
