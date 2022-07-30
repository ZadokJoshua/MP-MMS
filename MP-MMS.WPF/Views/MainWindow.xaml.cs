﻿using MP_MMS.WPF.Views.Pages;
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

namespace MP_MMS.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PartsPage PartPage { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            ContentFrame.Content = new HomeDashboard();
            PartPage = new PartsPage();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = PartPage;
        }
    }
}
