using MP_MMS.WPF.Views.Pages;
using System.Windows;
using System.Windows.Media;

namespace MP_MMS.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PartsPage PartPage { get; private set; }
        public IssuesPage IssuePage { get; private set; }
        public LocationsPage LocationPage { get; private set; }
        public UsersPage UserPage { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            ContentFrame.Content = new HomeDashboard();
            PartPage = new PartsPage();
            IssuePage = new IssuesPage();
            LocationPage = new LocationsPage();
            UserPage = new UsersPage();
            homeButton.Background = new SolidColorBrush(Color.FromRgb(82, 88, 92));
        }


        private void PartsPage_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = PartPage;
            ContentFrame.Content = new HomeDashboard();
            partsButton.Background = new SolidColorBrush(Color.FromRgb(61, 132, 33));
            homeButton.Background = new SolidColorBrush(Color.FromRgb(82, 88, 92));
            issuesButton.Background = new SolidColorBrush(Color.FromRgb(82, 88, 92));
            usersButton.Background = new SolidColorBrush(Color.FromRgb(82, 88, 92));
            locationsButton.Background = new SolidColorBrush(Color.FromRgb(82, 88, 92));
        }

        private void Locations_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = LocationPage;
            ContentFrame.Content = new HomeDashboard();
            locationsButton.Background  = new SolidColorBrush(Color.FromRgb(61, 132, 33));
            partsButton.Background = new SolidColorBrush(Color.FromRgb(82, 88, 92));
            issuesButton.Background = new SolidColorBrush(Color.FromRgb(82, 88, 92));
            usersButton.Background = new SolidColorBrush(Color.FromRgb(82, 88, 92));
            homeButton.Background = new SolidColorBrush(Color.FromRgb(82, 88, 92));
        }

        private void IssuesPage_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = IssuePage;
            ContentFrame.Content = new HomeDashboard();
            issuesButton.Background = new SolidColorBrush(Color.FromRgb(61, 132, 33));
            partsButton.Background = new SolidColorBrush(Color.FromRgb(82, 88, 92));
            homeButton.Background = new SolidColorBrush(Color.FromRgb(82, 88, 92));
            usersButton.Background = new SolidColorBrush(Color.FromRgb(82, 88, 92));
            locationsButton.Background = new SolidColorBrush(Color.FromRgb(82, 88, 92));
        }

        private void UsersPage_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = UserPage;
            ContentFrame.Content = new HomeDashboard();
            usersButton.Background = new SolidColorBrush(Color.FromRgb(61, 132, 33));
            partsButton.Background = new SolidColorBrush(Color.FromRgb(82, 88, 92));
            issuesButton.Background = new SolidColorBrush(Color.FromRgb(82, 88, 92));
            homeButton.Background = new SolidColorBrush(Color.FromRgb(82, 88, 92));
            locationsButton.Background = new SolidColorBrush(Color.FromRgb(82, 88, 92));
        }

        private void HomePage_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = new HomeDashboard();
            homeButton.Background = new SolidColorBrush(Color.FromRgb(61, 132, 33));
            partsButton.Background = new SolidColorBrush(Color.FromRgb(82, 88, 92));
            issuesButton.Background = new SolidColorBrush(Color.FromRgb(82, 88, 92));
            usersButton.Background = new SolidColorBrush(Color.FromRgb(82, 88, 92));
            locationsButton.Background = new SolidColorBrush(Color.FromRgb(82, 88, 92));
        }

        
    }
}
