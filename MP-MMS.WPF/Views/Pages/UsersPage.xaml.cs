using MP_MMS.Data;
using MP_MMS.Data.DataService;
using MP_MMS.Domain.Model;
using MP_MMS.WPF.Views.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MP_MMS.WPF.Views.Pages;

/// <summary>
/// Interaction logic for UsersPage.xaml
/// </summary>
public partial class UsersPage : Page
{
    public IEnumerable<Employee> Employees { get; private set; }

    public UsersPage()
    {
        InitializeComponent();
        Employees = new List<Employee>();
        LoadListView();
    }

    private async void AddUser_Click(object sender, RoutedEventArgs e)
    {
        var addUserWindow = new AddUser();
        addUserWindow.ShowDialog();
        await LoadListView();
    }

    async Task LoadListView()
    {
        var dataAccess = new GenericDataService<Employee>();
        Employees = await dataAccess.GetAll();

        if (Employees != null)
        {
            partsListView.ItemsSource = Employees;
        }
    }

    private async void UpdateUser_Click(object sender, RoutedEventArgs e)
    {
        Employee selectedEmployee = (Employee)partsListView.SelectedItem;
        if (selectedEmployee != null)
        {
            var updateUserWindow = new UpdateUser(selectedEmployee);
            updateUserWindow.ShowDialog();
        }
        else
        {
            MessageBox.Show("Select a record.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        await LoadListView();
    }

    private async void DeleteUser_Click(object sender, RoutedEventArgs e)
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
                var dataAccess = new GenericDataService<Employee>();
                await dataAccess.Delete(selectedEmployee);
            }
        }
        else
        {
            MessageBox.Show("Select a record.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        await LoadListView();
    }

    private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        var filteredList = Employees.Where(e => e.FirstName.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
        partsListView.ItemsSource = filteredList;   
    }
}
