﻿using MP_MMS.WPF.ChartResources;
using Syncfusion.UI.Xaml.Charts;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PieSeries = Syncfusion.UI.Xaml.Charts.PieSeries;

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
            ViewModel viewModel = new ViewModel();
            PieChartDisplay.DataContext = viewModel;
            PieChartDisplay.Header = "Work Order Report";
            PieChartDisplay.Legend = new ChartLegend()
            {
                DockPosition = ChartDock.Bottom,
                IconHeight = 20,
                IconWidth = 20
            };

            // Defining the PieSeries with adornments.
            PieSeries series = new PieSeries();
            series.XBindingPath = "Name";
            series.YBindingPath = "Count";
            series.ItemsSource = viewModel.Data;
            series.Palette = ChartColorPalette.GreenChrome;
            
            series.AdornmentsInfo = new ChartAdornmentInfo()
            {
                ShowLabel = true
            };
            PieChartDisplay.Series.Add(series);
        }
    }
}
