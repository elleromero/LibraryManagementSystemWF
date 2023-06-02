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
        private List<Announcement> announcements = new();

        public AnnouncementMenu()
        {
            InitializeComponent();

            // load data grid columns
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Header", "Header");
            dataGridView1.Columns.Add("Body", "Body");
            dataGridView1.Columns.Add("Due", "Due");
            dataGridView1.Columns.Add("Date Created", "Date Created");
            dataGridView1.Columns.Add("Cover", "Cover");
            dataGridView1.Columns.Add("Audience", "Audience");

            LoadAnnouncements();
        }

        private async void LoadAnnouncements()
        {
            ControllerAccessData<Announcement> res = await AnnouncementController.GetAllWithPastDue();

            if (res.IsSuccess)
            {
                // clear data grid
                dataGridView1.Rows.Clear();

                announcements = res.Results;
                foreach (Announcement ann in announcements)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string rowId = row.Cells["ID"].Value.ToString() ?? string.Empty;

                // Set the values of the text boxes to the values in the clicked row
                foreach (Announcement ann in announcements)
                {
                    if (rowId == ann.ID.ToString())
                    {
                        textAnnouncementID.Text = ann.ID.ToString();
                        txtHeader.Text = ann.Header;
                        txtBody.Text = ann.Body;
                        dtpAnnouncementDue.Value = ann.Due;
                        txtCover.Text = ann.Cover;
                        checkBoxImportant.Checked = ann.IsPriority;

                        // set checkbox
                        checkBoxAdmin.Checked = ann.VisibleRoles.Contains(RoleEnum.ADMINISTRATOR);
                        checkBoxUser.Checked = ann.VisibleRoles.Contains(RoleEnum.USER);
                        checkBoxLibrarian.Checked = ann.VisibleRoles.Contains(RoleEnum.LIBRARIAN);
                    }
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // publish announcement
            List<RoleEnum> publishToRoles = new();

            if (checkBoxAdmin.Checked) publishToRoles.Add(RoleEnum.ADMINISTRATOR);
            if (checkBoxLibrarian.Checked) publishToRoles.Add(RoleEnum.LIBRARIAN);
            if (checkBoxUser.Checked) publishToRoles.Add(RoleEnum.USER);

            ControllerModifyData<Announcement> res = await AnnouncementController.Create(
                txtHeader.Text,
                txtBody.Text,
                dtpAnnouncementDue.Value,
                publishToRoles,
                txtCover.Text,
                checkBoxImportant.Checked
                );

            if (res.IsSuccess)
            {
                MessageBox.Show("Announcement is published!");
                LoadAnnouncements();
            } else
            {
                foreach (KeyValuePair<string, string> error in res.Errors)
                {
                    MessageBox.Show($"{error.Key}: {error.Value}");
                }
            }
        }
    }
}
