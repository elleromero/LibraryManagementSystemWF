using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
using LibraryManagementSystemWF.views.components;
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

namespace LibraryManagementSystemWF.views.Dashboard.GeneralUser
{
    public partial class UserAnnouncement : Form
    {
        private int page = 1;
        private int maxPage = 1;
        private Loader loader;
        private Form form;

        public UserAnnouncement(Form form)
        {
            InitializeComponent();

            this.form = form;
            this.loader = new(this);
            this.loader.StartLoading();

            LoadAnnouncements();
        }

        private async void LoadAnnouncements()
        {
            ControllerAccessData<Announcement> res = await AnnouncementController.GetAll(page);

            if (res.IsSuccess)
            {
                this.loader.StopLoading();

                // init page
                maxPage = Math.Max(1, (int)Math.Ceiling((double)res.rowCount / 10));
                pageLbl.Text = $"{page} | {maxPage}";

                if (res.Results.Count == 0)
                {
                    Label lbl = new();
                    lbl.Text = "No announcements at the moment";

                    DialogBuilder.Show("No announcements at the moment", "Fetch Announcements", MessageBoxIcon.Information);
                }

                foreach (Announcement ann in res.Results)
                {
                    flowLayoutPanel1.Controls.Add(new AnnouncementFullContainer(ann));
                }
            } else
            {
                this.loader.StopLoading();
                DialogBuilder.Show(res.Errors, "Fetch Announcements Failed", MessageBoxIcon.Hand);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.form.Enabled = true;
            this.Close();
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                this.page--;
                this.loader = new(this);
                this.loader.StartLoading();
                LoadAnnouncements();
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (page < maxPage)
            {
                this.page++;
                this.loader = new(this);
                this.loader.StartLoading();
                LoadAnnouncements();
            }
        }
    }
}
