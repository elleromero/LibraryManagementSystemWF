using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using LibraryManagementSystemWF.views.Dashboard.Admin;

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
            this.Hide();
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
                    // AdminDashboardRevamp admin = new(); // ssshhh
                    AdminDashboard admin = new();
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
