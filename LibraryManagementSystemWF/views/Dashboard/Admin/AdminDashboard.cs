using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.interfaces;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using LibraryManagementSystemWF.utils;
using LibraryManagementSystemWF.views.components;
using LibraryManagementSystemWF.views.Dashboard.AdminDashboardControl;
using LibraryManagementSystemWF.views.loader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace LibraryManagementSystemWF.views.Dashboard.Admin
{
    public partial class AdminDashboard : Form, ICustomForm
    {
        private List<User> users = new();
        private int page = 1;
        private int maxPage = 1;
        private Loader loader;
        private Form form;
        private bool isSearch;

        public AdminDashboard(Form form)
        {
            InitializeComponent();

            this.form = form;
            this.isSearch = false;
            this.loader = new(this);

            // Initialize version name
            versionlbl.Text = EnvService.GetVersion();

            // init greeting
            User? user = AuthService.getSignedUser();

            if (user != null)
            {
                this.loader.StartLoading();
                LoadUsers();
                titleLbl.Text = GreetingGenerator.GenerateGreeting(user.Member.FirstName, DateTime.Now.ToString());
            }

            // run clock
            // Start the timer
            System.Windows.Forms.Timer timer = new();
            timer.Interval = 1000; // 1 second
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private async void LoadSearchUsers()
        {
            ControllerAccessData<User> res = await AdminController.Search(txtSearch.Text, page);

            if (res.IsSuccess)
            {
                this.loader.StopLoading();
                users = res.Results;

                subtitleLbl.Text = $"{res.rowCount} user(s) found.";

                // Fill books
                flowLayoutPanel1.Controls.Clear();
                if (res.Results.Count > 0)
                {
                    flowLayoutPanel1.Margin = new Padding(3);
                    // loop through results
                    foreach (User user in users)
                    {
                        flowLayoutPanel1.Controls.Add(new UserContainer(user));
                    }
                }
                else
                {
                    // add empty template
                    flowLayoutPanel1.Margin = Padding.Empty;
                    flowLayoutPanel1.Controls.Add(new CtrlEmpty());
                }

                // init page label
                maxPage = Math.Max(1, (int)Math.Ceiling((double)res.rowCount / 10));
                pageLbl.Text = $"{page} | {maxPage}";
            }
            else
            {
                this.loader.StopLoading();
                DialogBuilder.Show(res.Errors, "Search Users", MessageBoxIcon.Hand);
            }
        }

        public async void LoadUsers()
        {
            ControllerAccessData<User> res = await AdminController.GetAllUsers(page);

            if (res.IsSuccess)
            {
                this.loader.StopLoading();
                users = res.Results;

                subtitleLbl.Text = $"You currently have {res.rowCount} user(s) registered.";

                // Fill books
                flowLayoutPanel1.Controls.Clear();
                if (res.Results.Count > 0)
                {
                    flowLayoutPanel1.Margin = new Padding(3);
                    // loop through results
                    foreach (User user in users)
                    {
                        flowLayoutPanel1.Controls.Add(new UserContainer(user));
                    }
                }
                else
                {
                    // add empty template
                    flowLayoutPanel1.Margin = Padding.Empty;
                    flowLayoutPanel1.Controls.Add(new CtrlEmpty());
                }

                // init page label
                maxPage = Math.Max(1, (int)Math.Ceiling((double)res.rowCount / 10));
                pageLbl.Text = $"{page} | {maxPage}";
            } else
            {
                this.loader.StopLoading();
                DialogBuilder.Show(res.Errors, "Fetch Users", MessageBoxIcon.Hand);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string time = now.ToString("MMM. d yyyy. dddd. hh:mm:ss tt");
            timeLbl.Text = time;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to log out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                AuthController.LogOut();
                form.Show();
                this.Close();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            new AdminMenu(this).Show();
        }

        private void prevLastBtn_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                page = 1;
                this.loader = new(this);
                this.loader.StartLoading();
                LoadUsers();
            }
        }

        private void nextLastBtn_Click(object sender, EventArgs e)
        {
            if (page < maxPage)
            {
                page = maxPage;
                this.loader = new(this);
                this.loader.StartLoading();
                LoadUsers();
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (page < maxPage)
            {
                page += 1;
                this.loader = new(this);
                this.loader.StartLoading();
                LoadUsers();
            }
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                page -= 1;
                this.loader = new(this);
                this.loader.StartLoading();
                LoadUsers();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new AdminAnnouncement(this).Show();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                this.isSearch = true;
                this.loader = new(this);
                this.loader.StartLoading();
                this.page = 1;
                LoadSearchUsers();
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                this.isSearch = false;
                this.loader = new(this);
                this.loader.StartLoading();
                this.page = 1;
                LoadUsers();
            }
        }

        public void RefreshDataGrid()
        {
            this.page = 1;
            if (this.isSearch) LoadSearchUsers(); else LoadUsers();
        }
    }
}
