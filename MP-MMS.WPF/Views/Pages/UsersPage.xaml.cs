using MP_MMS.Data;
using MP_MMS.Domain.Model;
using MP_MMS.WPF.Views.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MP_MMS.WPF.Views.Pages
{
    /// <summary>
    /// Interaction logic for UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public IList<Employee> Employees { get; private set; }

        public UsersPage()
        {
            InitializeComponent();
            Employees = new List<Employee>();
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
                Employees = context.Employees.ToList<Employee>();
            }

            if (Employees != null)
            {
                partsListView.ItemsSource = Employees;
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
            Employee selectedEmployee = (Employee)partsListView.SelectedItem;
            if (selectedEmployee != null)
            {
                string message = $"Do you want to delete {selectedEmployee.FirstName}'s data?";
                string title = "Delete User";
                MessageBoxButton buttons = MessageBoxButton.YesNo;
                var result = MessageBox.Show(message, title, buttons, MessageBoxImage.Warning);
                if (result is MessageBoxResult.Yes)
                {
                    using (var context = new MPMMSDbContext())
                    {
                        context.Employees.Remove(selectedEmployee);
                        context.SaveChanges();
                    }
                }
            }

            LoadListView();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filteredList = Employees.Where(e => e.FirstName.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            partsListView.ItemsSource = filteredList;
        }
    }
}
