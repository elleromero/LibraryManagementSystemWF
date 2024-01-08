using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.views.Dashboard.GeneralUser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystemWF.views
{
    public partial class GuestRepo : Form
    {
        private Form form;

        public GuestRepo(User user, Form form)
        {
            InitializeComponent();

            this.form = form;
            this.panel1.Controls.Add(new CtrlRepo(this, user));
        }

        private void GuestRepo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.form.Show();
        }
    }
}
