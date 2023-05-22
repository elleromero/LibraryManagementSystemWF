using LibraryManagementSystemWF.controllers;
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
            if (this.mainPanel.Controls.Count > 0)
                this.mainPanel.Controls.RemoveAt(0);
            Form f = form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(f);
            this.mainPanel.Tag = f;
            f.Show();
        }

        private void btnBorrowed_Click(object sender, EventArgs e)
        {
            loadform(new Borrow());
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            loadform(new Return());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            loadform(new Home());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AuthController.LogOut();
            new SignIn().Show();
            this.Close();
        }
    }
}
