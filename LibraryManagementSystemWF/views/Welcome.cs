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

namespace LibraryManagementSystemWF.views
{
    public partial class Welcome : Form
    {
        private ScanLibraryCard slc;

        public Welcome()
        {
            InitializeComponent();

            this.slc = new ScanLibraryCard(this, this.callback);
        }

        private void callback(User user)
        {
            if (user != null) new GuestRepo(user, slc).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.slc.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SignIn(this).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
