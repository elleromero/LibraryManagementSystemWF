using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.interfaces;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using LibraryManagementSystemWF.utils;
using LibraryManagementSystemWF.views.components;
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

namespace LibraryManagementSystemWF.Dashboard.AdminDashboardControl
{
    public partial class Ctrldashboard : UserControl, ICustomForm
    {
        private int currentPage = 1;
        private int maxPage = 1;

        public Ctrldashboard()
        {
            InitializeComponent();

            // init greeting
            User? user = AuthService.getSignedUser();

            if (user != null)
            {
                titleLbl.Text = GreetingGenerator.GenerateGreeting(user.Member.FirstName, DateTime.Now.ToString());
            }

            LoadStats();
            LoadAnnouncements();
        }

        private async void LoadAnnouncements()
        {
            ControllerAccessData<Announcement> res = await AnnouncementController.GetAll(currentPage);

            if (res.IsSuccess)
            {
                // set page
                maxPage = Math.Max(1, (int)Math.Ceiling((double)res.rowCount / 10));
                pageLbl.Text = $"{currentPage} | {maxPage}";

                flpAnnouncements.Controls.Clear();

                foreach (Announcement ann in res.Results)
                {
                    flpAnnouncements.Controls.Add(new AnnouncementContainer(ann));
                }
            }
            else MessageBox.Show("Can't fetch announcements at the moment");
        }

        private async void LoadStats()
        {
            ControllerModifyData<Stats> res = await StatsController.GetStats();

            if (res.IsSuccess && res.Result != null)
            {
                totalBooksLbl.Text = res.Result.TotalBooks.ToString();
                btrRatioLbl.Text = $"{res.Result.TotalBorrowedBooks} : {res.Result.TotalReturnedBooks}";
                availableCopiesLbl.Text = res.Result.TotalAvailableCopies.ToString();
            }
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadAnnouncements();
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (currentPage < maxPage)
            {
                currentPage++;
                LoadAnnouncements();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new AnnouncementMenu(this).Show();
        }

        public void RefreshDataGrid()
        {
            LoadAnnouncements();
        }
    }
}
