using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using LibraryManagementSystemWF.utils;
using LibraryManagementSystemWF.views.components;
using LibraryManagementSystemWF.views.Dashboard.AdminDashboardControl;
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
    public partial class AdminDashboard : Form
    {
        private List<User> users = new();
        private int page = 1;
        private int maxPage = 1;

        public AdminDashboard()
        {
            InitializeComponent();

            // Initialize version name
            versionlbl.Text = EnvService.GetVersion();

            LoadUsers();

            // init greeting
            User? user = AuthService.getSignedUser();

            if (user != null)
            {
                titleLbl.Text = GreetingGenerator.GenerateGreeting(user.Member.FirstName, DateTime.Now.ToString());
            }

            // run clock
            // Start the timer
            System.Windows.Forms.Timer timer = new();
            timer.Interval = 1000; // 1 second
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        public async void LoadUsers()
        {
            ControllerAccessData<User> res = await AdminController.GetAllUsers(page);

            if (res.IsSuccess)
            {
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

                // init pagination buttons
                prevLastBtn.Enabled = page > 1;
                prevBtn.Enabled = page > 1;

                nextLastBtn.Enabled = page < maxPage;
                nextBtn.Enabled = page < maxPage;
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
            AuthController.LogOut();
            new SignIn().Show();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new AdminMenu(this).Show();
        }

        private void prevLastBtn_Click(object sender, EventArgs e)
        {
            page = 1;
            LoadUsers();
        }

        private void nextLastBtn_Click(object sender, EventArgs e)
        {
            page = maxPage;
            LoadUsers();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            page += 1;
            LoadUsers();
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            page -= 1;
            LoadUsers();
        }
    }
}
