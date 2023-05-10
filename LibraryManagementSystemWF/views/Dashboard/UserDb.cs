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

namespace LibraryManagementSystemWF.views
{
    public partial class UserDb : Form
    {
        public UserDb()
        {
            InitializeComponent();
        }
        public void loadform(object form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            loadform(new dashboard());
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            loadform(new booksform());
        }

        private void btnRes_Click(object sender, EventArgs e)
        {
            loadform(new reserveform());
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            loadform(new booksform());
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            loadform(new renewform());
        }
    }
}
