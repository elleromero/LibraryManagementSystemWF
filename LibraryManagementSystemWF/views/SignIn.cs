using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.Dashboard;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private async void button2_Click_1(object sender, EventArgs e)
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

                    AdminDashboard admin = new AdminDashboard();
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
