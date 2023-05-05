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

namespace LibraryManagementSystemWF.Dashboard
{
    public partial class AdminDashboard : Form
    {
        private Ctrldashboard dashboard = new Ctrldashboard();
        private Ctrlstatus status = new Ctrlstatus();
        private Ctrlauthor author = new Ctrlauthor();
        private Ctrlbooks books = new Ctrlbooks();
        private Ctrlloans loans = new Ctrlloans();
        private Ctrlmembers members = new Ctrlmembers();

        public AdminDashboard()
        {
            InitializeComponent();

            panelMainDesktop.Controls.Add(dashboard);
            panelMainDesktop.Controls.Add(status);
            panelMainDesktop.Controls.Add(author);
            panelMainDesktop.Controls.Add(books);
            panelMainDesktop.Controls.Add(loans);
            panelMainDesktop.Controls.Add(members);

            dashboard.Visible = false;
            status.Visible = false;
            author.Visible = false;
            books.Visible = false;
            loans.Visible = false;
            members.Visible = false;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            dashboard.Visible = true;
            status.Visible = false;
            author.Visible = false;
            books.Visible = false;
            loans.Visible = false;
            members.Visible = false;
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            dashboard.Visible = false;
            status.Visible = true;
            author.Visible = false;
            books.Visible = false;
            loans.Visible = false;
            members.Visible = false;
        }

        private void btnAuthor_Click(object sender, EventArgs e)
        {
            dashboard.Visible = false;
            status.Visible = false;
            author.Visible = true;
            books.Visible = false;
            loans.Visible = false;
            members.Visible = false;
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            dashboard.Visible = false;
            status.Visible = false;
            author.Visible = false;
            books.Visible = true;
            loans.Visible = false;
            members.Visible = false;
        }

        private void btnLoans_Click(object sender, EventArgs e)
        {
            dashboard.Visible = false;
            status.Visible = false;
            author.Visible = false;
            books.Visible = false;
            loans.Visible = true;
            members.Visible = false;
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            dashboard.Visible = false;
            status.Visible = false;
            author.Visible = false;
            books.Visible = false;
            loans.Visible = false;
            members.Visible = true;
        }
    }
}
