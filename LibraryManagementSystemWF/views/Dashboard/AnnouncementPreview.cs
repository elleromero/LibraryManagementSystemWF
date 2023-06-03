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
    public partial class AnnouncementPreview : Form
    {
        public AnnouncementPreview(Announcement ann)
        {
            InitializeComponent();

            // set initial values
            headerLbl.Text = ann.Header;
            rtbBody.Text = ann.Body;
            announcedByLbl.Text = $"{ann.User.Member.FirstName} {ann.User.Member.LastName} ({ann.User.Username}) - {ann.User.Role.Name}";
            announcedOnLbl.Text = ann.Timestamp.ToString("MMM. d yyyy. dddd. hh:mm:ss tt");

            if (File.Exists(ann.Cover)) coverPictureBox.Image = Image.FromFile(ann.Cover);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
