using LibraryManagementSystemWF.views.components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystemWF.views.Dashboard.AdminDashboardControl
{
    public partial class Ctrlbooksrevamp : UserControl
    {
        public Ctrlbooksrevamp()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                flowLayoutPanel1.Controls.Add(new BookContainer());
            }
        }
    }
}
