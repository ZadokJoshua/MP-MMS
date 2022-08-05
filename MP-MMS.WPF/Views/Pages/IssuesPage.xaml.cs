﻿using MP_MMS.WPF.Views.Windows;
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
