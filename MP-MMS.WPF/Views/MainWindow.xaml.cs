using MP_MMS.WPF.Views.Pages;
using System.Windows;

namespace MP_MMS.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public HomeDashboard Home { get; private set; }
        public PartsPage PartPage { get; private set; }
        public IssuesPage IssuePage { get; private set; }
        public LocationsPage LocationPage { get; private set; }
        public UsersPage UserPage { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            Home = new HomeDashboard();
            ContentFrame.Content = Home;
            PartPage = new PartsPage();
            IssuePage = new IssuesPage();
            LocationPage = new LocationsPage();
            UserPage = new UsersPage();
        }


        private void PartsPage_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = PartPage;
        }

        private void Locations_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = LocationPage;
        }

        private void IssuesPage_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = IssuePage;
        }

        private void UsersPage_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = UserPage;
        }

        private void HomePage_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = Home;
        }
    }
}
