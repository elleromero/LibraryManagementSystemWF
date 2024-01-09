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
        private Form? form;

        public SignIn(Form? form = null)
        {
            InitializeComponent();

            this.loader = new(this);
            this.form = form;
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
            this.loader = new(this);
            loader.StartLoading();

            ControllerModifyData<User> res = await AuthController.SignIn(username, password);
            User? user = AuthService.getSignedUser();


            if (res.IsSuccess)
            {
                loader.StopLoading();

                if (user.Role.HasAccess && user.Role.Name == "ADMINISTRATOR")
                {
                    AdminDashboard admin = new(this);
                    this.Hide();
                    admin.Show();
                }
                else if (user.Role.HasAccess && user.Role.Name == "LIBRARIAN")
                {
                    LibrarianDashboard librarian = new(this);
                    this.Hide();
                    librarian.Show();
                }
                else
                {
                    UserDashboard userDb = new(this);
                    this.Hide();
                    userDb.Show();
                }
            }
            else
            {
                loader.StopLoading();
                DialogBuilder.Show(res.Errors, "Authentication Error", MessageBoxIcon.Stop);
            }

            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new About().ShowDialog();
        }

        private void SignIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.form?.Show();
        }
    }
}
