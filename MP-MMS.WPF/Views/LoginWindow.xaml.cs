using Microsoft.EntityFrameworkCore;
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

namespace MP_MMS.WPF.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public MainWindow MainWindow  { get; set; }
        public IList<User> Users { get; set; }

        public LoginWindow()
        {
            InitializeComponent();
            MainWindow = new MainWindow();
        }

        private void GrantAccess()
        {
            MainWindow.Show();
            Close();
        }

        private void CloseAppBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            bool userFound;
            var username = UsernameTxt.Text;
            var password = PasswordTxt.Password;

            using (var context = new MPMMSDbContext())
            {
                Users = context.Users.ToList();
            }

            userFound = Users.Any(user => user.UserName.Equals(username) && user.Password.Equals(password));

            if (userFound)
            {
                GrantAccess();
            }
            else
            {
                ErrorText.Content = "Wrong Credentials";
            }
        }
    }
}
