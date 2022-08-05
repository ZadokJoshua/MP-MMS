using MP_MMS.Data;
using MP_MMS.Domain.Model;
using MP_MMS.WPF.Views.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MP_MMS.WPF.Views.Pages
{
    /// <summary>
    /// Interaction logic for UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
            LoadListView();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            var addUserWindow = new AddUser();
            addUserWindow.ShowDialog();
            LoadListView();
        }


        void LoadListView()
        {
            using (var context = new MPMMSDbContext())
            {
                partsListView.ItemsSource = context.Employees.ToList<Employee>();
            }
        }

        private void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            Employee selectedEmployee = (Employee)partsListView.SelectedItem;
            if (selectedEmployee != null)
            {
                var updateUserWindow = new UpdateUser(selectedEmployee);
                updateUserWindow.ShowDialog();
            }
            LoadListView();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
