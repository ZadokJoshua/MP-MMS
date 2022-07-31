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
    /// Interaction logic for PartsPage.xaml
    /// </summary>
    public partial class PartsPage : Page
    {
        IEnumerable<Friends> FriendsList = new List<Friends>()
        {
        new Friends()
        {
            FirstName = "Zadok",
            LastName = "Samuel"

        },
        new Friends()
        {
            FirstName = "Zadok",
            LastName = "Samuel"
        }
    };
        

        public PartsPage()
        {
            InitializeComponent();
            partsListView.ItemsSource = FriendsList;
        }
       
    }

    public class Friends
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageLocation { get; set; }
    }
}
