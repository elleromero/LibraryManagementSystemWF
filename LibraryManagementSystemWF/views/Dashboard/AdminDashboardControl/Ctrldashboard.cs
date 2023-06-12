using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.interfaces;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using LibraryManagementSystemWF.utils;
using LibraryManagementSystemWF.views.components;
using LibraryManagementSystemWF.views.Dashboard;
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

namespace LibraryManagementSystemWF.Dashboard.AdminDashboardControl
{
    public partial class Ctrldashboard : UserControl, ICustomForm
    {
        private int currentPage = 1;
        private int maxPage = 1;
        private Form form;
        private Loader loader;

        public Ctrldashboard(Form form)
        {
            InitializeComponent();

            this.form = form;

            // init greeting
            User? user = AuthService.getSignedUser();

            if (user != null)
            {
                titleLbl.Text = GreetingGenerator.GenerateGreeting(user.Member.FirstName, DateTime.Now.ToString());
            }

            // start loading
            this.loader = new(this.form);
            this.loader.StartLoading();

            LoadRecentBooks();
            LoadStats();
            LoadAnnouncements();
        }

        public async void LoadRecentBooks()
        {
            ControllerAccessData<Book> res = await BookController.GetAllBooks(1);

            Label label = new();

            if (res.IsSuccess)
            {
                this.loader.StopLoading();

                flowLayoutPanel1.Controls.Clear();

                if (res.Results.Count == 0)
                {
                    label.Text = "No recent books";
                    DialogBuilder.Show("No recent books found", "Fetch Books", MessageBoxIcon.Information);
                    flowLayoutPanel1.Controls.Add(label);

                    return;
                }

                for (int i = 0; i < Math.Min(5, res.Results.Count); i++)
                {
                    flowLayoutPanel1.Controls.Add(new BookContainer(res.Results[i], false, this.form, this));
                }
            } else
            {
                this.loader.StopLoading();

                label.Text = "Error fetching recent books";

                DialogBuilder.Show("Error on fetching recent books", "Fetch Books Error", MessageBoxIcon.Hand);

                flowLayoutPanel1.Controls.Add(label);
            }
        }

        private async void LoadAnnouncements()
        {
            ControllerAccessData<Announcement> res = await AnnouncementController.GetAll(currentPage);

            if (res.IsSuccess)
            {
                this.loader.StopLoading();

                flpAnnouncements.Controls.Clear();

                if (res.Results.Count == 0)
                {
                    Label label = new();
                    label.Text = "No announcements yet";
                    label.Width = 200;

                    flpAnnouncements.Controls.Add(label);
                }

                // set page
                maxPage = Math.Max(1, (int)Math.Ceiling((double)res.rowCount / 10));
                pageLbl.Text = $"{currentPage} | {maxPage}";

                foreach (Announcement ann in res.Results)
                {
                    flpAnnouncements.Controls.Add(new AnnouncementContainer(ann));
                }
            }
            else
            {
                this.loader.StopLoading();
                DialogBuilder.Show("Can't fetch announcements at the moment", "Fetch Announcement Error", MessageBoxIcon.Hand);
            }
        }

        public async void LoadStats()
        {
            ControllerModifyData<Stats> res = await StatsController.GetStats();

            if (res.IsSuccess && res.Result != null)
            {
                this.loader.StopLoading();

                totalBooksLbl.Text = res.Result.TotalBooks.ToString();
                btrRatioLbl.Text = $"{res.Result.TotalBorrowedBooks} : {res.Result.TotalReturnedBooks}";
                availableCopiesLbl.Text = res.Result.TotalAvailableCopies.ToString();
            } else
            {
                this.loader.StopLoading();
            }
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                this.loader = new(this.form);
                this.loader.StartLoading();
                LoadAnnouncements();
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (currentPage < maxPage)
            {
                currentPage++;
                this.loader = new(this.form);
                this.loader.StartLoading();
                LoadAnnouncements();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.form.Enabled = false;
            new AnnouncementMenu(this, this.form).Show();
        }

        public void RefreshDataGrid()
        {
            LoadAnnouncements();
        }
    }
}
