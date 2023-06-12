using LibraryManagementSystemWF.models;
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
    public partial class AnnouncementContainer : UserControl
    {
        private Announcement ann;

        public AnnouncementContainer(Announcement ann)
        {
            InitializeComponent();

            this.ann = ann;
            lblHeader.Text = ann.Header;

            if (ann.IsPriority) this.BackColor = ColorTranslator.FromHtml("#fece2f");
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {
            new AnnouncementPreview(this.ann).Show();
        }
    }
}
