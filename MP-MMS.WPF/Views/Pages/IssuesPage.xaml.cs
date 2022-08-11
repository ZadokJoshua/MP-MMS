using MP_MMS.WPF.Views.Windows;
using System.Windows;
using System.Windows.Controls;

namespace MP_MMS.WPF.Views.Pages
{
    /// <summary>
    /// Interaction logic for IssuesPage.xaml
    /// </summary>
    public partial class IssuesPage : Page
    {
        public IssuesPage()
        {
            InitializeComponent();
        }

        private void AddIssue_Click(object sender, RoutedEventArgs e)
        {
            var addIssueWindow = new AddIssue();
            addIssueWindow.ShowDialog();
        }
    }
}
