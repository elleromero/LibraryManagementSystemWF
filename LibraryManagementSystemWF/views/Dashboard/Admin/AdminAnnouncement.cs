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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryManagementSystemWF.views.Dashboard.Admin
{
    public partial class AdminAnnouncement : Form
    {
        private int currentPage = 1;
        private int maxPage = 1;

        public AdminAnnouncement()
        {
            InitializeComponent();

            LoadAnnouncements();
        }

        public async void LoadAnnouncements()
        {
            dataGridView1.Rows.Clear(); // Clear existing rows before adding new ones

            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Header", "Header");
            dataGridView1.Columns.Add("Preview", "Preview");

            ControllerAccessData<Announcement> res = await AnnouncementController.GetAllBeforeDue();

            if (res.IsSuccess)
            {
                if (res.rowCount == 0) MessageBox.Show("No records found.");

                // init page label
                maxPage = Math.Max(1, (int)Math.Ceiling((double)res.rowCount / 20));
                pageLbl.Text = $"{currentPage} | {maxPage}";

                foreach (Announcement ann in res.Results)
                {
                    dataGridView1.Rows.Add(
                        ann.ID,
                        ann.Header,
                        ann.Body.Substring(0, Math.Min(100, ann.Body.Length))
                        );
                }
            }
            else MessageBox.Show("Can't fetch announcements at the moment.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            List<RoleEnum> roles = new();
            roles.Add(RoleEnum.ADMINISTRATOR);
            roles.Add(RoleEnum.USER);
            roles.Add(RoleEnum.LIBRARIAN);

            ControllerModifyData<Announcement> res = await AnnouncementController.Create(
                "Announcement Importantdsakjkd",
                "This is the body",
                DateTime.Now.AddMonths(12),
                roles
                
                );

            // MessageBox.Show(res.IsSuccess.ToString() + res.Result?.Header);

            foreach (KeyValuePair<string, string> error in res.Errors)
            {
                MessageBox.Show(error.Key + ": " + error.Value);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadAnnouncements();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (currentPage < maxPage)
            {
                currentPage++;
                LoadAnnouncements();
            }
        }
    }
}
