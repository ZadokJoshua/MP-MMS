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
