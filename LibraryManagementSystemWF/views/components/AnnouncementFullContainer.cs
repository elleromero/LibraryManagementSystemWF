using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
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

namespace LibraryManagementSystemWF.views.components
{
    public partial class AnnouncementFullContainer : UserControl
    {
        private Announcement announcement;

        public AnnouncementFullContainer(Announcement ann)
        {
            InitializeComponent();

            this.announcement = ann;

            this.titleLbl.Text = this.announcement.Header;
            this.subtitleLbl.Text = this.announcement.Body;

            if (File.Exists(this.announcement.Cover)) this.pictureBox1.Image = Image.FromFile(this.announcement.Cover);
        }

        private void titleLbl_Click(object sender, EventArgs e)
        {
            new AnnouncementPreview(this.announcement).ShowDialog();
        }

        private void titleLbl_MouseEnter(object sender, EventArgs e)
        {
            titleLbl.ForeColor = Color.Gray;
        }

        private void titleLbl_MouseLeave(object sender, EventArgs e)
        {
            titleLbl.ForeColor = Color.Black;
        }
    }
}
