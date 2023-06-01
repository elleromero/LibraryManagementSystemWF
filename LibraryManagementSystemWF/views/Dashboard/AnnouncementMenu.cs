using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystemWF.views.Dashboard
{
    public partial class AnnouncementMenu : Form
    {
        public AnnouncementMenu()
        {
            InitializeComponent();

            LoadAnnouncements();
        }

        private async void LoadAnnouncements()
        {
            // load data grid
            dataGridView1.Rows.Clear();

            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Header", "Header");
            dataGridView1.Columns.Add("Body", "Body");
            dataGridView1.Columns.Add("Due", "Due");
            dataGridView1.Columns.Add("Date Created", "Date Created");
            dataGridView1.Columns.Add("Cover", "Cover");
            dataGridView1.Columns.Add("Audience", "Audience");

            ControllerAccessData<Announcement> res = await AnnouncementController.GetAllWithPastDue();

            if (res.IsSuccess)
            {

                foreach (Announcement ann in res.Results)
                {

                    dataGridView1.Rows.Add(
                        ann.ID,
                        ann.Header,
                        ann.Body,
                        ann.Due.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                        ann.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                        ann.Cover,
                        string.Join(" ", ann.VisibleRoles)
                        );
                }
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
