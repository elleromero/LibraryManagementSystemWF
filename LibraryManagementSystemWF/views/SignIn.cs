using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using LibraryManagementSystemWF.utils;
using LibraryManagementSystemWF.views.Dashboard.Admin;
using LibraryManagementSystemWF.views.Dashboard.GeneralUser;
using LibraryManagementSystemWF.views.Dashboard.Librarian;
using LibraryManagementSystemWF.views.loader;

namespace LibraryManagementSystemWF.views
{
    public partial class SignIn : Form
    {
        private Loader loader;

        public SignIn()
        {
            InitializeComponent();

            this.loader = new();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new(this);
            register.Show();
            this.Hide();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // call loader
            this.loader = new();
            button2.Enabled = false;
            loader.StartLoading();

            ControllerModifyData<User> res = await AuthController.SignIn(username, password);
            User? user = AuthService.getSignedUser();


            if (res.IsSuccess)
            {
                button2.Enabled = true;
                loader.StopLoading();

                if (user.Role.HasAccess && user.Role.Name == "ADMINISTRATOR")
                {
                    AdminDashboard admin = new(this);
                    this.Hide();
                    admin.Show();
                }
                else if (user.Role.HasAccess && user.Role.Name == "LIBRARIAN")
                {
                    LibrarianDashboard librarian = new();
                    this.Hide();
                    librarian.Show();
                }
                else
                {
                    UserDashboard userDb = new();
                    this.Hide();
                    userDb.Show();
                }
            }
            else
            {
                button2.Enabled = true;
                loader.StopLoading();
                DialogBuilder.Show(res.Errors, "Authentication Error", MessageBoxIcon.Stop);
            }

            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new About().ShowDialog();
        }
    }
}
