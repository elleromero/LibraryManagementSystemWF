using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.Dashboard;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using LibraryManagementSystemWF.views.Dashboard;
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new();
            register.Show();
            this.Close();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            ControllerModifyData<User> res = await AuthController.SignIn(username, password);
            User? user = AuthService.getSignedUser();


            if (res.IsSuccess)
            {
                if (user.Role.HasAccess)
                {
                    MessageBox.Show("LOGIN SUCCESS!!!! WELCOME ADMIN!!!");

                    // AdminDashboard admin = new AdminDashboard();
                    AdminDashboardRevamp admin = new();
                    admin.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("LOGIN SUCCESS!!!! WELCOME USER!!!");

                    UserDb userDb = new UserDb();
                    userDb.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("WRONG INPUT!!!");
            }

            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }
    }
}
