using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.Dashboard;
using LibraryManagementSystemWF.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystemWF.views
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            ControllerModifyData<User> res = AuthController.SignIn(username, password);

            if (res.IsSuccess)
            {
                MessageBox.Show("LOGIN SUCCESS!!!! WELCOME USER!!!");

                AdminDashboard admin = new AdminDashboard();
                admin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("WRONG INPUT!!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }
    }
}
