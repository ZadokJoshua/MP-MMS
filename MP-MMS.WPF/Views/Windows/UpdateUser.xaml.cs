﻿using MP_MMS.Data;
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

namespace MP_MMS.WPF.Views.Windows
{
    /// <summary>
    /// Interaction logic for UpdateUser.xaml
    /// </summary>
    public partial class UpdateUser : Window
    {
        private Employee employee;
        public UpdateUser(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            txtFirstName.Text = employee.FirstName;
            txtLastName.Text = employee.LastName;
            txtRole.Text = employee.Role;
            txtEmail.Text = employee.Email;
        }

        private void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            employee.FirstName = txtFirstName.Text;
            employee.LastName = txtLastName.Text;
            employee.Role = txtRole.Text;
            employee.Email = txtEmail.Text;

            using (var context = new MPMMSDbContext())
            {
                context.Employees.Update(employee);
                context.SaveChanges();
            }
        }
    }
}
