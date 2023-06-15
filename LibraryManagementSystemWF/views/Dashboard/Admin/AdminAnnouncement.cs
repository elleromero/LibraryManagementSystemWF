using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.interfaces;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
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

namespace LibraryManagementSystemWF.views.Dashboard.Admin
{
    public partial class AdminAnnouncement : Form, ICustomForm
    {
        private int currentPage = 1;
        private int maxPage = 1;
        private List<Announcement> annList = new();
        private Form form;
        private Loader loader;

        public AdminAnnouncement(Form form)
        {
            InitializeComponent();

            this.form = form;
            this.form.Enabled = false;

            this.loader = new(this);
            this.loader.StartLoading();

            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Header", "Header");
            dataGridView1.Columns.Add("Preview", "Preview");

            LoadAnnouncements();
        }

        public async void LoadAnnouncements()
        {
            dataGridView1.Rows.Clear(); // Clear existing rows before adding new ones

            ControllerAccessData<Announcement> res = await AnnouncementController.GetAll(currentPage);

            if (res.IsSuccess)
            {
                this.loader.StopLoading();

                if (res.rowCount == 0)
                {
                    DialogBuilder.Show("No announcements for now", "No Announcements", MessageBoxIcon.Information);
                    dataGridView1.Rows.Add(string.Empty, "No announcements for now");
                }

                // init page label
                maxPage = Math.Max(1, (int)Math.Ceiling((double)res.rowCount / 20));
                pageLbl.Text = $"{currentPage} | {maxPage}";

                annList = res.Results;

                for (int i = 0; i < annList.Count; i++)
                {
                    dataGridView1.Rows.Add(
                        annList[i].ID,
                        annList[i].Header,
                        annList[i].Body.Substring(0, Math.Min(100, annList[i].Body.Length))
                        );

                    if (annList[i].IsPriority) dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fece2f");
                }
            }
            else
            {
                this.loader.StopLoading();
                MessageBox.Show("Can't fetch announcements at the moment.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.form.Enabled = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string? annId = selectedRow.Cells["ID"].Value.ToString();

            if (annId != null)
            {
                foreach (Announcement ann in annList)
                {
                    if (ann.ID.ToString() == annId) 
                    {
                        new AnnouncementPreview(ann).ShowDialog();
                        break;
                    }
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                this.loader = new(this);
                this.loader.StartLoading();
                LoadAnnouncements();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (currentPage < maxPage)
            {
                currentPage++;
                this.loader = new(this);
                this.loader.StartLoading();
                LoadAnnouncements();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            new AnnouncementMenu(this, this).Show();
        }

        public void RefreshDataGrid()
        {
            this.currentPage = 1;
            LoadAnnouncements();
        }
    }
}
