using LibraryManagementSystemWF.Dashboard.AdminDashboardControl;
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
    public partial class AdminDashboardRevamp : Form
    {
        private Ctrldashboard dashboard = new();
        private Ctrlbooks books = new();

        public AdminDashboardRevamp()
        {
            InitializeComponent();

            mainPanel.Controls.Add(dashboard);
            mainPanel.Controls.Add(books);

            dashboard.Visible = true;
            books.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dashboard.Visible = true;
            books.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dashboard.Visible = true;
            books.Visible = true;
        }
    }
}
