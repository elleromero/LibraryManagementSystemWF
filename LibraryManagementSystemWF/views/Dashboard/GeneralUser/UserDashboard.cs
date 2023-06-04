using LibraryManagementSystemWF.controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystemWF.views.Dashboard.GeneralUser
{
    public partial class UserDashboard : Form
    {
        public UserDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AuthController.LogOut();
            new SignIn().Show();
            this.Close();
        }
    }
}
