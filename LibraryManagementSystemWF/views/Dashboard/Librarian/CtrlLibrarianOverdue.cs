using LibraryManagementSystemWF.models;
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

namespace LibraryManagementSystemWF.views.Dashboard.Librarian
{
    public partial class CtrlLibrarianOverdue : UserControl
    {
        public CtrlLibrarianOverdue()
        {
            InitializeComponent();
            this.LoadPreview();
        }

        private void LoadPreview()
        {

            // load default preview
            panel1.Controls.Clear();
            panel1.Controls.Add(new UserContainer(new User
            {
                Username = "juan_54",
                Member = new Member
                {
                    FirstName = "Juan",
                    LastName = "Dela Cruz"
                },
                Role = new Role
                {
                    Name = "USER"
                }
            }, true));
        }
    }
}
