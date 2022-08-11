using System.Windows.Controls;

namespace MP_MMS.WPF.Views.Pages
{
    /// <summary>
    /// Interaction logic for HomeDashboard.xaml
    /// </summary>
    public partial class HomeDashboard : Page
    {
        public HomeDashboard()
        {
            InitializeComponent();
            Plot();
        }

        void Plot()
        {
            double[] dataX = new double[] { 1, 2, 3, 4, 5 };
            double[] dataY = new double[] { 1, 4, 9, 16, 25 };
            Wpfplot1.Plot.AddScatter(dataX, dataY);
            Wpfplot1.Refresh();
        }

    }
}
